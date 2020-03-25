using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        public static IWebDriver objdriver;

        /*public MainPage(IWebDriver driver)
        {
            this.objdriver = driver;
        }*/


        [SetUp]
        public void BeforeAlTest()
        {
            objdriver = new ChromeDriver();
            objdriver.Url = url;
            objdriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            objdriver.Close();
        }
        [OneTimeTearDown]
        public void AfterAllTests()
        {
            objdriver.Quit();
        }

    }
}
