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
        /*ATTRIBUTES*/
        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        private IWebDriver driver;
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
        readonly static string STR_DD_SEL_OPT_1 = "//div[@name='selOpt']/select/option[text()='1']";
        readonly static string STR_DD_SEL_OPT_2 = "//div[@name='selOpt']/select/option[text()='2']";
        readonly static string STR_DD_SEL_OPT_3 = "//div[@name='selOpt']/select/option[text()='3']";
        readonly static string STR_DD_SEL_OPT_4 = "//div[@name='selOpt']/select/option[text()='4']";
        readonly static string STR_DD_SEL_OPT_5 = "//div[@name='selOpt']/select/option[text()='5']";
        readonly static string STR_DD_SEL_OPT_6 = "//div[@name='selOpt']/select/option[text()='6']";
        readonly static string STR_DD_NOSEL = "//div[@name='noSel']/select";
        readonly static string STR_BTN_SUBMIT = "//button[text()='Submit']";

        /*CONSTRUCTOR*/
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            _driverWait = new WebDriverWait(_objDriver, new TimeSpan(0, 0, 40));
        }

        SelectElement oSelect = new SelectElement(_objDriver.FindElement(By.Id("selectFilterbyUser")));
        
    }
}
