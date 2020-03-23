using System;
using System.Configuration;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        public static IWebDriver driver;
        public MainPage objmainPage;
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("url");
        string expectedSuccessMessage = "Congratulations Saul! Everything was properly populated.";
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

        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            objmainPage.InsertFirstName("Saul");
            objmainPage.InsertLastName("Garcia");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("5");
            objmainPage.selectDropDown2("");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedSuccessMessage);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedSuccessMessage, messagefrompage);
        }

        [Test]
        public void Negative_First_Name_Empty()
        {
            objmainPage.InsertLastName("Garcia");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("5");
            objmainPage.selectDropDown2("");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage1);
            NUnit.Framework.Assert.AreEqual(expectedErrorMessage1, messagefrompage);
        }

        [Test]
        public void Negative_Last_Name_Empty()
        {
            objmainPage.InsertFirstName("Saul");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("5");
            objmainPage.selectDropDown2("");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage2);
            NUnit.Framework.Assert.AreEqual(expectedErrorMessage2, messagefrompage);
        }

        [Test]
        public void Negative_Wrong_Check_Box_Selected()
        {
            objmainPage.InsertFirstName("Saul");
            objmainPage.InsertLastName("Garcia");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxC();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("5");
            objmainPage.selectDropDown2("");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage3);
            NUnit.Framework.Assert.AreEqual(expectedErrorMessage3, messagefrompage);
        }

        [Test]
        public void Negative_Wrong_Dropdown_Selected_First()
        {
            objmainPage.InsertFirstName("Saul");
            objmainPage.InsertLastName("Garcia");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("4");
            objmainPage.selectDropDown2("");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage4);
            NUnit.Framework.Assert.AreEqual(expectedErrorMessage4, messagefrompage);
        }

        [Test]
        public void Negative_WrongOption_SecondDropdown()
        {
            objmainPage.InsertFirstName("Saul");
            objmainPage.InsertLastName("Garcia");
            objmainPage.clickCheckboxB();
            objmainPage.clickCheckboxPlus();
            objmainPage.clickCheckboxP();
            objmainPage.selectDropDown1("5");
            objmainPage.selectDropDown2("5");
            objmainPage.clickSubmitBtn();
            string messagefrompage = objmainPage.ConfirmationWindow(expectedErrorMessage5);
            NUnit.Framework.Assert.AreEqual(expectedErrorMessage5, messagefrompage);
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
