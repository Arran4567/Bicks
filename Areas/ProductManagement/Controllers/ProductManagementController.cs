using Bicks.Areas.ProductManagement.Data.DAL;
using Bicks.Models;
using Bicks.ViewModels;
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
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bicks.Areas.ProductManagement.Controllers
{
    [Area("ProductManagement")]
    public class ProductManagementController : Controller
    {
        private readonly ILogger<ProductManagementController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private ProductManagementWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public ProductManagementController(ILogger<ProductManagementController> logger, UserManager<ApplicationUser> userManager, ProductManagementWorkUnit workUnit,
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

        public IActionResult ProductList()
        {
            return View(_workUnit.ProductRepository.Get(orderBy: pr => pr.OrderBy(p => p.SubCategory.Category.Name).ThenBy(p => p.Name)));
        }

        public IActionResult CreateProduct()
        {
            ProductViewModel editProductViewModel = new ProductViewModel()
            {
                SubCategories = _workUnit.SubCategoryRepository.Get().ToList()
            };
            return View(editProductViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(ProductViewModel editProductViewModel)
        { 
            Category category = _workUnit.CategoryRepository.GetByID(editProductViewModel.Product.SubCategory.Category.ID);
            editProductViewModel.Product.SubCategory.Category = category;
            _workUnit.ProductRepository.Insert(editProductViewModel.Product);
            _workUnit.Save();
            return RedirectToAction("ProductList");
        }

        public IActionResult EditProduct(int id)
        {
            ProductViewModel editProductViewModel = new ProductViewModel()
            {
                Product = _workUnit.ProductRepository.GetByID(id),
                SubCategories = _workUnit.SubCategoryRepository.Get().ToList(),
            };
            return View(editProductViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(ProductViewModel editProductViewModel)
        {
            SubCategory subCategory = _workUnit.SubCategoryRepository.GetByID(editProductViewModel.Product.SubCategory.ID);
            editProductViewModel.Product.SubCategory = subCategory;
            _workUnit.ProductRepository.Update(editProductViewModel.Product);
            _workUnit.Save();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            Product product = _workUnit.ProductRepository.GetByID(id);
            _workUnit.ProductRepository.Delete(product);
            _workUnit.Save();
            return RedirectToAction("ProductList");
        }

        public IActionResult StockList()
        {
            return View(_workUnit.ProductRepository.Get(orderBy: pr => pr.OrderBy(p => p.SubCategory.Category.Name).ThenBy(p => p.Name)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StockList(List<Product> products)
        {
            _workUnit.ProductRepository.UpdateStock(products);
            _workUnit.Save();
            return RedirectToAction("StockList");
        }

        public IActionResult CategoryList()
        {
            return View(_workUnit.CategoryRepository.Get(orderBy: cr => cr.OrderBy(c => c.Name)));
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category) 
        { 
            _workUnit.CategoryRepository.Insert(category);
            _workUnit.Save();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            if (_workUnit.SubCategoryRepository.GetByID(id) != null)
            {
                return View(_workUnit.CategoryRepository.GetByID(id));
            }
            return View("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category)
        {
            _workUnit.CategoryRepository.Update(category);
            _workUnit.Save();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            Category category = _workUnit.CategoryRepository.GetByID(id);
            _workUnit.CategoryRepository.Delete(category);
            _workUnit.Save();
            return RedirectToAction("CategoryList");
        }

        public IActionResult SubCategoryList()
        {
            return View(_workUnit.SubCategoryRepository.Get(orderBy: cr => cr.OrderBy(c => c.Name)));
        }

        public IActionResult CreateSubCategory()
        {
            ViewBag.Categories = _workUnit.CategoryRepository.Get().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSubCategory(SubCategory subCategory)
        {
            Category category = _workUnit.CategoryRepository.GetByID(subCategory.Category.ID);
            subCategory.Category = category;
            _workUnit.SubCategoryRepository.Insert(subCategory);
            _workUnit.Save();
            return RedirectToAction("SubCategoryList");
        }

        [HttpGet]
        public IActionResult EditSubCategory(int id)
        {
            ViewBag.Categories = _workUnit.CategoryRepository.Get().ToList();
            if (_workUnit.SubCategoryRepository.GetByID(id) != null)
            {
                return View(_workUnit.SubCategoryRepository.GetByID(id));
            }
            return View("SubCategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSubCategory(SubCategory subCategory)
        {
            _workUnit.SubCategoryRepository.Update(subCategory);
            _workUnit.Save();
            return RedirectToAction("SubCategoryList");
        }

        public IActionResult DeleteSubCategory(int id)
        {
            SubCategory subCategory = _workUnit.SubCategoryRepository.GetByID(id);
            _workUnit.SubCategoryRepository.Delete(subCategory);
            _workUnit.Save();
            return RedirectToAction("SubCategoryList");
        }
    }
}
