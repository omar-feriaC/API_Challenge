using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BaseFramework.WebPages
{
    public class MainPage : BaseTest
    {
        //public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        public static IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //LOCATORS
        readonly static string STR_FIRSTNAME_TXT = "//input[@name='_firstName']";
        readonly static string STR_LASTNAME_TXT = "//input[@name='_lastName']";
        readonly static string STR_B_CHK = "//input[@name='chk1']";
        readonly static string STR_C_CHK = "//input[@name='chk2']";
        readonly static string STR_PLUS_CHK = "//input[@name='chk3']";
        readonly static string STR_P_CHK = "//input[@name='chk4']";
        readonly static string STR_FIRST_DRP = "//div[@name='selOpt']//select[1]";
        readonly static string STR_SECOND_DRP = "//div[@name='noSel']//select[1]";
        readonly static string STR_SUBMIT_BTN = "//button[contains(text(), 'Submit')]";

        //OBJECTS
        private static IWebElement ObjFirstNameTxt => _driver.FindElement(By.XPath(STR_FIRSTNAME_TXT));
        private static IWebElement ObjLastNameTxt => _driver.FindElement(By.XPath(STR_LASTNAME_TXT));
        private static IWebElement ObjBChk => _driver.FindElement(By.XPath(STR_B_CHK));
        private static IWebElement ObjCChk => _driver.FindElement(By.XPath(STR_C_CHK));
        private static IWebElement ObjPlusChk => _driver.FindElement(By.XPath(STR_PLUS_CHK));
        private static IWebElement ObjPChk => _driver.FindElement(By.XPath(STR_P_CHK));
        private static IWebElement ObjFirstDrp => _driver.FindElement(By.XPath(STR_FIRST_DRP));
        private static IWebElement ObjSecondDrp => _driver.FindElement(By.XPath(STR_SECOND_DRP));
        private static IWebElement ObjSubmitBtn => _driver.FindElement(By.XPath(STR_SUBMIT_BTN));

        //METHODS
        public static IWebElement GetFirstName()
        {
            return ObjFirstNameTxt;
        }
        public static void EnterFirstName(string strFirstName)
        {
            ObjFirstNameTxt.Clear();
            ObjFirstNameTxt.SendKeys(strFirstName);
        }
        public static IWebElement GetLastName()
        {
            return ObjLastNameTxt;
        }
        public static void EnterLastName(string strLastName)
        {
            ObjLastNameTxt.Clear();
            ObjLastNameTxt.SendKeys(strLastName);
        }
        public static IWebElement GetCheckBoxB()
        {
            return ObjBChk;
        }
        public static void SelectCheckBoxB()
        {
            ObjBChk.Click();
        }
        public static IWebElement GetCheckBoxC()
        {
            return ObjCChk;
        }
        public static void SelectCheckBoxC()
        {
            ObjCChk.Click();
        }
        public static IWebElement GetCheckBoxPlus()
        {
            return ObjPlusChk;
        }
        public static void SelectCheckBoxPlus()
        {
            ObjPlusChk.Click();
        }
        public static IWebElement GetCheckBoxP()
        {
            return ObjPChk;
        }
        public static void SelectCheckBoxP()
        {
            ObjPChk.Click();
        }

        public static void ClickSubmitButton()
        {
            ObjSubmitBtn.Click();
        }

        public static IWebElement GetFirstDropdown()
        {
            return ObjFirstDrp;
        }
        public static void SelectFirstDropdown(string strOption)
        {
            var selectElement = new SelectElement(ObjFirstDrp);
            selectElement.SelectByText(strOption);
        }
        public static void SelectSecondDropdown(string strOption)
        {
            var selectElement = new SelectElement(ObjSecondDrp);
            selectElement.SelectByText(strOption);
        }
        public static void CleanCheckboxes()
        {
            if (GetCheckBoxB().Selected == true) { SelectCheckBoxB(); }
            if (GetCheckBoxC().Selected == true) { SelectCheckBoxC(); }
            if (GetCheckBoxPlus().Selected == true) { SelectCheckBoxPlus(); }
            if (GetCheckBoxP().Selected == true) { SelectCheckBoxP(); }
        }
        public static string GetAlertText()
        {
            return _driver.SwitchTo().Alert().Text;
        }
        public static void CloseAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }








    }
}
