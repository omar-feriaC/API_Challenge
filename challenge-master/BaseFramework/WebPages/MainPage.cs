using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BaseFramework.WebPages
{
    public class MainPage
    {
        //public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";

        /*DRIVER REFERENCE*/
        string url;

        private static IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            // this._driver = driver;
            _driver = driver;
        }


        /*ELEMENT LOCATORS*/
        private static readonly string STR_USERNAME_TEXTFIELD = "//div[@id='fNameSect']//input[1]";
        private static readonly string STR_USERLASTNAME_TEXTFIELD = "//div[@id='lNameSect']//input[1]";

        //CHECK BOX OPTIONS
        private static readonly string CHECK_BOX_B = "//input[contains(@name, 'chk1')]";
        private static readonly string CHECK_BOX_C = "//input[contains(@name, 'chk2')]";
        private static readonly string CHECK_BOX_X = "//input[contains(@name, 'chk3')]";
        private static readonly string CHECK_BOX_P = "//input[contains(@name, 'chk4')]";
        private static readonly string DROP__DOWN_1 = "html[1]/body[1]/div[4]/select[1]";
        private static readonly string DROP__DOWN_2 = "//div[text()='Do not select anything from this drop down.']/following-sibling::select";
        private static readonly string SUBMITBTN = "//div[text()='Click on Submit, then read out the alert message']/following-sibling::button";


        //CHECK THE STATUS OF CHECKBOX
        private static readonly string CHECKBOX_STATUS = "input:not(:checked)[type='checkbox']";

        /*PAGE ELEMENT OBJECTS*/
        private static IWebElement objUsernameText => _driver.FindElement(By.XPath(STR_USERNAME_TEXTFIELD));
        private static IWebElement objLastnameText => _driver.FindElement(By.XPath(STR_USERLASTNAME_TEXTFIELD));

        //CHECK OPTIONS
        private static IWebElement objCheckBoxB => _driver.FindElement(By.XPath(CHECK_BOX_B));
        private static IWebElement objCheckBoxC => _driver.FindElement(By.XPath(CHECK_BOX_C));
        private static IWebElement objCheckBoxX => _driver.FindElement(By.XPath(CHECK_BOX_X));
        private static IWebElement objCheckBoxP => _driver.FindElement(By.XPath(CHECK_BOX_P));
        private static IWebElement objDropDown1 => _driver.FindElement(By.XPath(DROP__DOWN_1));
        private static IWebElement objDropDown2 => _driver.FindElement(By.XPath(DROP__DOWN_2));
        private static IWebElement objSubmiBtn => _driver.FindElement(By.XPath(SUBMITBTN));

        //STATUS 
        private static IWebElement objCheckBoxStatus => _driver.FindElement(By.CssSelector(CHECKBOX_STATUS));

        /*GET ELEMENT METHODS*/
        public IWebElement GetUsernameField()
        {
            return objUsernameText;
        }
        public IWebElement GetLastnameField()
        {
            return objLastnameText;
        }
        //************************************
        public IWebElement GetCheckBoxStatus()
        {
            return objCheckBoxStatus;
        }
        public IWebElement GetCheckBoxB()
        {
            return objCheckBoxB;
        }
        public IWebElement GetCheckBoxC()
        {
            return objCheckBoxC;
        }
        public IWebElement GetCheckBoxX()
        {
            return objCheckBoxX;
        }
        public IWebElement GetCheckBoxP()
        {
            return objCheckBoxP;
        }
        public IWebElement GetDropDown1()
        {
            return objDropDown1;
        }
        public IWebElement GetDropDown2()
        {
            return objDropDown2;
        }
        public IWebElement GetSubmitBtn()
        {
            return objSubmiBtn;
        }

        /*PAGE ELEMENT ACTIONS*/
        public void fnEnterUsername(string pstrUsername)
        {
            objUsernameText.Clear();
            objUsernameText.SendKeys(pstrUsername);
        }
        public void fnEnterUserLastname(string pstrUserLastname)
        {
            objLastnameText.Clear();
            objLastnameText.SendKeys(pstrUserLastname);
        }

        public void fnPositiveTest()
        {
            if (objCheckBoxB.Selected == false)
            { objCheckBoxB.Click(); }
            if (objCheckBoxX.Selected == false)
            { objCheckBoxX.Click(); }
            if (objCheckBoxP.Selected == false)
            { objCheckBoxP.Click(); }
            if (objCheckBoxC.Selected == false)
            {
                //if is checked, dont do anything
            }
            else { objCheckBoxC.Click(); }
            objDropDown1.Click();
            objDropDown1.SendKeys("5");
            objDropDown1.Click();

            objSubmiBtn.Click();
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e);
            }

        }
        public void fnAddCheckBoxC()
        {
            if (objCheckBoxB.Selected == false)
            {
                objCheckBoxB.Click();
            }
            if (objCheckBoxX.Selected == false)
            {
                objCheckBoxX.Click();
            }
            if (objCheckBoxP.Selected == false)
            {
                objCheckBoxP.Click();
            }
            if (objCheckBoxC.Selected == true)
            {
                //objCheckBoxC.Click();
            }
            else { objCheckBoxC.Click(); }
            objDropDown1.Click();
            objDropDown1.SendKeys("5");
            objDropDown1.Click();

            objSubmiBtn.Click();
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e);
            }
        }
        public void fnWrongFirstDropDwn()
        {
            if (objCheckBoxB.Selected == false)
            { objCheckBoxB.Click(); }
            if (objCheckBoxX.Selected == false)
            { objCheckBoxX.Click(); }
            if (objCheckBoxP.Selected == false)
            { objCheckBoxP.Click(); }
            if (objCheckBoxC.Selected == false)
            {
                //if is checked, dont do anything
            }
            else { objCheckBoxC.Click(); }
            objDropDown1.Click();
            objDropDown1.SendKeys("4");
            objDropDown1.Click();

            objSubmiBtn.Click();
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e);
            }

        }
        public void fnWrongSecondDropDwn()
        {
            if (objCheckBoxB.Selected == false)
            { objCheckBoxB.Click(); }
            if (objCheckBoxX.Selected == false)
            { objCheckBoxX.Click(); }
            if (objCheckBoxP.Selected == false)
            { objCheckBoxP.Click(); }
            if (objCheckBoxC.Selected == false)
            {
                //if is checked, dont do anything
            }
            else { objCheckBoxC.Click(); }
            objDropDown1.Click();
            objDropDown1.SendKeys("5");
            objDropDown1.Click();
            objDropDown2.Click();
            objDropDown2.SendKeys("5");
            objDropDown2.Click();

            objSubmiBtn.Click();
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
