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
        private IWebDriver objDriver;
        readonly static string strFIRSTNAME = "_fNameInput";
        readonly static string strLASTNAME = "_lNameInput";
        readonly static string strCHECK_B = "DX3GY_CBX1";
        readonly static string strCHECK_C = "AGSRO_CBX2";
        readonly static string strCHECK_PLUS = "EZSMF_CBX3";
        readonly static string strCHECK_P = "VEX8W_CBX4";
        readonly static string strSELECT_DRPDW = "//div[@name='selOpt']//select";
        readonly static string strDONT_SELECT_DRPDW = "//div[@name='noSel']//select";
        readonly static string strSUBMIT_BTN = "//button[text()='Submit']";
        readonly static string[] arrCheckBx = { strCHECK_B, strCHECK_C, strCHECK_PLUS, strCHECK_P };

        private IWebElement objFirstName => objDriver.FindElement(By.Id(strFIRSTNAME));
        private IWebElement objLastName => objDriver.FindElement(By.Id(strLASTNAME));
        private IWebElement objCheckB => objDriver.FindElement(By.Id(strCHECK_B));
        private IWebElement objCheckC => objDriver.FindElement(By.Id(strCHECK_C));
        private IWebElement objCheckPlus => objDriver.FindElement(By.Id(strCHECK_PLUS));
        private IWebElement objCheckP => objDriver.FindElement(By.Id(strCHECK_P));
        private IWebElement objDropSelect => objDriver.FindElement(By.XPath(strSELECT_DRPDW));
        private IWebElement objDropDontSelect => objDriver.FindElement(By.XPath(strDONT_SELECT_DRPDW));
        private IWebElement objSubmitBtn => objDriver.FindElement(By.XPath(strSUBMIT_BTN));
        
        //Constructor
        public MainPage(IWebDriver driver)
        {
            this.objDriver = driver;
        }

        //Methods
        public void fnInsertFirstName(string pstrFirstName)
        {
            objFirstName.SendKeys(pstrFirstName);
        }

        public void fnInsertLastName(string pstrLastName)
        {
            objLastName.SendKeys(pstrLastName);
        }

        public void fnResetChecks()
        {
            for (int j = 0; j < arrCheckBx.Length; j++)
            {
                if (objDriver.FindElement(By.Id(arrCheckBx[j])).Selected)
                {
                    objDriver.FindElement(By.Id(arrCheckBx[j])).Click();
                }
            }
        }

        public void fnClickCheckbox_b()
        {
            objCheckB.Click();
        }

        public void fnClickCheckbox_c()
        {
            objCheckC.Click();
        }

        public void fnClickCheckbox_plus()
        {
            objCheckPlus.Click();
        }

        public void fnClickCheckbox_p()
        {
            objCheckP.Click();
        }

        public void fnClickSubmitButton()
        {
            objSubmitBtn.Click();
        }

        public void fnSelectDropDownSelect(string pstrItem)
        {
            var selectElement = new SelectElement(objDropSelect);
            selectElement.SelectByText(pstrItem);
        }

        public void fnSelectDropDownDontSelect(string pstrItem)
        {
            var selectElement = new SelectElement(objDropDontSelect);
            selectElement.SelectByText(pstrItem);
        }

        public string ConfirmationWindow(string pstrMessage)
        {
            var window = objDriver.SwitchTo().Alert();
            string messageinwindow = window.Text;
            if (messageinwindow.Contains(pstrMessage))
            {
                window.Accept();
            }
            return messageinwindow;
        }
    }
}
