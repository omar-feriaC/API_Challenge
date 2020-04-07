using System;
using System.Threading;
using BaseFramework.WebPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;


namespace Challenge.Tests
{

    public class Web_Tests
    {
        public IWebDriver driver;
        public MainPage mainPage = null;
        public static string url = "http://ztestqa.com/selenium/mainpage.html";
        public string first_Name = "Alfonso";
        public string last_Name = "Medina";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = url;
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(driver);
        }

        [Test]
        public void MainPage_Positive()
        {
            try
            {
                string expectedMessage = $"Congratulations {first_Name}! Everything was properly populated.";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(first_Name);
                mainPage.enterLastName(last_Name);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("5");
                mainPage.selectDropDownOption2("");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void MainPage_Negative_First_Name_Empty()
        {
            try
            {
                string expectedMessage = "Please enter your first name";
                mainPage.clearFirstName();
                mainPage.enterFirstName(first_Name);
                mainPage.clearLastName();
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("5");
                mainPage.selectDropDownOption2("");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void MainPage_Negative_Last_Name_Empty()
        {
            try
            {
                string expectedMessage = "Please enter your last name";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterLastName(last_Name);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("5");
                mainPage.selectDropDownOption2("");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void MainPage_Negative_Wrong_Check_Box_Selected()
        {
            try
            {
                string expectedMessage = "The checkbox selection is not appropiate";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(first_Name);
                mainPage.enterLastName(last_Name);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickCCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("5");
                mainPage.selectDropDownOption2("");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void MainPage_Negative_Wrong_First_Dropdown_Selected()
        {
            try
            {
                string expectedMessage = "The dropdown selection is not appropiate";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(first_Name);
                mainPage.enterLastName(last_Name);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("4");
                mainPage.selectDropDownOption2("");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void MainPage_Negative_Wrong_Second_Dropdown_Selected()
        {
            try
            {
                string expectedMessage = "A selection was made different than default in the select list 2";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(first_Name);
                mainPage.enterLastName(last_Name);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPlusCheckbox();
                mainPage.clickPCheckbox();
                mainPage.selectDropDownOption1("5");
                mainPage.selectDropDownOption2("5");
                mainPage.clickSubmitButton();
                string message = mainPage.Alert(expectedMessage);
                Assert.AreEqual(expectedMessage, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}