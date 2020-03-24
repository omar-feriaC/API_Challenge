using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


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
            if( objCheckBoxStatus.Selected==false)
            {
               objCheckBoxB.Click();
            }
        }




    }
}
