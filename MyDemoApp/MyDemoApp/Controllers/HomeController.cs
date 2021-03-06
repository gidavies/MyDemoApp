﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using MyDemoApp.Models;
using MyDemoApp.Web.Models;

namespace MyDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private TelemetryClient telemetry;

        // use constructor injection to get TelemetryClient instance
        public HomeController(TelemetryClient telemetry)
        {
            this.telemetry = telemetry;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View(new AboutModel());
        }

        public IActionResult Colours()
        {
            return View();
        }

        public IActionResult Messaging(MessagingModel model)
        {
            try
            {
                model.telemetryClient = telemetry;
                model.SendMessage();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Webinars()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
