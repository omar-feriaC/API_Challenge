using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        public readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        private IWebDriver _objDriver;
       
        #region Page Objects
        //XPATHS
        readonly static string STR_FNAME_INPUT = "//input[@id='_fNameInput']";
        readonly static string STR_LNAME_INPUT = "//input[@id='_lNameInput']";
        readonly static string STR_CBX_1 = "//input[@id='DX3GY_CBX1']";
        readonly static string STR_CBX_2 = "//input[@id='AGSRO_CBX2']";
        readonly static string STR_CBX_3 = "//input[@id='EZSMF_CBX3']";
        readonly static string STR_CBX_4 = "//input[@id='VEX8W_CBX4']";
        readonly static string STR_DD_SEL = "//div[@name='selOpt']/select";
        readonly static string STR_DD_NOSEL = "//div[@name='noSel']/select";
        readonly static string STR_BTN_SUBMIT = "//button[text()='Submit']";
        
        public MainPage(IWebDriver driver)
        {
            _objDriver = driver;
        }
        //Page Objects
        private IWebElement objFirstName => _objDriver.FindElement(By.XPath(STR_FNAME_INPUT));
        private IWebElement objLastName => _objDriver.FindElement(By.XPath(STR_LNAME_INPUT));
        private IWebElement objChkbox1 => _objDriver.FindElement(By.XPath(STR_CBX_1));
        private IWebElement objChkbox2 => _objDriver.FindElement(By.XPath(STR_CBX_2));
        private IWebElement objChkbox3 => _objDriver.FindElement(By.XPath(STR_CBX_3));
        private IWebElement objChkbox4 => _objDriver.FindElement(By.XPath(STR_CBX_4));
        private IWebElement objSelectDropdown1 => _objDriver.FindElement(By.XPath(STR_DD_SEL));
        private IWebElement objSelectDropdown2 => _objDriver.FindElement(By.XPath(STR_DD_NOSEL));
        private IWebElement objButtonSubmit => _objDriver.FindElement(By.XPath(STR_BTN_SUBMIT));
        #endregion

        #region Functions
        //Clear All Check Boxes
        public void fnClearCheckboxes()
        {
            if (objChkbox1.Selected) objChkbox1.Click();
            if (objChkbox2.Selected) objChkbox2.Click();
            if (objChkbox3.Selected) objChkbox3.Click();
            if (objChkbox4.Selected) objChkbox4.Click();
        }

        //Add First Name
        private IWebElement InputFirstName()
        {
            return objFirstName;
        }
        public void fnInputFirstName(string _strFirstName)
        {
            objFirstName.Click();
            objFirstName.Clear();
            objFirstName.SendKeys(_strFirstName);
        }

        //Add Last Name
        private IWebElement InputLastName()
        {
            return objLastName;
        }

        public void fnInputLastName(string _strLastName)
        {
            objLastName.Click();
            objLastName.Clear();
            objLastName.SendKeys(_strLastName);
        }

        //Tic Checkbox1 (B)
        private IWebElement TicCheckbox1()
        {
            return objChkbox1;
        }

        public void fnTicCheckbox1()
        {
            objChkbox1.Click();
        }

        //Tic Checkbox2 (C)
        private IWebElement TicCheckbox2()
        {
            return objChkbox2;
        }

        public void fnTicCheckbox2()
        {
            objChkbox2.Click();
        }

        //Tic Checkbox3 (+)
        private IWebElement TicCheckbox3()
        {
            return objChkbox3;
        }

        public void fnTicCheckbox3()
        {
            objChkbox3.Click();
        }

        //Tic Checkbox4 (P)
        private IWebElement TicCheckbox4()
        {
            return objChkbox4;
        }

        public void fnTicCheckbox4()
        {
            objChkbox4.Click();
        }

        //Select Dropdown 1
        private IWebElement SelectDropdown1()
        {
            return objSelectDropdown1;
        }

        public void fnSelectDropdown1(string optSelect1)
        {
            objSelectDropdown1.Click();
            objSelectDropdown1.SendKeys(optSelect1);
            objSelectDropdown1.SendKeys(Keys.Enter);
        }

        //Select Dropdown 2
        private IWebElement SelectDropdown2()
        {
            return objSelectDropdown2;
        }

        public void fnSelectDropdown2(string optSelect2)
        {
            objSelectDropdown2.Click();
            objSelectDropdown2.SendKeys(optSelect2);
            objSelectDropdown2.SendKeys(Keys.Enter);
        }

        //Click Submit Button
        private IWebElement ClickSubmitButton()
        {
            return objButtonSubmit;
        }

        public void fnClickSubmitButton()
        {
            objButtonSubmit.Click();
        }
        #endregion
    }
}
