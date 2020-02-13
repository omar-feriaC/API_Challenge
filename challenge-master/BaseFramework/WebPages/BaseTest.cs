using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace BaseFramework.WebPages
{
    class BaseTest
    {
        //**************************************************
        //*                V A R I A B L E S
        //**************************************************

        /*Webdriver Intance*/
        public static IWebDriver driver;
        /*URL for Webdriver*/
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("url");

        //**************************************************
        //                  M E T H O D S 
        //**************************************************

        [SetUp]
        /*Initialize the driver and indicates the url*/
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
        }

        [TearDown]
        /*Close the browser and quit the selenium instance*/
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
