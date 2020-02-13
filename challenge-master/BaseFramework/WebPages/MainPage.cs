using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        /*ATTRIBUTES*/
        public static WebDriverWait _driverWait;

        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        private static IWebDriver myDriver { get; set; }

        /*LOCATORS DESCRIPTION LOGIN*/
        readonly static string INP_FIRST_NAME = "//input[@id ='_fNameInput']";
        readonly static string INP_LAST_NAME = "//input[@id ='_lNameInput']";
        readonly static string CBX_ALL = "//div[@name='cbxBP']//input";
        readonly static string CHB_B = "//input[@name='chk1']";
        readonly static string CHB_C = "//input[@name='chk2']";
        readonly static string CHB_PLUS = "//input[@name='chk3']";
        readonly static string CHB_P = "//input[@name='chk4']";
        readonly static string DRDW1 = "//div[@name='selOpt']//option";
        readonly static string DRDW2 = "//div[@name='noSel']//select";
        readonly static string BTN_SUBMIT = "//button[text()='Submit']";

        /*CONSTRUCTOR*/
        public MainPage(IWebDriver driver)
        {
            myDriver = driver;
            _driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
        }

        /*OBJECT DEFINITION*/
        private static IWebElement objInputFirstName => myDriver.FindElement(By.XPath(INP_FIRST_NAME));
        private static IWebElement objInputLastName => myDriver.FindElement(By.XPath(INP_LAST_NAME));
        private static List<IWebElement> listCheckboxes => myDriver.FindElements(By.XPath(CBX_ALL)).ToList<IWebElement>();
        private static IWebElement objChbB => myDriver.FindElement(By.XPath(CHB_B));
        private static IWebElement objChbC => myDriver.FindElement(By.XPath(CHB_C));
        private static IWebElement objChbPlus => myDriver.FindElement(By.XPath(CHB_PLUS));
        private static IWebElement objChbP => myDriver.FindElement(By.XPath(CHB_P));
        private static List<IWebElement> listDropdown1 => myDriver.FindElements(By.XPath(DRDW1)).ToList<IWebElement>();
        private static List<IWebElement> listDropdown2 => myDriver.FindElements(By.XPath(DRDW2)).ToList<IWebElement>();
        private static IWebElement objSubmitButton => myDriver.FindElement(By.XPath(BTN_SUBMIT));
        //private static IWebElement
        //GETTERS
        public static IWebElement GetInputFirstName()
        {
            return objInputFirstName;
        }
        public static IWebElement GetInputLastName()
        {
            return objInputLastName;
        }
        public static List<IWebElement> GetChecboxes()
        {
            return listCheckboxes;
        }
        public static IWebElement GetCheckboxB()
        {
            return objChbB;
        }
        public static IWebElement GetCheckboxC()
        {
            return objChbC;
        }
        public static IWebElement GetCheckboxPlus()
        {
            return objChbPlus;
        }
        public static IWebElement GetCheckboxP()
        {
            return objChbP;
        }

        public static List<IWebElement> GetDropdown1()
        {
            return listDropdown1;
        }
        public static List<IWebElement> GetDropdown2()
        {
            return listDropdown2;
        }
        public static IWebElement GetSubmitButton()
        {
            return objSubmitButton;
        }
        /*METHODS/FUNCTIONS*/
        public static void FnClickIWebElement(IWebElement pIWebElement)
        {
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(pIWebElement));
            pIWebElement.Click();
        }
        public static void FnSendkeyAndClear(IWebElement pIWebElement,string pstrString)
        {
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(pIWebElement));
            pIWebElement.Clear();
            pIWebElement.SendKeys(pstrString);
        }
    }
}
