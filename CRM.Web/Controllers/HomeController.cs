using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.CustomerApplication;
using Microsoft.AspNetCore.Mvc;
using CRM.Web.Models;

namespace CRM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            bool isExist = _customerService.IsExist("001", "ywd");

            ViewBag.IsExist = isExist;

            ViewBag.AllCustomers = _customerService.GetAll();

            return View();
        }
    }
}
