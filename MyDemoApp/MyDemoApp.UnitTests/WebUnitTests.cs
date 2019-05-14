using MyDemoApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDemoApp.Web.Models;
using Microsoft.ApplicationInsights;

namespace MyDemoApp.UnitTests
{
    // Some simple unit tests to check the controllers
    [TestClass]
    public class WebUnitTests
    {
        [TestMethod]
        public void HomePageTest()
        {
            var controller = new HomeController(new TelemetryClient());
            IActionResult result = controller.Index();
            Assert.AreEqual(null, controller.ViewData["Message"]);
        }

        [TestMethod]
        public void AboutPageTest()
        {
            var controller = new HomeController(new TelemetryClient());
            IActionResult result = controller.About();
            Assert.AreEqual(null, controller.ViewData["Message"]);
        }

        [TestMethod]
        public void ColoursPageTest()
        {
            var controller = new HomeController(new TelemetryClient());
            IActionResult result = controller.Colours();
            Assert.AreEqual(null, controller.ViewData["Message"]);
        }

        [TestMethod]
        public void MessagingPageTest()
        {
            var controller = new HomeController(new TelemetryClient());
            var messagingModel = new MessagingModel();
            IActionResult result = controller.Messaging(messagingModel);
            Assert.AreEqual(null, controller.ViewData["Message"]);
        }
    }
}
