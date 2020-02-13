using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        private IWebDriver _driver;
        private IWebElement objFirstName;
        private IWebElement objLastNAme;
        private IWebElement objCheckBox;
        private IWebElement objDropDownSelect;
        private IWebElement objDropDownNot;
        private IWebElement objSubmitButton;
        
        readonly static string strFirstName = "//input[@name='_firstName']";
        readonly static string strLastNAme = "//input[@name='_lastName']";
        readonly static string strCheckBox = "//input[@name='chk";
        readonly static string strDropDownSelect = "//div[@name='selOpt']//option[text()='";
        readonly static string strDropDownNot = "//div[@name='noSel']//option[text()='";
        readonly static string strSubmitButton = "//*[text()='Submit']";
        public string strMessage;
        public bool boolMessage;

        public MainPage(IWebDriver pdriver) 
        {
            _driver = pdriver;
        }

        public void setFirstName(string pValue) 
        {
            objFirstName = _driver.FindElement(By.XPath(strFirstName));
            objFirstName.Clear();
            objFirstName.SendKeys(pValue);
            
        }
        public void setLastNAme(string pValue)
        {
            objLastNAme = _driver.FindElement(By.XPath(strLastNAme));
            objLastNAme.Clear();
            objLastNAme.SendKeys(pValue);
            
        }

        public void setCheckBox(string pValue)
        {
            objCheckBox = _driver.FindElement(By.XPath(strCheckBox+ pValue + "']"));
            string tem = objCheckBox.GetAttribute("checked");
            if (tem is null) { objCheckBox.Click(); }
        }

        public void setCheckBoxFalse(string pValue)
        {
            objCheckBox = _driver.FindElement(By.XPath(strCheckBox + pValue + "']"));
            string tem = objCheckBox.GetAttribute("checked");
            if (tem != null) { objCheckBox.Click(); }
        }

        public void setDropDownSelect(string pValue)
        {
            objDropDownSelect = _driver.FindElement(By.XPath(strDropDownSelect + pValue + "']"));
            objDropDownSelect.Click();
            
        }
        public void setDropDownNot(string pValue)
        {
            objDropDownNot = _driver.FindElement(By.XPath(strDropDownNot + pValue + "']"));
            objDropDownNot.Click();
            
        }

        public void setSubmitButton()
        {
            objSubmitButton = _driver.FindElement(By.XPath(strSubmitButton));
            objSubmitButton.Click();
            
        }
        public void setMessage(string pValue)
        {
            strMessage = _driver.SwitchTo().Alert().Text;
            _driver.SwitchTo().Alert().Accept();
            if (strMessage == pValue) { boolMessage = true; }
            else { boolMessage= false; }
        }
    }
}
