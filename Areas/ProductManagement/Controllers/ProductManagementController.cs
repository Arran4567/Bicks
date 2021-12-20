using Bicks.Areas.Invoicing.Controllers;
using Bicks.Areas.ProductManagement.Data.DAL;
using Bicks.Models;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bicks.Areas.ProductManagement.ViewModels;

namespace Bicks.Areas.ProductManagement.Controllers
{
    [Area("ProductManagement")]
    public class ProductManagementController : Controller
    {
        private readonly ILogger<InvoicingController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private ProductManagementWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public ProductManagementController(ILogger<InvoicingController> logger, UserManager<ApplicationUser> userManager, ProductManagementWorkUnit workUnit,
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

        public IActionResult EditProduct(int id)
        {
            EditProductViewModel editProductViewModel = new EditProductViewModel()
            {
                Product = _workUnit.ProductRepository.GetByID(id),
                Categories = _workUnit.CategoryRepository.Get().ToList(),
            };
            return View(editProductViewModel);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel editProductViewModel)
        {
            Category category = _workUnit.CategoryRepository.GetByID(editProductViewModel.Product.Category.ID);
            editProductViewModel.Product.Category = category;
            _workUnit.ProductRepository.Update(editProductViewModel.Product);
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductList()
        {
            return View(_workUnit.ProductRepository.Get(orderBy: pr => pr.OrderBy(p => p.Category).OrderBy(p => p.Name)));
        }
    }
}
