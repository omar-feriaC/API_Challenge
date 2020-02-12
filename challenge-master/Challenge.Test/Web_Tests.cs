using BaseFramework.WebPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Challenge.Test
{

    public class Web_Tests
    {
        public IWebDriver driver;
        public MainPage mainPage = null;
        public static string url = "http://ztestqa.com/selenium/mainpage.html";
        public string firstName = "Carlos";
        public string lastName = "Paz";

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
                string expectedMessage = $"Congratulations {firstName}! Everything was properly populated.";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(firstName);
                mainPage.enterLastName(lastName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
                string expectedMessage = "Please enter a first name";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterLastName(lastName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
                string expectedMessage = "Please enter a last name";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(firstName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
                string expectedMessage = "The checkbox selection is not quite right";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(firstName);
                mainPage.enterLastName(lastName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickCCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
                string expectedMessage = "The dropdown selection is not quite right";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(firstName);
                mainPage.enterLastName(lastName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
                string expectedMessage = "A selection was made other than the default in select list 2";
                mainPage.clearFirstName();
                mainPage.clearLastName();
                mainPage.enterFirstName(firstName);
                mainPage.enterLastName(lastName);
                mainPage.clearButtons();
                mainPage.clickBCheckbox();
                mainPage.clickPCheckbox();
                mainPage.clickPlusCheckbox();
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
