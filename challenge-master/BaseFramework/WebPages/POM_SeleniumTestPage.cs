using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseFramework.WebPages
{
    public class POM_SeleniumTestPage : MainPage
    {
        /*DRIVER REFERENCE*/
        private static IWebDriver _objDriver;
        public static WebDriverWait _objDriverWait;

        public POM_SeleniumTestPage (IWebDriver objDriver)
        {
            _objDriver = objDriver;
        }

        /*ELEMENT LOCATORS*/
        private static readonly string STR_FIRSTNAME_TEXTFIELD_Id = "_fNameInput";
        private static readonly string STR_LASTNAME_TEXTFIELD_Id = "_lNameInput";
        private static readonly string STR_CHECK1_CHECKFIELD_Name = "//input[@name='chk1']";
        private static readonly string STR_CHECK2_CHECKFIELD_Name = "chk2";
        private static readonly string STR_CHECK3_CHECKFIELD_Name = "chk3";
        private static readonly string STR_CHECK4_CHECKFIELD_Name = "chk4";
        private static readonly string STR_DROPDOWN1_DROPFIELD_XPath = "//div[@name='selOpt']//option";//*********List for options
        private static readonly string STR_DROPDOWN2_DROPFIELD_Xpath = "//div[@name='noSel']//option";//*********List
        private static readonly string STR_BTNSUBMIT_BTNFIELD_XPath = "//button[text()='Submit']";

        /*PAGE ELEMENT OBJECTS*/
        private static IWebElement objFirstNameText => _objDriver.FindElement(By.Id(STR_FIRSTNAME_TEXTFIELD_Id));
        private static IWebElement objLastNameText => _objDriver.FindElement(By.Id(STR_LASTNAME_TEXTFIELD_Id));
        private static IWebElement objCheckBoxB1CHK => _objDriver.FindElement(By.XPath(STR_CHECK1_CHECKFIELD_Name));
        private static IWebElement objCheckBoxC2CHK => _objDriver.FindElement(By.Name(STR_CHECK2_CHECKFIELD_Name));
        private static IWebElement objCheckBoxPlus3CHK => _objDriver.FindElement(By.Name(STR_CHECK3_CHECKFIELD_Name));
        private static IWebElement objCheckBoxP4CHK => _objDriver.FindElement(By.Name(STR_CHECK4_CHECKFIELD_Name));
        private static IList<IWebElement> objDropDown1DRP => _objDriver.FindElements(By.XPath(STR_DROPDOWN1_DROPFIELD_XPath));
        private static IList<IWebElement> objDropDown2DRP => _objDriver.FindElements(By.XPath(STR_DROPDOWN2_DROPFIELD_Xpath));
        private static IWebElement objSubmitBTN => _objDriver.FindElement(By.XPath(STR_BTNSUBMIT_BTNFIELD_XPath));

        /*GET ELEMENT METHODS*/
        public IWebElement GetFirstNameField()
        {
            return objFirstNameText;
        }

        public IWebElement GetLastNameField()
        {
            return objLastNameText;
        }

        public IWebElement GetCheckB1Field()
        {
            return objCheckBoxB1CHK;
        }

        public IWebElement GetCheckC2Field()
        {
            return objCheckBoxC2CHK;
        }

        public IWebElement GetCheckPlus3Field()
        {
            return objCheckBoxPlus3CHK;
        }

        public IWebElement GetCheckP4Field()
        {
            return objCheckBoxP4CHK;
        }

        public IList<IWebElement> GetDropDown1Field()
        {
            return objDropDown1DRP;
        }

        public IList<IWebElement> GetDropDown2Field()
        {
            return objDropDown2DRP;
        }

        public IWebElement GetSubmitButton()
        {
            return objSubmitBTN;
        }

        /*PAGE ELEMENT ACTIONS*/
        public void fnChechBoxToFalse()
        {
            if (objCheckBoxB1CHK.Selected)
                objCheckBoxB1CHK.Click();

            if (objCheckBoxC2CHK.Selected)
                objCheckBoxC2CHK.Click();

            if (objCheckBoxPlus3CHK.Selected)
                objCheckBoxPlus3CHK.Click();

            if (objCheckBoxP4CHK.Selected)
                objCheckBoxP4CHK.Click();

            objFirstNameText.Clear();
            objLastNameText.Clear();

        }

        public void fnScenarioPositive1 (string psrtFName, string pstrLName)
        {
            string strPopUpText;
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();
            
            objFirstNameText.SendKeys(psrtFName);
            objLastNameText.SendKeys(pstrLName);
            objCheckBoxB1CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();

            objDropDown1DRP.ElementAt(4).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());

        }

        public void fnScenarioFNameEmprty(string pstrfName)
        {
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();

            objLastNameText.SendKeys(pstrfName);
            objCheckBoxB1CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();
            objDropDown1DRP.ElementAt(4).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());

        }

        public void fnScenarioLNameEmprty(string pstrLName)
        {
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();

            objFirstNameText.SendKeys(pstrLName);
            objCheckBoxB1CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();
            objDropDown1DRP.ElementAt(4).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());

        }

        public void fnScenarioWrongCHK(string pstrFname, string pstrLName)
        {
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();

            objFirstNameText.SendKeys(pstrFname);
            objLastNameText.SendKeys(pstrLName);
            objCheckBoxB1CHK.Click();
            objCheckBoxC2CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();
            objDropDown1DRP.ElementAt(4).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());

        }

        public void fnScenarioWrongOptionDRP1(string pstrFname, string pstrLName)
        {
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();

            objFirstNameText.SendKeys(pstrFname);
            objLastNameText.SendKeys(pstrLName);
            objCheckBoxB1CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();
            objDropDown1DRP.ElementAt(3).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void fnScenarioWrongOptionDRP2(string pstrFname, string pstrLName)
        {
            _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));
            this.fnChechBoxToFalse();

            objFirstNameText.SendKeys(pstrFname);
            objLastNameText.SendKeys(pstrLName);
            objCheckBoxB1CHK.Click();
            objCheckBoxPlus3CHK.Click();
            objCheckBoxP4CHK.Click();
            objDropDown1DRP.ElementAt(4).Click();
            objDropDown2DRP.ElementAt(5).Click();
            objSubmitBTN.Submit();
            _objDriverWait.Until(ExpectedConditions.AlertIsPresent());

        }
    }
}
