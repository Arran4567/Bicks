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

        public IActionResult EditSale(int id)
        {
            return View();
        }

        public IActionResult GenerateInvoice(int id)
        {
            Sale sale = _workUnit.SaleRepository.GetByID(id);
            SalesInvoiceViewModel salesInvoiceViewModel = _workUnit.SaleRepository.GenerateInvoice(sale);
            string filename = salesInvoiceViewModel.InvoiceNo.ToString("000000") + ".pdf";
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string directory = System.IO.Path.Combine(wwwRootPath, "Invoices");
            string filepath = System.IO.Path.Combine(directory, filename);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            ControllerContext controllerContext = new ControllerContext(this.ControllerContext);
            ViewAsPdf viewAsPdf = new ViewAsPdf("SalesInvoiceTemplate", salesInvoiceViewModel) { FileName = $"{salesInvoiceViewModel.InvoiceNo}.pdf" };
            var pdfAsByte = viewAsPdf.BuildFile(controllerContext).Result;
            System.IO.File.WriteAllBytes(filepath, pdfAsByte);
            return RedirectToAction("SalesList");
        }

        public IActionResult GenerateExampleSale()
        {
            _workUnit.GenerateExampleSale();
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
