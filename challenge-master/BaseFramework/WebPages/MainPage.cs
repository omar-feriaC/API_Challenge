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
    public class MainPage
    {
        public readonly string url = "http://ztestqa.com/selenium/mainpage.html";

        public static WebDriverWait _driverWait;
        private IWebDriver _driver;


        readonly static string STR_FIRSTNAME_TXT = "//input[@name='_firstName']";
        readonly static string STR_LASTNAME_TXT = "//input[@name='_lastName']";
        readonly static string STR_B_CHECKBTN = "//input[@name='chk1']";
        readonly static string STR_C_CHECKBTN = "//input[@name='chk2']";
        readonly static string STR_PLUS_CHECKBTN = "//input[@name='chk3']";
        readonly static string STR_P_CHECKBTN = "//input[@name='chk4']";
        static string STR_SELECT_DROPDOWN = "//div[@name = 'selOpt']/select";
        static string STR_DONTSELECT_DROPDOWN = $"//div[@name = 'noSel']/select";
        readonly static string STR_SUBMIT_BTN = "//*[text()='Submit']";

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, new TimeSpan(0, 0, 40));
        }

        private IWebElement objFirstName => _driver.FindElement(By.XPath(STR_FIRSTNAME_TXT));
        private IWebElement objLastName => _driver.FindElement(By.XPath(STR_LASTNAME_TXT));
        private IWebElement objBCheckBtn => _driver.FindElement(By.XPath(STR_B_CHECKBTN));
        private IWebElement objCCheckBtn => _driver.FindElement(By.XPath(STR_C_CHECKBTN));
        private IWebElement objPlusCheckBtn => _driver.FindElement(By.XPath(STR_PLUS_CHECKBTN));
        private IWebElement objPCheckBtn => _driver.FindElement(By.XPath(STR_P_CHECKBTN));
        private IWebElement objSelectDropdwn => _driver.FindElement(By.XPath(STR_SELECT_DROPDOWN));
        private IWebElement objDontSelectDropdwn => _driver.FindElement(By.XPath(STR_DONTSELECT_DROPDOWN));
        private IWebElement objSubmitBtn => _driver.FindElement(By.XPath(STR_SUBMIT_BTN));

        

        //Methods

        /* Add First Name */

        private IWebElement AddFirstName()
        {
            return objFirstName;
        }

        public void fnAddFirstName(string pstrFirstNameTxt)
        {
            objFirstName.Click();
            objFirstName.Clear();
            objFirstName.SendKeys(pstrFirstNameTxt);
        }

        /* Add Last Name */

        private IWebElement AddLastName()
        {
            return objLastName;
        }

        public void fnAddLastName(string pstrLastNameTxt)
        {
            objLastName.Click();
            objLastName.Clear();
            objLastName.SendKeys(pstrLastNameTxt);
        }

        /* Clear Check box */
        public void fnClearCheckBox()

        { 
            if (objBCheckBtn.Selected) objBCheckBtn.Click();
            if (objCCheckBtn.Selected) objCCheckBtn.Click();
            if (objPlusCheckBtn.Selected) objPlusCheckBtn.Click();
            if (objPCheckBtn.Selected) objPCheckBtn.Click();

        }

/* Select check Box B */

        private IWebElement ClickCheckbtnB()
        {
            return objBCheckBtn;
        }

        public void fnClickCheckbtnB()
        {
            objBCheckBtn.Click();
        }

        /* Select check Box C */

        private IWebElement ClickCheckbtnC()
        {
            return objCCheckBtn;
        }

        public void fnClickCheckbtnC()
        {
            objCCheckBtn.Click();
        }

        /* Select check Box + Plus */

        private IWebElement ClickCheckbtnPlus()
        {
            return objPlusCheckBtn;
        }

        public void fnClickCheckbtnPlus()
        {
            objPlusCheckBtn.Click();
        }

        /* Select check Box P */

        private IWebElement ClickCheckbtnP()
        {
            return objPCheckBtn;
        }

        public void fnClickCheckbtnP()
        {
            objPCheckBtn.Click();
        }

        /* Select Dropdown */

        private IWebElement SelectDropdown()
        {
            return objSelectDropdwn;
        }

        public void fnSelectDropdown(string optSelect)
        {
            objSelectDropdwn.Click();
            objSelectDropdwn.SendKeys(optSelect);
            objSelectDropdwn.SendKeys(Keys.Enter);
        }

        /* No Select Dropdown */

        private IWebElement NoSelectDropdown()
        {
            return objDontSelectDropdwn;
        }

        public void fnNoSelectDropdown(string optNoSelect)
        {
            objDontSelectDropdwn.Click();
            objDontSelectDropdwn.SendKeys(optNoSelect);
            objDontSelectDropdwn.SendKeys(Keys.Enter);
        }

        /* Click in Submit */

        private IWebElement ClickSubmitBtn()
        {
            return objSubmitBtn;
        }

        public void fnClickSubmitBtn()
        {
            objSubmitBtn.Click();
        }

    }
}
