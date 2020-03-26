using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        public static IWebDriver driver;
        private static readonly string url = "http://ztestqa.com/selenium/mainpage.html";


        [SetUp]
        /*Initialize the driver and indicates the url*/
        public static void SetUp()
        {
         
            driver = new ChromeDriver();
            driver.Url = url;
        }

        [TearDown]
        /*Close the browser and quit the selenium instance*/
        public static void AfterTest()
        {
                driver.Close();
                driver.Quit();

        }
    }
}
