using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
//using BaseFramework.REST;
using System.Net;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        /*ATTRIBUTES*/
        public IWebDriver _driver;

        /*LOCATORS DESCRIPTION*/
        readonly static string INPUT_FIRSTNAME_TEXTFIELD = "//input[@id='_fNameInput']";
        readonly static string INPUT_LASTNAME_TEXTFIELD = "//input[@id='_lNameInput']";
        readonly static string INPUT_CHECKBOXB_TEXTFIELD = "//input[@id='DX3GY_CBX1']";
        readonly static string INPUT_CHECKBOXC_TEXTFIELD = "//input[@id='AGSRO_CBX2']";
        readonly static string INPUT_CHECKBOXPLUS_TEXTFIELD = "//input[@id='EZSMF_CBX3']";
        readonly static string INPUT_CHECKBOXP_TEXTFIELD = "//input[@id='VEX8W_CBX4']";
        readonly static string DROPDOWN_SELLOPT = "//div[@name='selOpt']/select";
        readonly static string DROPDOWN_NOSEL = "//div[@name='noSel']/select";
        readonly static string BUTTON_SUBMIT = "//button[text()='Submit']";

        /*CONSTRUCTOR*/
        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        /*OBJECT DEFINITION*/
        private IWebElement objFirstNameTextInput => _driver.FindElement(By.XPath(INPUT_FIRSTNAME_TEXTFIELD));
        private IWebElement objLasttNameTextInput => _driver.FindElement(By.XPath(INPUT_LASTNAME_TEXTFIELD));
        private IWebElement objBcheckBox => _driver.FindElement(By.XPath(INPUT_CHECKBOXB_TEXTFIELD));
        private IWebElement objCcheckBox => _driver.FindElement(By.XPath(INPUT_CHECKBOXC_TEXTFIELD));
        private IWebElement objPluscheckBox => _driver.FindElement(By.XPath(INPUT_CHECKBOXPLUS_TEXTFIELD));
        private IWebElement objPcheckBox => _driver.FindElement(By.XPath(INPUT_CHECKBOXP_TEXTFIELD));
        private IWebElement objSelOptDropDown => _driver.FindElement(By.XPath(DROPDOWN_SELLOPT));
        private IWebElement objNoSelDropDown => _driver.FindElement(By.XPath(DROPDOWN_NOSEL));
        private IWebElement objSubmitButton => _driver.FindElement(By.XPath(BUTTON_SUBMIT));

        /*METHODS/FUNCTIONS*/
        private IWebElement GetFirstNameText()
        {
            return objFirstNameTextInput;
        }
        private IWebElement GetLastNameText()
        {
            return objLasttNameTextInput;
        }
        private IWebElement getBcheckBox()
        {
            return objBcheckBox;
        }
        private IWebElement getCcheckBox()
        {
            return objCcheckBox;
        }
        private IWebElement GetPluscheckBox()
        {
            return objPluscheckBox;
        }
        private IWebElement GetPcheckBox()
        {
            return objPcheckBox;
        }
        private IWebElement GetSelOptDropDown()
        {
            return objSelOptDropDown;
        }
        private IWebElement GetNoSelDropDown()
        {
            return objNoSelDropDown;
        }
        private IWebElement GetSubmitButton()
        {
            return objSubmitButton;
        }

        public string fnEnterFirstName(string strFirstName)
        {
            
            objFirstNameTextInput.SendKeys(strFirstName);
            return strFirstName;
        }
        public void fnEnterLasttName(string strLastName)
        {

            objLasttNameTextInput.SendKeys(strLastName);
        }
        public void fnCheckBCheckBox()
        {
           objBcheckBox.Click();
        }
        public void fnCheckCcheckBox()
        {
            objCcheckBox.Click();
        }
        public void fnCheckPlusCheckBox()
        {
            objPluscheckBox.Click();
        }
        public void fnCheckPCheckBox()
        {
            objPcheckBox.Click();
        }
        public void fnSubmitButton()
        {
            objSubmitButton.Click();
        }

        public void fnSelectDropDownSelOpt(string option) { 
            var selectElement = new SelectElement(objSelOptDropDown); 
            selectElement.SelectByText(option); 
        }
        public void fnSelectDropDownNoSel(string option)
        {
            var selectElement = new SelectElement(objNoSelDropDown);
            selectElement.SelectByText(option);
        }
        public void fnClearAllFields()
        {
            objFirstNameTextInput.Clear();
            objLasttNameTextInput.Clear();
            if (objBcheckBox.Selected){
                objBcheckBox.Click();
            }
            if (objCcheckBox.Selected){
                objCcheckBox.Click();
            }
            if (objPluscheckBox.Selected){
                objPluscheckBox.Click();
            }
            if (objPcheckBox.Selected){
                objPcheckBox.Click();
            }
        }
        public string fnReadPopUp()
        {
            string strAlertText = _driver.SwitchTo().Alert().Text;
            _driver.SwitchTo().Alert().Accept();
            return strAlertText;
        }
        public string fnPositiveToVal(string strName)
        {
            String strToVal = "Congratulations " + strName + "! Everything was properly populated.";
            return strToVal;
        }

        public string fnNoFirstName()
        {
            String strNoFirstName = "Please enter a first name";
            return strNoFirstName;
        }
        public string fnNoLastName()
        {
            String strNoFirstName = "Please enter a last name";
            return strNoFirstName;
        }
        public string fnWrongCheckboxChecked()
        {
            String strWrongCheckBox = "The checkbox selection is not quite right";
            return strWrongCheckBox;
        }
        public string fnWronDropDownSelected()
        {
            String strWrongDropDownBox = "The dropdown selection is not quite right";
            return strWrongDropDownBox;
        }
        public string fnWronSecondDropDownSelected()
        {
            String strWrongSecondDropDownBox = "A selection was made other than the default in select list 2";
            return strWrongSecondDropDownBox;
        }
    }
}
