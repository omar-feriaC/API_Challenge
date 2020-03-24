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

        private IWebDriver objDriver2;

        readonly static string FIRSTNAME = "_fNameInput";
        readonly static string LASTNAME = "_lNameInput";
        readonly static string CHECKBOXB = "DX3GY_CBX1";
        readonly static string CHECKBOXC = "AGSRO_CBX2";
        readonly static string CHECKBOXPLUS = "EZSMF_CBX3";
        readonly static string CHECKBOXP = "VEX8W_CBX4";
        readonly static string DROPDOWN1 = "//div[@name='selOpt']//select";
        readonly static string DROPDOWN2 = "//div[@name='noSel']//select";
        readonly static string SUBMITBTN = "//button[text()='Submit']";
        private IWebElement objFirstName => objDriver2.FindElement(By.Id(FIRSTNAME));
        private IWebElement objLastName => objDriver2.FindElement(By.Id(LASTNAME));
        private IWebElement objCheckBoxB => objDriver2.FindElement(By.Id(CHECKBOXB));
        private IWebElement objCheckBoxC => objDriver2.FindElement(By.Id(CHECKBOXC));
        private IWebElement objCheckBoxPlus => objDriver2.FindElement(By.Id(CHECKBOXPLUS));
        private IWebElement objCheckBoxP => objDriver2.FindElement(By.Id(CHECKBOXP));
        private IWebElement objDropDown1 => objDriver2.FindElement(By.XPath(DROPDOWN1));
        private IWebElement objDropDown2 => objDriver2.FindElement(By.XPath(DROPDOWN2));
        private IWebElement objSubmitBtn => objDriver2.FindElement(By.XPath(SUBMITBTN));

        public static readonly string Url = "http://ztestqa.com/selenium/mainpage.html";

        //private readonly IWebDriver objDriver;

        public MainPage(IWebDriver objDriver)
        {
            this.objDriver2 = objDriver;
        }

        public void InsertFirstName(string FirstName)
        {
            objFirstName.SendKeys(FirstName);
        }

        public void InsertLastName(string LastName)
        {
            objLastName.SendKeys(LastName);
        }

        public void ResetCheckBoxes()
        {
            if (objCheckBoxB.Selected)
            {
                objCheckBoxB.Click();
            }
            if (objCheckBoxC.Selected)
            {
                objCheckBoxC.Click();
            }
            if (objCheckBoxPlus.Selected)
            {
                objCheckBoxPlus.Click();
            }
            if (objCheckBoxP.Selected)
            {
                objCheckBoxP.Click();
            }
        }

        public void clickCheckboxB()
        {
            objCheckBoxB.Click();
        }

        public void clickCheckboxC()
        {
            objCheckBoxC.Click();
        }

        public void clickCheckboxPlus()
        {
            objCheckBoxPlus.Click();
        }

        public void clickCheckboxP()
        {
            objCheckBoxP.Click();
        }

        public void clickSubmitBtn()
        {
            objSubmitBtn.Click();
        }

        public void selectDropDown1(string item)
        {
            var selectElement = new SelectElement(objDropDown1);
            selectElement.SelectByText(item);
        }

        public void selectDropDown2(string item)
        {
            var selectElement = new SelectElement(objDropDown2);
            selectElement.SelectByText(item);
        }

        public string ConfirmationWindow(string message)
        {
            var window = objDriver2.SwitchTo().Alert();
            string messageinwindow = window.Text;
            if (messageinwindow.Contains(message))
            {
                window.Accept();

            }
            return messageinwindow;
        }
    }
}