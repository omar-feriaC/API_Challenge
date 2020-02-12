using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests:BaseTest
    {
        //MainPage objMainPage = new MainPage(driver);
        //IWebDriver driver ;

        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            
        }
    }
}
