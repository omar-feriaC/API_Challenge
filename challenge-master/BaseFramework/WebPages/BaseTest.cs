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
        //**************************************************
        //*                V A R I A B L E S
        //**************************************************

        /*Webdriver Instance*/
        public static clsDriver objclsDriver;
        public static IWebDriver driver;
        /*URL for Webdriver*/
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("webUrl");




        //**************************************************
        //                  M E T H O D S 
        //**************************************************
        [SetUp]
        //SetUp Before each test case
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
            driver.Manage().Window.Maximize();
            objclsDriver = new clsDriver(driver);

        }

        [TearDown]
        //TearDown After each test case
        public static void AfterTest()
        {
            driver.Close();
            driver.Quit();
        }

        /*Clear and Send text to specific field*/
        public static void FnSendkeyAndClear(By by, string pstrText)
        {
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(pstrText);
        }

    }
}

