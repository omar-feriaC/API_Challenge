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
        //private IWebDriver _pobjdriver;
        public static WebDriverWait _driverWait; //= new WebDriverWait(_objDriver, new TimeSpan(0, 0, 40));
        private static IWebDriver _objDriver;

        /*LOCATORS DESCRIPTION*/

        readonly static string STR_FNAME_INPUT = "//input[@id='_fNameInput']";
        readonly static string STR_LNAME_INPUT = "//input[@id='_lNameInput']";
        readonly static string STR_CHKBX_B = "//input[@id='DX3GY_CBX1']";
        readonly static string STR_CHKBX_C = "//input[@id='AGSRO_CBX2']";
        readonly static string STR_CHKBX_PLUS = "//input[@id='EZSMF_CBX3']";
        readonly static string STR_CHKBX_P = "//input[@id='VEX8W_CBX4']";
        readonly static string STR_DD_SEL = "//div[@name='selOpt']/select";
        readonly static string STR_DD_SEL_OPT_1 = "//div[@name='selOpt']/select/option[@value='SEL_DX3GY']";
        readonly static string STR_DD_SEL_OPT_2 = "//div[@name='selOpt']/select/option[@value='SEL_AGSRO']";
        readonly static string STR_DD_SEL_OPT_3 = "//div[@name='selOpt']/select/option[@value='SEL_EZSMF']";
        readonly static string STR_DD_SEL_OPT_4 = "//div[@name='selOpt']/select/option[@value='SEL_VEX8W']";
        readonly static string STR_DD_SEL_OPT_5 = "//div[@name='selOpt']/select/option[@value='SEL_KSLUH']";
        readonly static string STR_DD_SEL_OPT_6 = "//div[@name='selOpt']/select/option[@value='SEL_4U3QU']";
        readonly static string STR_DD_NOSEL = "//div[@name='noSel']/select";
        readonly static string STR_DD_NOSEL_OPT_0 = "//div[@name='noSel']/select/option[@value='empty']";
        readonly static string STR_DD_NOSEL_OPT_1 = "//div[@name='noSel']/select/option[@value='SEL_1']";
        readonly static string STR_DD_NOSEL_OPT_2 = "//div[@name='noSel']/select/option[@value='SEL_2']";
        readonly static string STR_DD_NOSEL_OPT_3 = "//div[@name='noSel']/select/option[@value='SEL_3']";
        readonly static string STR_DD_NOSEL_OPT_4 = "//div[@name='noSel']/select/option[@value='SEL_4']";
        readonly static string STR_DD_NOSEL_OPT_5 = "//div[@name='noSel']/select/option[@value='SEL_5']";
        readonly static string STR_DD_NOSEL_OPT_6 = "//div[@name='noSel']/select/option[@value='SEL_6']";
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
        private static IWebElement objDDSel1 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_1));
        private static IWebElement objDDSel2 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_2));
        private static IWebElement objDDSel3 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_3));
        private static IWebElement objDDSel4 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_4));
        private static IWebElement objDDSel5 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_5));
        private static IWebElement objDDSel6 => _objDriver.FindElement(By.XPath(STR_DD_SEL_OPT_6));
        private static IWebElement objDDNoSel => _objDriver.FindElement(By.XPath(STR_DD_NOSEL));
        private static IWebElement objDDNoSel0 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_0));
        private static IWebElement objDDNoSel1 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_1));
        private static IWebElement objDDNoSel2 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_2));
        private static IWebElement objDDNoSel3 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_3));
        private static IWebElement objDDNoSel4 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_4));
        private static IWebElement objDDNoSel5 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_5));
        private static IWebElement objDDNoSel6 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL_OPT_6));
        private static IWebElement objBtnSubmit => _objDriver.FindElement(By.XPath(STR_BTN_SUBMIT));

        /*METHODS/FUNCTIONS*/

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





    }
}
