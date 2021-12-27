using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult EditCustomer()
        {
            return View();
        }

        public IActionResult DisableCustomer()
        {
            return View();
        }
    }
}
