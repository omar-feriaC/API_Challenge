using System;
using System.Configuration;
using BaseFramework;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        MainPage mainPage;
        //public static IWebDriver driver = new ChromeDriver();


        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            try
            {
                //mainPage = new MainPage(driver);
                string firstName = "Jose";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("Novelo");
                mainPage.fnClickB();
                mainPage.fnClickC(false);
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("5");
                mainPage.fnClickSubmit();
                string PopUpMessage = String.Format("Congratulations {0}! Everything was properly populated", firstName);
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MainPage_First_Name_Empty()
        {
            try
            {
                string firstName = "";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("Novelo");
                mainPage.fnClickB();
                mainPage.fnClickC(false);
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("5");
                mainPage.fnClickSubmit();
                string PopUpMessage = "Please enter a first name";
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MainPage_Last_Name_Empty()
        {
            try
            {
                string firstName = "Jose";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("");
                mainPage.fnClickB();
                mainPage.fnClickC(false);
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("5");
                mainPage.fnClickSubmit();
                string PopUpMessage = "Please enter a last name";
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MainPage_Wrong_CheckBox_Selected()
        {
            try
            {
                string firstName = "Jose";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("");
                mainPage.fnClickB();
                mainPage.fnClickC();
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("5");
                mainPage.fnClickSubmit();
                string PopUpMessage = "The checkbox selection is not quite right";
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_1()
        {
            try
            {
                string firstName = "Jose";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("Novelo");
                mainPage.fnClickB();
                mainPage.fnClickC(false);
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("4");
                mainPage.fnClickSubmit();
                string PopUpMessage = "The dropdown selection is not quite right";
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_2()
        {
            try
            {
                string firstName = "Jose";
                mainPage.fnEnterFirstN(firstName);
                mainPage.fnEnterLastN("Novelo");
                mainPage.fnClickB();
                mainPage.fnClickC(false);
                mainPage.fnClickPlus();
                mainPage.fnClickP();
                mainPage.fnSelFirstDropdownOpt("5");
                mainPage.fnSelSecondDropdownOpt("5");
                mainPage.fnClickSubmit();
                string PopUpMessage = "A selection was made other than the default in select list 2";
                Assert.AreEqual(PopUpMessage, mainPage.fnReadPopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }








    }
}
