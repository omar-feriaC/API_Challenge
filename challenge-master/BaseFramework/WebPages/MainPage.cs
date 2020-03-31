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
        //Constructor
        public MainPage(IWebDriver driver)
        {
            this.objdriver = driver;
        }

        private IWebDriver objdriver;

        //Page Objects//
        readonly static string STRFIRSTNAME = "_firstName";
        readonly static string STRLASTNAME = "_lastName";
        readonly static string STRBCHECKBOX = "chk1";
        readonly static string STRCCHECKBOX = "chk2";
        readonly static string STRPLUSCHECKBOX = "chk13";
        readonly static string STRPCHECKBOX = "chk14";
        readonly static string STRFIRSDROPDOWN = "//div[@name='selOpt']//select";
        readonly static string STRSECONDDROPDOWN = "//div[@name='noSel']//select";
        readonly static string STRSUBMITBUTTON = "//button[text()='Submit']";

        private IWebElement objFirstName => objdriver.FindElement(By.Name(STRFIRSTNAME));
        private IWebElement objLastName => objdriver.FindElement(By.Name(STRLASTNAME));
        private IWebElement objBCheckBox => objdriver.FindElement(By.Name(STRBCHECKBOX));
        private IWebElement objCChecjBox => objdriver.FindElement(By.Name(STRCCHECKBOX));
        private IWebElement objPlusCheckBox => objdriver.FindElement(By.Name(STRPLUSCHECKBOX));
        private IWebElement objPCheckBox => objdriver.FindElement(By.Name(STRPCHECKBOX));
        private IWebElement objFirstDropDown => objdriver.FindElement(By.XPath(STRFIRSDROPDOWN));
        private IWebElement objSecondDropDown => objdriver.FindElement(By.XPath(STRSECONDDROPDOWN));
        private IWebElement objSubmitBtn => objdriver.FindElement(By.XPath(STRSUBMITBUTTON));

        //Methods//
        public void fnInputFirstName(string pstrFirstName)
        {
            objFirstName.Clear();
            objFirstName.SendKeys(pstrFirstName);
        }
        public void fnInputLastName(string pstrLastName)
        {
            objLastName.Clear();
            objLastName.SendKeys(pstrLastName);
        }
     
        public void fnClickBCheckBox()
        {
            objBCheckBox.Click();
        }
        public void fnClickCCheckbox()
        {
            objCChecjBox.Click();
        }
        public void fnClickPlusCheckbox()
        {
            objPlusCheckBox.Click();
        }
        public void fnClickPCheckbox()
        {
            objPCheckBox.Click();
        }
        public void fnClickSubmitButton()
        {
            objSubmitBtn.Click();
        }
        public void fnSelectFirstDropDown(string pstrItem)
        {
            var selectElement = new SelectElement(objFirstDropDown);
            selectElement.SelectByText(pstrItem);
        }
        public void fnSelectSecondDropDown(string pstrItem)
        {
            var selectElement = new SelectElement(objSecondDropDown);
            selectElement.SelectByText(pstrItem);
        }

        public string ConfirmationWindow(string pstrMessage)
        {
            var window = objdriver.SwitchTo().Alert();
            string messageinwindow = window.Text;
            if (messageinwindow.Contains(pstrMessage))
            {
                window.Accept();
            }
            return messageinwindow;
        }

    }

}
