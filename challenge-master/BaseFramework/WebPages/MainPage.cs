using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class MainPage : BaseTest
    {
        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        //private static IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            //_driver = driver;
        }

        //locators
        readonly static string STR_FIRSTNAME_TXT = "_firstName";
        readonly static string STR_LASTNAME_TXT = "_lastName";
        readonly static string STR_B_CHK = "chk1"; 
        readonly static string STR_C_CHK = "chk2";
        readonly static string STR_PLUS_CHK = "chk3";
        readonly static string STR_P_CHK = "chk4";
        readonly static string STR_FIRST_DRP = "//div[@name='selOpt']//select[1]";
        readonly static string STR_SECOND_DRP = "//div[@name='noSel']//select[1]";
        readonly static string STR_SUBMIT_BTN = "//button[contains(text(), 'Submit')]";

        //web objects
        private static IWebElement ObjFirstNameTxt => driver.FindElement(By.Name(STR_FIRSTNAME_TXT));
        private static IWebElement ObjLastNameTxt => driver.FindElement(By.Name(STR_LASTNAME_TXT));
        private static IWebElement ObjBChk => driver.FindElement(By.Name(STR_B_CHK));
        private static IWebElement ObjCChk => driver.FindElement(By.Name(STR_C_CHK));
        private static IWebElement ObjPlusChk => driver.FindElement(By.Name(STR_PLUS_CHK));
        private static IWebElement ObjPChk => driver.FindElement(By.Name(STR_P_CHK));
        private static IWebElement ObjFirstDrp => driver.FindElement(By.XPath(STR_FIRST_DRP));
        private static IWebElement ObjSecondDrp => driver.FindElement(By.XPath(STR_SECOND_DRP));
        private static IWebElement ObjSubmitBtn => driver.FindElement(By.XPath(STR_SUBMIT_BTN));

        //methods
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
        public static IWebElement GetBCheckBox()
        {
            return ObjBChk;
        }
        public static void ClickBCheckBox()
        {
            ObjBChk.Click();
        }
        public static IWebElement GetCCheckBox()
        {
            return ObjCChk;
        }
        public static void ClickCCheckBox()
        {
            ObjCChk.Click();
        }
        public static IWebElement GetPlusCheckBox()
        {
            return ObjPlusChk;
        }
        public static void ClickPlusCheckBox()
        {
            ObjPlusChk.Click();
        }
        public static IWebElement GetPCheckBox()
        {
            return ObjPChk;
        }
        public static void ClickPCheckBox()
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
            if (GetBCheckBox().Selected == true) { ClickBCheckBox(); }
            if (GetCCheckBox().Selected == true) { ClickCCheckBox(); }
            if (GetPlusCheckBox().Selected == true) { ClickPlusCheckBox(); }
            if (GetPCheckBox().Selected == true) { ClickPCheckBox(); }
        }
        public static string GetAlertText()
        {
            return driver.SwitchTo().Alert().Text;
        }
    }
}
