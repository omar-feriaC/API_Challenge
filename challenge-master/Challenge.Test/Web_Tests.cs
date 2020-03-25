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

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }

        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            login.fnEnterUserLastname("Ku");
            login.fnPositiveTest();
        }
        [Test]
        public void NegativeFirstNameEmpty()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("");
            login.fnEnterUserLastname("Ku");
            login.fnPositiveTest();
        }
        [Test]
        public void NegativeLastNameEmpty()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            login.fnEnterUserLastname("");
            login.fnPositiveTest();
        }
        [Test]
        public void NegativeWrongCheckBox()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            login.fnEnterUserLastname("Ku");
            login.fnAddCheckBoxC();
        }
        [Test]
        public void NegativeWrongFirstDropDnw()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            
            login.fnEnterUserLastname("Ku");
            login.fnWrongFirstDropDwn();
        }
        [Test]
        public void NegativeWrongSecondDropDnw()
        {
            login = new MainPage(driver);
            login.fnEnterUsername("Manuel");
            login.fnEnterUserLastname("Ku");
            login.fnWrongSecondDropDwn();
        }

    }
}
