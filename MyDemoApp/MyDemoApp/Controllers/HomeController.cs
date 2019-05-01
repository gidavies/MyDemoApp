using System;
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

        public IActionResult About()
        {
            return View(new AboutModel());
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
            try
            {
                new MessagingModel().SendMessage(model);
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
