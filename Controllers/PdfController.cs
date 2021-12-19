using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Bicks.Areas.Invoicing.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Bicks.Controllers
{
    public class PdfController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public PdfController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult SalesInvoiceTemplate(SalesInvoiceViewModel salesInvoiceViewModel)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string directory = System.IO.Path.Combine(wwwRootPath, "Invoices");
            string filepath = System.IO.Path.Combine(directory, "test.pdf");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            ControllerContext controllerContext = new ControllerContext(this.ControllerContext);
            ViewAsPdf viewAsPdf = new ViewAsPdf("SalesInvoiceTemplate", salesInvoiceViewModel) { FileName = "test.pdf"};
            var pdfAsByte = viewAsPdf.BuildFile(controllerContext).Result;
            System.IO.File.WriteAllBytes(filepath, pdfAsByte);
            return null;
        }
    }
}
