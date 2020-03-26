using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.WebPages
{
    public class BaseTest
    {
        public static IWebDriver driver;
        private static string strBrowserName = "http://ztestqa.com/selenium/mainpage.html";

        [SetUp]
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
        }

        [TearDown]
        public static void AfterTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
