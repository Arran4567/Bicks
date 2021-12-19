using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bicks.Areas.Invoicing.ViewModels;
using Bicks.Areas.Invoicing.Data.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Bicks.Models;
using Rotativa.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Bicks.Areas.Invoicing.Controllers
{
    [Area("Invoicing")]
    public class InvoicingController : Controller
    {
        private readonly ILogger<InvoicingController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private InvoicingWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostEnvironment;

        public InvoicingController(ILogger<InvoicingController> logger, UserManager<ApplicationUser> userManager, InvoicingWorkUnit workUnit,
            IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _userManager = userManager;
            _workUnit = workUnit;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateInvoice()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerateExampleInvoice()
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string directory = wwwRootPath;
            string filepath = System.IO.Path.Combine("test.txt", directory);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            ViewAsPdf viewAsPdf = _workUnit.GenerateExampleInvoice();
            byte[] pdfAsByteArray = viewAsPdf.BuildFile(this.ControllerContext).Result;
            System.IO.File.WriteAllBytes(filepath, pdfAsByteArray);
            return RedirectToAction("Index");
        }
    }
}
