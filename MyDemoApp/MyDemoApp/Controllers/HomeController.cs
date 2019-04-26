﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDemoApp.Models;
using MyDemoApp.Web.Models;

namespace MyDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colours(ColoursModel model)
        {
            ColoursModel coloursMod = new ColoursModel
            {
                ColoursAPIUrl = model.ColoursAPIUrl
            };
            return View(coloursMod);
        }

        public IActionResult Messaging(MessagingModel model)
        {
            Task t = new MessagingModel().SendMessageAsync(model);

            return View();
            //return Content($"Message {model.SBMessage} sent");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
