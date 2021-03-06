﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMS.Models;
using AMS.Services.Customers;

namespace AMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Cache(name:"System")]
        public IActionResult Index()
        {
            var account = _accountService.GetRoleList().FirstOrDefault();
            if (account != null)
            {
                ViewBag.UserName = account.Name;
            }
            else
                ViewBag.UserName = "nulllllllllll";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
