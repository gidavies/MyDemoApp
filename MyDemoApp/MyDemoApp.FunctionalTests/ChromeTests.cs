using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace MyDemoApp.FunctionalTests
{
    [TestClass]
    public class ChromeTests
    {

        #region Initialisation
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
        #endregion

        #region Home Page Tests
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

        [TestMethod]
        public void HomePageHeadingTest()
        {
            try
            {
                string expectedHeading = "My Resources";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("HomeHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void HomePageSlidesCardTest()
        {
            try
            {
                string expectedHeading = "Slides";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("SlidesCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected card heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void HomePageLabsCardTest()
        {
            try
            {
                string expectedHeading = "Hands on Labs";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("LabsCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected card heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void HomePageTrainingCardTest()
        {
            try
            {
                string expectedHeading = "Azure Training";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("TrainingCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected card heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void HomePageBlogsCardTest()
        {
            try
            {
                string expectedHeading = "Blog Posts";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("BlogCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected card heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void HomePageWebinarsCardTest()
        {
            try
            {
                string expectedHeading = "Webinars";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString();
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("WebinarsHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected card heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        #endregion

        #region Colours Page Tests
        [TestMethod]
        public void ColoursPageTitleTest()
        {
            try
            {
                string expectedTitle = "Colours - Giles Davies";
                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Colours";
                driver.Navigate().GoToUrl(webAppUrl);
                Assert.AreEqual(expectedTitle, driver.Title, "Expected title to be '" + expectedTitle + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void ColoursPageConfigurationCardTest()
        {
            try
            {
                string expectedHeading = "Configuration";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Colours";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("ColoursConfigCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void ColoursPageRunCardTest()
        {
            try
            {
                string expectedHeading = "Run";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Colours";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("ColoursRunCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        #endregion

        #region Messaging Page Tests
        [TestMethod]
        public void MessagingPageTitleTest()
        {
            try
            {
                string expectedTitle = "Messaging - Giles Davies";
                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Messaging";
                driver.Navigate().GoToUrl(webAppUrl);
                Assert.AreEqual(expectedTitle, driver.Title, "Expected title to be '" + expectedTitle + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void MessagingPageQueuesCardTest()
        {
            try
            {
                string expectedHeading = "Queues";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Messaging";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("QueuesCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void MessagingPageTopicsCardTest()
        {
            try
            {
                string expectedHeading = "Topics";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/Messaging";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("TopicsCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        #endregion

        #region About Page Tests
        [TestMethod]
        public void AboutPageTitleTest()
        {
            try
            {
                string expectedTitle = "About - Giles Davies";
                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/About";
                driver.Navigate().GoToUrl(webAppUrl);
                Assert.AreEqual(expectedTitle, driver.Title, "Expected title to be '" + expectedTitle + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void AboutPageMeCardTest()
        {
            try
            {
                string expectedHeading = "Me";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/About";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("MeCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void AboutPageStatusCardTest()
        {
            try
            {
                string expectedHeading = "Pipeline status";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/About";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("StatusCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void AboutPageAppCardTest()
        {
            try
            {
                string expectedHeading = "This app";

                driver = GetChromeDriver();
                var webAppUrl = testContext.Properties["webAppUrl"].ToString() + "/Home/About";
                driver.Navigate().GoToUrl(webAppUrl);
                RemoteWebElement headingElement = (RemoteWebElement)driver.FindElementById("AppCardHeading");

                Assert.AreEqual(expectedHeading, headingElement.Text, "Expected heading to be '" + expectedHeading + "'");
            }
            finally
            {
                driver.Quit();
            }
        }
        #endregion
    }
}