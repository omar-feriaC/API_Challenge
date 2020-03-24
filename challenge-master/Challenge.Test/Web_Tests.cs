using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseFramework.WebPages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Challenge.Test
{
   // [TestClass]
    public class Web_Tests 
    {
        private IWebDriver driver;
        string url;
        public MainPage login;      
        
        [SetUp]
        public void BeforeTest()
        {
            url = Environment.GetEnvironmentVariable("url", EnvironmentVariableTarget.User);
            driver = new ChromeDriver();
            driver.Url = url;
            //login = new MainPage(driver);
        }    
        
        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            login.fnEnterUserLastname("Ku");
            login.fnPositiveTest();

        }
    }
}
