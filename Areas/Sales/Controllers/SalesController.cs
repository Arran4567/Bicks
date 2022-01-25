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
            ViewData["RootLoc"] = _hostEnvironment.WebRootPath;
            return View(_workUnit.SaleRepository.Get(orderBy: sr => sr.OrderByDescending(s => s.ID)));
        }

        [HttpGet]
        public IActionResult CreateSale()
        {
            SaleViewModel saleViewModel = new SaleViewModel
            {
                ClientList = _workUnit.ClientRepository.Get(orderBy: cr => cr.OrderBy(c => c.Name)).ToList(),
                InvoiceItems = new List<InvoiceItem>()
            };
            List<Product> products = _workUnit.ProductRepository.Get(orderBy: pr => pr.OrderBy(p => p.ID)).ToList();
            foreach (Product product in products)
            {
                saleViewModel.InvoiceItems.Add(new InvoiceItem
                {
                    Product = product
                });
            }
            return View(saleViewModel);
        }

        [HttpPost]
        public IActionResult CreateSale(SaleViewModel saleViewModel)
        {
            _workUnit.SaleRepository.Insert(_workUnit.CreateNewSaleFromViewModel(saleViewModel));
            _workUnit.Save();
            return RedirectToAction("SalesList");
        }

        [HttpGet]
        public IActionResult EditSale(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            return View(_workUnit.GetViewModelFromSale(sale));
        }

        [HttpPost]
        public IActionResult EditSale(SaleViewModel saleViewModel)
        {
            _workUnit.SaleRepository.Update(_workUnit.UpdateExistingSaleFromViewModel(saleViewModel));
            _workUnit.Save();
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
            return RedirectToAction("SalesList");
        }

        [HttpGet]
        public IActionResult DeleteSale(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            _workUnit.DeleteSale(sale);
            _workUnit.Save();
            return RedirectToAction("SalesList");
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
    }
}
