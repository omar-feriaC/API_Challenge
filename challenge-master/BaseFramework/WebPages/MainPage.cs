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
        private static string FName = "";

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

        //Function to Clear all the Textboxes and Checkboxes in order to start every test with a page free of selections.
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

        //Function to enter the First Name.
        public static void fnEnterFName(string pFirstName)
        {
            FName = pFirstName;
            objFName.SendKeys(pFirstName);
        }

        //Function to enter the Last Name.
        public static void fnEnterLName(string pLastName)
        {
            objLName.SendKeys(pLastName);
        }

        //Function to select the desired Checkbox for every test case.
        public static void fnCheckboxes(bool pCbxB, bool pCbxC, bool pCbxPlus, bool pCbxP)
        {
            if (pCbxB) objCBXB.Click();
            if (pCbxC) objCBXC.Click();
            if (pCbxPlus) objCBXPLUS.Click();
            if (pCbxP) objCBXP.Click();
        }

        //Function to choose any option from the First Dropdown menu.
        public static void fnDDSelection(int i)
        {
            objDDSel.Click();
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(STR_DD_SEL_OPT_2)));
            objDDSel.SendKeys($"{i}");
            objDDSel.SendKeys(Keys.Enter);
        }

        //Function to choose any option from the second Dropdown menu.
        public static void fnDDNoSelection(int i)
        {
            objDDNoSel.Click();
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(STR_DD_NOSEL_OPT_2)));
            objDDNoSel.SendKeys($"{i}");
            objDDNoSel.SendKeys(Keys.Enter);
        }

        //Function to click on Submit button.
        public static void fnClickSubmit()
        {
            objBtnSubmit.Click();
        }

        //Function to Capture an Alert message, save it on a variable and print it in the Console.
        public static string fnAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            string AlertMessage = alert.Text;
            alert.Accept();
            Console.WriteLine("Message displayed: " + AlertMessage);
            return AlertMessage;
        }

        //Function to store the Alert Messages availables in order to compare and validate against the actual Message.
        public static string fnAlertMessages(int i)
        {
            List<string> Message = new List<string>() 
            {
                "Congratulations " + FName +"! Everything was properly populated.",
                "Please enter a first name",
                "Please enter a last name",
                "The checkbox selection is not quite right",
                "The dropdown selection is not quite right",
                "A selection was made other than the default in select list 2"};
            return Message[i].ToString();
        }
    }
}
