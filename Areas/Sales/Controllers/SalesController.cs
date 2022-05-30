using Bicks.Areas.Sales.Data.DAL;
using Bicks.Models;
using Bicks.Library.Mail;
using Bicks.Services;
using Bicks.Areas.Sales.ViewModels;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Rotativa.AspNetCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;
using Bicks.Entities;

namespace Bicks.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize(Roles = Role.Sales)]
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private readonly IMailService _mailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private SalesWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SalesController(ILogger<SalesController> logger, IMailService mailService, UserManager<ApplicationUser> userManager, SalesWorkUnit workUnit,
            IWebHostEnvironment hostEnvironment, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _mailService = mailService;
            _userManager = userManager;
            _workUnit = workUnit;
            _hostEnvironment = hostEnvironment;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SalesList()
        {
            return View(_workUnit.SaleRepository.Get(orderBy: sr => sr.OrderByDescending(s => s.ID)));
        }

        [HttpGet]
        public IActionResult CreateSale(int id)
        {
            if (_workUnit.isClient(id))
            {
                SaleViewModel saleViewModel = new SaleViewModel
                {
                    Client = _workUnit.ClientRepository.GetByID(id),
                    InvoiceItems = new List<InvoiceItem>()
                };
                List<InvoiceItem> recommendedItems = _workUnit.GetRecommendedItems(id);
                saleViewModel.RecommendedItems = recommendedItems;
                List<Product> products = _workUnit.ProductRepository.Get(orderBy: pr => pr.OrderBy(p => p.Name)).ToList();
                foreach (Product product in products)
                {
                    if (recommendedItems.Count > 0)
                    {
                        foreach (InvoiceItem recommendedItem in recommendedItems)
                        {
                            if (!recommendedItem.Product.Equals(product))
                            {
                                saleViewModel.InvoiceItems.Add(new InvoiceItem
                                {
                                    Product = product
                                });
                            }
                        }
                    }
                    else
                    {
                        saleViewModel.InvoiceItems.Add(new InvoiceItem
                        {
                            Product = product
                        });
                    }
                }
                return View(saleViewModel);
            }
            return RedirectToAction("SalesList");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleViewModel saleViewModel)
        {
            Sale sale = _workUnit.CreateNewSaleFromViewModel(saleViewModel);
            if(sale == null)
            {
                return RedirectToAction("ClientList");
            }
            _workUnit.SaleRepository.Insert(sale);
            _workUnit.Save();
            await GeneratePackingSheet(sale.ID);
            return RedirectToAction("SalesList");
        }

        [HttpGet]
        public IActionResult EditSale(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            return View(_workUnit.GetViewModelFromSale(sale));
        }

        [HttpPut]
        public async Task<IActionResult> EditSale(SaleViewModel saleViewModel)
        {
            Sale sale = _workUnit.UpdateExistingSaleFromViewModel(saleViewModel);
            _workUnit.SaleRepository.Update(sale);
            _workUnit.Save();
            await GeneratePackingSheet(sale.ID);
            return RedirectToAction("SalesList");
        }

        [HttpGet]
        public async Task<IActionResult> GenerateInvoice(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            SalesInvoiceViewModel salesInvoiceViewModel = _workUnit.SaleRepository.GenerateInvoice(sale);
            string filename = $"{salesInvoiceViewModel.InvoiceNo.ToString("0000000")}.pdf";
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string directory = System.IO.Path.Combine(wwwRootPath, "Invoices");
            string filepath = System.IO.Path.Combine(directory, filename);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            ControllerContext controllerContext = new ControllerContext(this.ControllerContext);
            ViewAsPdf viewAsPdf = new ViewAsPdf("SalesInvoiceTemplate", salesInvoiceViewModel) { FileName = filename };
            var pdfAsByte = await viewAsPdf.BuildFile(controllerContext);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            System.IO.File.WriteAllBytes(filepath, pdfAsByte);
            return RedirectToAction("Invoicing", sale);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            _workUnit.DeleteSale(sale);
            _workUnit.Save();
            return RedirectToAction("SalesList");
        }

        [HttpGet]
        public IActionResult Invoicing(int id)
        {
            ViewData["RootLoc"] = _hostEnvironment.WebRootPath;
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            return View(sale);
        }

        [HttpGet]
        public IActionResult SendInvoice(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            string wwwRoot = _hostEnvironment.WebRootPath;
            string directory = System.IO.Path.Combine(wwwRoot, "Invoices");
            string filePath = System.IO.Path.Combine(directory, $"{id.ToString("0000000")}.pdf");
            Mail invoiceEmail = new Mail
            {
                ToEmail = sale.Client.ContactEmail,
                Subject = $"Invoice #{sale.ID.ToString("0000000")}",
                Body = $"Please find attached a copy of invoice #{sale.ID.ToString("0000000")}",
                Attachments = new List<string>
                {
                    filePath
                }
            };
            _mailService.SendEmailNow(invoiceEmail);
            return RedirectToAction("SalesList");
        }

        public IActionResult Packing(int id)
        {
            ViewData["RootLoc"] = _hostEnvironment.WebRootPath;
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            return View(sale);
        }

        public async Task<IActionResult> PackingSheetRedirection(int id)
        {
            await GeneratePackingSheet(id);
            return RedirectToAction("Packing");
        } 

        private async Task GeneratePackingSheet(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            string filename = $"{sale.ID.ToString("0000000")}.pdf";
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string directory = System.IO.Path.Combine(wwwRootPath, "PackingSheets");
            string filepath = System.IO.Path.Combine(directory, filename);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            ControllerContext controllerContext = new ControllerContext(this.ControllerContext);
            ViewAsPdf viewAsPdf = new ViewAsPdf("PackingSheetTemplate", sale) { FileName = filename };
            var pdfAsByte = await viewAsPdf.BuildFile(controllerContext);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            System.IO.File.WriteAllBytes(filepath, pdfAsByte);
        }
    }
}
