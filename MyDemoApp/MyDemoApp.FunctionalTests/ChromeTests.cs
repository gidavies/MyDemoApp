using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace MyDemoApp.FunctionalTests
{
    [TestClass]
    public class ChromeTests
    {
        private static TestContext testContext;
        private RemoteWebDriver driver;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            ChromeTests.testContext = testContext;
        }

        private RemoteWebDriver GetChromeDriver()
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");

            if (!string.IsNullOrWhiteSpace(path))
            {
                return new ChromeDriver(path, options, TimeSpan.FromSeconds(300));
            }
            else
            {
                return new ChromeDriver(options);
            }
        }

        [TestMethod]
        public void HomePageTitleTest()
        {
            try
            {
                string expectedTitle = "Home Page - Giles Davies";
                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                Assert.AreEqual(expectedTitle, driver.Title, "Expected title to be '" + expectedTitle + "'");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
