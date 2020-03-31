using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Configuration;

namespace Challenge.Test
{
    [TestClass]
    
    public class Web_Tests
    {
        public IWebDriver mdriver;
        public MainPage objMainPage;
        private static string strBrowser = ConfigurationManager.AppSettings.Get("ZetaUrl");
        string pstrFname = "Jose";

        [TestInitialize]
        public void OpenBrowser()
        {
            mdriver = new ChromeDriver();
            mdriver.Url = strBrowser;
            mdriver.Manage().Window.Maximize();
            objMainPage = new MainPage(mdriver);
          
        }
        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            string expectedSuccessMessage = "Congratulations " + pstrFname + "! Everything was properly populated.";
            objMainPage.fnInputFirstName(pstrFname);
            objMainPage.fnInputLastName("Pasos");
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("5");
            objMainPage.fnSelectSecondDropDown("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedSuccessMessage);
            Assert.AreEqual(expectedSuccessMessage, messagefrompage);
        }

        [TestMethod]
        public void MainPage_Negative_FirstName_Empty()
        {
            //cleaning before test//
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();

            //Test//
            string expectedErrorMessage1 = "Please enter a first name";
            objMainPage.fnInputFirstName("");
            objMainPage.fnInputLastName("Pasos");
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("5");
            objMainPage.fnSelectSecondDropDown("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage1);
            Assert.AreEqual(expectedErrorMessage1, messagefrompage);
        }

        [TestMethod]
        public void MainPage_Negative_LastName_Empty()
        {
            //Cleaning before test//
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();

            //Test//
            string expectedErrorMessage2 = "Please enter a last name";
            objMainPage.fnInputFirstName(pstrFname);
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("5");
            objMainPage.fnSelectSecondDropDown("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage2);
            Assert.AreEqual(expectedErrorMessage2, messagefrompage);
        }
        [TestMethod]
        public void MainPage_Negative_WrongCheckbox_Selected()
        {
            //Cleaning before test//
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();

            //Test//
            string expectedErrorMessage3 = "The checkbox selection is not quite right";
            objMainPage.fnInputFirstName(pstrFname);
            objMainPage.fnInputFirstName("Pasos");
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickCCheckbox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("5");
            objMainPage.fnSelectSecondDropDown("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage3);
            Assert.AreEqual(expectedErrorMessage3, messagefrompage);
        }

        [TestMethod]
        public void MainPage_Negative_WrongDropdown_SelectedinFirst()
        {
            //Cleaning Before Test//
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickCCheckbox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();

            //Test//
            string expectedErrorMessage4 = "The dropdown selection is not quite right";
            objMainPage.fnInputFirstName(pstrFname);
            objMainPage.fnInputLastName("Pasos");
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("4");
            objMainPage.fnSelectSecondDropDown("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage4);
            Assert.AreEqual(expectedErrorMessage4, messagefrompage);
        }

        [TestMethod]
        public void MainPage_Negative_WrongDropdown_SelectedinSecond()
        {
            //cleaning before test//
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();

            //Test//
            string expectedErrorMessage5 = "A selection was made other than the default in select list 2";
            objMainPage.fnInputFirstName(pstrFname);
            objMainPage.fnInputLastName("Pasos");
            objMainPage.fnClickBCheckBox();
            objMainPage.fnClickPlusCheckbox();
            objMainPage.fnClickPCheckbox();
            objMainPage.fnSelectFirstDropDown("5");
            objMainPage.fnSelectSecondDropDown("5");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage5);
            Assert.AreEqual(expectedErrorMessage5, messagefrompage);
        }

        [TestCleanup]
        public void Close()
        {
            mdriver.Close();
            mdriver.Quit();
        }
    }
}
