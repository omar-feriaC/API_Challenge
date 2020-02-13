﻿using BaseFramework.WebPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;


namespace Challenge.Test
{
    public class Web_Tests

    {
        public IWebDriver driver;
        public MainPage objmainPage;
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("url");
        string expectedSuccessMessage = "Congratulations Luis! Everything was properly populated.";
        string expectedErrorMessage1 = "Please enter a first name";
        string expectedErrorMessage2 = "Please enter a last name";
        string expectedErrorMessage3 = "The checkbox selection is not quite right";
        string expectedErrorMessage4 = "The dropdown selection is not quite right";
        string expectedErrorMessage5 = "A selection was made other than the default in select list 2";

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
            driver.Manage().Window.Maximize();
            objmainPage = new MainPage(driver);
            objmainPage.ResetCheckBoxes();
        }

        [Test]
        public void MainPage_HappyPath()
        {


                objmainPage.InsertFirstName("Luis");
                objmainPage.InsertLastName("Esperon");
                objmainPage.clickBCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("5");
                objmainPage.selectDropDownOption2("");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedSuccessMessage);
                Assert.AreEqual(expectedSuccessMessage, messagefrompage);
            
        }

        [Test]
        public void Negative_FirstNameEmpty()
        {
           
              
                objmainPage.InsertLastName("Esperon");
                objmainPage.clickBCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("5");
                objmainPage.selectDropDownOption2("");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage1);
                Assert.AreEqual(expectedErrorMessage1, messagefrompage);
            
           
        }

        [Test]
        public void Negative_LastNameEmpty()
        {
               
                objmainPage.InsertFirstName("Luis");
                objmainPage.clickBCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("5");
                objmainPage.selectDropDownOption2("");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage2);
                Assert.AreEqual(expectedErrorMessage2, messagefrompage);
            
           
        }

        [Test]
        public void Negative_WrongCheckBox()
        {
                
                objmainPage.InsertFirstName("Luis");
                objmainPage.InsertLastName("Esperon");
                objmainPage.clickBCheckbox();
                objmainPage.clickCCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("5");
                objmainPage.selectDropDownOption2("");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage3);
                Assert.AreEqual(expectedErrorMessage3, messagefrompage);
            
        }

        [Test]
        public void Negative_WrongOption_FirstDropdown()
        {
            
               
                objmainPage.InsertFirstName("Luis");
                objmainPage.InsertLastName("Esperon");
                objmainPage.clickBCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("4");
                objmainPage.selectDropDownOption2("");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage4);
                Assert.AreEqual(expectedErrorMessage4, messagefrompage);
           
        }

        [Test]
        public void Negative_WrongOption_SecondDropdown()
        {
                
                objmainPage.InsertFirstName("Luis");
                objmainPage.InsertLastName("Esperon");
                objmainPage.clickBCheckbox();
                objmainPage.clickPlusCheckbox();
                objmainPage.clickPCheckbox();
                objmainPage.selectDropDownOption1("5");
                objmainPage.selectDropDownOption2("5");
                objmainPage.clickSubmitButton();
                string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage5);
                Assert.AreEqual(expectedErrorMessage5, messagefrompage);
            
            
        }

        [TearDown]
        public void Close()
        {
                   
           driver.Close();
           driver.Quit();
        }
    }
}
