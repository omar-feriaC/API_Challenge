using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace BaseFramework.WebPages
{
    public class MainPage : BaseTest
    {
        /*ATTRIBUTES*/
        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        public static WebDriverWait _driverWait;
        private static IWebDriver _objDriver;

        /*LOCATORS DESCRIPTION*/

        readonly static string STR_FNAME_INPUT = "//input[@id='_fNameInput']";
        readonly static string STR_LNAME_INPUT = "//input[@id='_lNameInput']";
        readonly static string STR_CHKBX_B = "//input[@id='DX3GY_CBX1']";
        readonly static string STR_CHKBX_C = "//input[@id='AGSRO_CBX2']";
        readonly static string STR_CHKBX_PLUS = "//input[@id='EZSMF_CBX3']";
        readonly static string STR_CHKBX_P = "//input[@id='VEX8W_CBX4']";
        readonly static string STR_DD_SEL = "//div[@name='selOpt']/select";
        readonly static string STR_DD_SEL_OPT_2 = "//div[@name='selOpt']/select/option[@value='SEL_AGSRO']";
        readonly static string STR_DD_NOSEL = "//div[@name='noSel']/select";
        readonly static string STR_DD_NOSEL_OPT_2 = "//div[@name='noSel']/select/option[@value='SEL_2']";
        readonly static string STR_BTN_SUBMIT = "//button[text()='Submit']";

        /*CONSTRUCTOR*/
        public MainPage(IWebDriver pobjdriver)
        {
            _objDriver = pobjdriver;
            _driverWait = new WebDriverWait(_objDriver, new TimeSpan(0, 0, 40));
        }

        /*OBJECT DEFINITION*/
        private static IWebElement objFName => _objDriver.FindElement(By.XPath(STR_FNAME_INPUT));
        private static IWebElement objLName => _objDriver.FindElement(By.XPath(STR_LNAME_INPUT));
        private static IWebElement objCBXB => _objDriver.FindElement(By.XPath(STR_CHKBX_B));
        private static IWebElement objCBXC => _objDriver.FindElement(By.XPath(STR_CHKBX_C));
        private static IWebElement objCBXPLUS => _objDriver.FindElement(By.XPath(STR_CHKBX_PLUS));
        private static IWebElement objCBXP => _objDriver.FindElement(By.XPath(STR_CHKBX_P));
        private static IWebElement objDDSel => _objDriver.FindElement(By.XPath(STR_DD_SEL));
        private static IWebElement objDDNoSel => _objDriver.FindElement(By.XPath(STR_DD_NOSEL));
        private static IWebElement objBtnSubmit => _objDriver.FindElement(By.XPath(STR_BTN_SUBMIT));

        /*METHODS/FUNCTIONS*/

        //
        private IWebElement GetClearElements()
        {
            return objFName;
            
        }

        public static void fnClearAll()
        {
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(STR_FNAME_INPUT)));
            objFName.Clear();
            objLName.Clear();
            if (objCBXB.Selected) objCBXB.Click();
            if (objCBXC.Selected) objCBXC.Click();
            if (objCBXPLUS.Selected) objCBXPLUS.Click();
            if (objCBXP.Selected) objCBXP.Click();
        }

        public static void fnEnterFName(string pFirstName)
        {
            objFName.SendKeys(pFirstName);
        }

        private IWebElement GetLName()
        {
            return objLName;
        }

        public static void fnEnterLName(string pLastName)
        {
            objLName.SendKeys(pLastName);
        }

        public static void fnCheckboxes(bool pCbxB, bool pCbxC, bool pCbxPlus, bool pCbxP)
        {
            if (pCbxB) objCBXB.Click();
            if (pCbxC) objCBXC.Click();
            if (pCbxPlus) objCBXPLUS.Click();
            if (pCbxP) objCBXP.Click();
        }

        public static void fnDDSelection(int i)
        {
            objDDSel.Click();
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(STR_DD_SEL_OPT_2)));
            objDDSel.SendKeys($"{i}");
            objDDSel.SendKeys(Keys.Enter);
        }

        public static void fnDDNoSelection(int i)
        {
            objDDNoSel.Click();
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(STR_DD_NOSEL_OPT_2)));
            objDDNoSel.SendKeys($"{i}");
            objDDNoSel.SendKeys(Keys.Enter);
        }

        public static void fnClickSubmit()
        {
            objBtnSubmit.Click();
        }

        public static string fnAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            string AlertMessage = alert.Text;
            alert.Accept();
            Console.WriteLine("Message displayed: " + AlertMessage);
            return AlertMessage;
        }
    }
}
