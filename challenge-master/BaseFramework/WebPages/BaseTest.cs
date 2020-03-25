using BaseFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.WebPages
{
    public class BaseTest
    {
        
        public static clsDriver objclsDriver;
        public static IWebDriver driver;
        
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("webUrl");

        
    
        [SetUp]
        
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
            driver.Manage().Window.Maximize();
            objclsDriver = new clsDriver(driver);

        }

        [TearDown]
        
        public static void AfterTest()
        {
            driver.Close();
            driver.Quit();
        }

        
        public static void FnSendkeyAndClear(By by, string pstrText)
        {
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(pstrText);
        }

    }
}

