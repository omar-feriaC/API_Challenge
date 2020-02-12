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
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnClickSubmitBtn();

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_FirstName_Empty_Negative()
        {
            driver.Url = page.url;
            page.fnAddLastName("Castillo");
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnClickSubmitBtn();

            driver.Quit();


        }

        [TestMethod]
        public void MainPage_LastName_Empty_Negative()
        {
            driver.Url = page.url;
            page.fnAddFirstName("Hector");
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnClickSubmitBtn();

            driver.Quit();


        }

        [TestMethod]
        public void MainPage_Wrong_Checkbox_Selected_Negative()
        {
            driver.Url = page.url;
            page.fnAddFirstName("Hector");
            page.fnAddLastName("Castillo");
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnC();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnClickSubmitBtn();

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_Negative()
        {
            driver.Url = page.url;
            page.fnAddFirstName("Hector");
            page.fnAddLastName("Castillo");
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("4");
            page.fnClickSubmitBtn();

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_Wrong_Second_Dropdown_Selected_Negative()
        {
            driver.Url = page.url;
            page.fnAddFirstName("Hector");
            page.fnAddLastName("Castillo");
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown("5");
            page.fnNoSelectDropdown("5");
            page.fnClickSubmitBtn();

            driver.Quit();
        }
    }
}
