using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;


namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        string strMyFirstName = "Hugo";
        string strMyLastName = "Vidal";
        public IWebDriver driver;
        public MainPage objMainPage;
        private static string strBrowserName = ConfigurationManager.AppSettings.Get("url");        
        [TestInitialize]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
            driver.Manage().Window.Maximize();
            objMainPage = new MainPage(driver);
            objMainPage.fnResetChecks();
        }
        [TestMethod] 
        public void P_Success()
        {
            string expectedSuccessMessage = "Congratulations " + strMyFirstName + "! Everything was properly populated.";
            objMainPage.fnInsertFirstName(strMyFirstName);
            objMainPage.fnInsertLastName(strMyLastName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("5");
            objMainPage.fnSelectDropDownDontSelect("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedSuccessMessage);
            Assert.AreEqual(expectedSuccessMessage, messagefrompage);
        }
        [TestMethod]
        public void N_FirstName_Empty()
        {
            string expectedErrorMessage1 = "Please enter a first name";
            objMainPage.fnInsertLastName(strMyLastName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("5");
            objMainPage.fnSelectDropDownDontSelect("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage1);
            Assert.AreEqual(expectedErrorMessage1, messagefrompage);
        }
        [TestMethod]
        public void N_LastName_Empty()
        {
            string expectedErrorMessage2 = "Please enter a last name";
            objMainPage.fnInsertFirstName(strMyFirstName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("5");
            objMainPage.fnSelectDropDownDontSelect("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage2);
            Assert.AreEqual(expectedErrorMessage2, messagefrompage);
        }
        [TestMethod]
        public void N_Wrong_CheckBox()
        {
            string expectedErrorMessage3 = "The checkbox selection is not quite right";
            objMainPage.fnInsertFirstName(strMyFirstName);
            objMainPage.fnInsertLastName(strMyLastName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_c();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("5");
            objMainPage.fnSelectDropDownDontSelect("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage3);
            Assert.AreEqual(expectedErrorMessage3, messagefrompage);
        }
        [TestMethod]
        public void N_Wrong_FirstDropdown()
        {
            string expectedErrorMessage4 = "The dropdown selection is not quite right";
            objMainPage.fnInsertFirstName(strMyFirstName);
            objMainPage.fnInsertLastName(strMyLastName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("4");
            objMainPage.fnSelectDropDownDontSelect("");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage4);
            Assert.AreEqual(expectedErrorMessage4, messagefrompage);
        }
        [TestMethod]
        public void N_Wrong_SecondDropdown()
        {
            string expectedErrorMessage5 = "A selection was made other than the default in select list 2";
            objMainPage.fnInsertFirstName(strMyFirstName);
            objMainPage.fnInsertLastName(strMyLastName);
            objMainPage.fnClickCheckbox_b();
            objMainPage.fnClickCheckbox_plus();
            objMainPage.fnClickCheckbox_p();
            objMainPage.fnSelectDropDownSelect("5");
            objMainPage.fnSelectDropDownDontSelect("5");
            objMainPage.fnClickSubmitButton();
            string messagefrompage = objMainPage.ConfirmationWindow(expectedErrorMessage5);
            Assert.AreEqual(expectedErrorMessage5, messagefrompage);
        }
        [TestCleanup]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
