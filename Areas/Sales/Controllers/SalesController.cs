using Bicks.Areas.Sales.Data.DAL;
using Bicks.Models;
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

namespace Bicks.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private SalesWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public SalesController(ILogger<SalesController> logger, UserManager<ApplicationUser> userManager, SalesWorkUnit workUnit,
            IWebHostEnvironment hostEnvironment, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _userManager = userManager;
            _workUnit = workUnit;
            _hostEnvironment = hostEnvironment;
            _backgroundJobClient = backgroundJobClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalesList()
        {
            ViewData["RootLoc"] = _hostEnvironment.WebRootPath;
            return View(_workUnit.SaleRepository.Get(orderBy: sr => sr.OrderByDescending(s => s.ID)));
        }

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

        public async Task<IActionResult> GenerateInvoice(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            SalesInvoiceViewModel salesInvoiceViewModel = _workUnit.SaleRepository.GenerateInvoice(sale);
            string filename =  $"{salesInvoiceViewModel.InvoiceNo.ToString("0000000")}.pdf";
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

        public IActionResult DeleteSale(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            _workUnit.DeleteSale(sale);
            _workUnit.Save();
            return RedirectToAction("SalesList");
        }
    }
}
