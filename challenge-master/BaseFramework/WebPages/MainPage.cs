using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        /*ATTRIBUTES*/
        //public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        public static WebDriverWait wait;
        private IWebDriver _driver;

        /*LOCATORS*/
        readonly static string STR_FIRSTNAME_TXT = "//input[@id='_fNameInput']";
        readonly static string STR_LASTNAME_TXT = "//input[@id='_lNameInput']";
        readonly static string STR_B_BTN = "//input[@id='DX3GY_CBX1']";
        readonly static string STR_C_BTN = "//input[@id='AGSRO_CBX2']";
        readonly static string STR_PLUS_BTN = "//input[@id='EZSMF_CBX3']";
        readonly static string STR_P_BTN = "//input[@id='VEX8W_CBX4']";
        readonly static string STR_SELOP_DROPDOWN = "//div[@name='selOpt']/select";
        readonly static string STR_NOSEL_DROPDOWN = "//div[@name='noSel']/select";
        readonly static string STR_SUBMIT_BTN = "//button[text()='Submit']";


        /*CONSTRUCTOR*/
        public MainPage(IWebDriver pdriver)
        {
            _driver = pdriver;
        }

        /*OBJECT DEFINITION*/
        private IWebElement objFirstNameTxt;// => _driver.FindElement(By.XPath(STR_FIRSTNAME_TXT));
        private IWebElement objLastNameTxt;// => _driver.FindElement(By.XPath(STR_LASTNAME_TXT));
        private IWebElement objBCheck;// => _driver.FindElement(By.XPath(STR_B_BTN));
        private IWebElement objCCheck;// => _driver.FindElement(By.XPath(STR_C_BTN));
        private IWebElement objPlusCheck;// => _driver.FindElement(By.XPath(STR_PLUS_BTN));
        private IWebElement objPCheck;// => _driver.FindElement(By.XPath(STR_P_BTN));
        private IWebElement objSelOptDrop;// => _driver.FindElement(By.XPath(STR_SELOP_DROPDOWN));
        private IWebElement objNoSelOptDrop;// => _driver.FindElement(By.XPath(STR_NOSEL_DROPDOWN));
        private IWebElement objSubmitBtn;// => _driver.FindElement(By.XPath(STR_SUBMIT_BTN));


        /*METHODS / FUNCTIONS*/
        //First Name TextBox
        private IWebElement GetFirstName()
        {
            return objFirstNameTxt;
        }
        public void fnEnterFirstN(string pstrFirstName)
        {
            objFirstNameTxt = _driver.FindElement(By.XPath(STR_FIRSTNAME_TXT));
            objFirstNameTxt.Clear();
            objFirstNameTxt.SendKeys(pstrFirstName);
        }

        private IWebElement GetLastName()
        {
            return objLastNameTxt;
        }
        public void fnEnterLastN(string pstrLastName)
        {
            objLastNameTxt = _driver.FindElement(By.XPath(STR_LASTNAME_TXT));
            objLastNameTxt.Clear();
            objFirstNameTxt.SendKeys(pstrLastName);
        }

        private IWebElement GetBCheck()
        {
            return objBCheck;
        }
        public void fnClickB(bool pstrFlag = true)
        {
            objBCheck = _driver.FindElement(By.XPath(STR_B_BTN));
            if (pstrFlag)
            {
                if (objBCheck.Selected)
                {
                    objBCheck.Click();
                }
                objBCheck.Click();
            }
            else
            {
                if (objBCheck.Selected)
                {
                    objBCheck.Click();
                }
            }
        }

        private IWebElement GetCCheck()
        {
            return objCCheck;
        }
        public void fnClickC(bool pstrFlag = true)
        {
            objCCheck = _driver.FindElement(By.XPath(STR_C_BTN));
            if (pstrFlag)
            {
                if (objCCheck.Selected)
                {
                    objCCheck.Click();
                }
                objCCheck.Click();
            }
            else
            {
                if (objCCheck.Selected)
                {
                    objCCheck.Click();
                }
            }
        }

        private IWebElement GetPlusCheck()
        {
            return objPlusCheck;
        }
        public void fnClickPlus(bool pstrFlag = true)
        {
            objPlusCheck = _driver.FindElement(By.XPath(STR_PLUS_BTN));
            if (pstrFlag)
            {
                if (objPlusCheck.Selected)
                {
                    objPlusCheck.Click();
                }
                objPlusCheck.Click();
            }
            else
            {
                if (objPlusCheck.Selected)
                {
                    objPlusCheck.Click();
                }
            }
        }

        private IWebElement GetPCheck()
        {
            return objPCheck;
        }
        public void fnClickP(bool pstrFlag=true)
        {
            objPCheck = _driver.FindElement(By.XPath(STR_P_BTN));
            if (pstrFlag)
            {
                if (objPCheck.Selected)
                {
                    objPCheck.Click();
                }
                objPCheck.Click();
            }
            else
            {
                if (objPCheck.Selected)
                {
                    objPCheck.Click();
                }
            }
        }

        private IWebElement GetSelOpt()
        {
            return objSelOptDrop;
        }
        public void fnSelFirstDropdownOpt(string pstrValue)
        {
            objSelOptDrop = _driver.FindElement(By.XPath(STR_SELOP_DROPDOWN));
            var selectElement = new SelectElement(objSelOptDrop);
            selectElement.SelectByText(pstrValue);
        }

        private IWebElement GetNoSelOpt()
        {
            return objNoSelOptDrop;
        }
        public void fnSelSecondDropdownOpt(string pstrValue)
        {
            objNoSelOptDrop = _driver.FindElement(By.XPath(STR_NOSEL_DROPDOWN));
            var selectElement = new SelectElement(objNoSelOptDrop);
            selectElement.SelectByText(pstrValue);
        }

        private IWebElement GetSubmitBtn()
        {
            return objSubmitBtn;
        }
        public void fnClickSubmit()
        {
            objSubmitBtn = _driver.FindElement(By.XPath(STR_SUBMIT_BTN));
            objSubmitBtn.Click();
        }

        public string fnReadPopUp()
        {
            string strAlertText = _driver.SwitchTo().Alert().Text;
            _driver.SwitchTo().Alert().Accept();
            return strAlertText;
        }




    }
}
