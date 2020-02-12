using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaseFramework.WebPages;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        static ChromeDriver driver = new ChromeDriver();
        MainPage page = new MainPage(driver);

        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            driver.Url = page.url;
            page.fnAddFirstName("Hector");
            page.fnAddLastName("Castillo");
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnClickSubmitBtn();
        }
    }
}
