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
        // creating Objects to store locators
        private static readonly string FIRSTNAME_TEXTFIELD = "_fNameInput";
        private static readonly string LASTNAME_TEXTFIELD = "_lNameInput";
        public string CHECKBUTTONB_BUTTON = "DX3GY_CBX1";
        public string CHECKBUTTONC_BUTTON = "AGSRO_CBX2";
        public string CHECKBUTTONPLUS_BUTTON = "EZSMF_CBX3";
        public string CHECKBUTTONP_BUTTON = "VEX8W_CBX4";
        private static readonly string SELECTELEMENT1_DROPDOWN = "//div[@name='selOpt']//select";
        private static readonly string SELECTELEMENT2_DROPDOWN = "//div[@name='noSel']//select";
        private static readonly string SUBMIT_BUTTON = "/html[1]/body[1]/div[6]/button[1]";

        private IWebDriver _driver;

        public MainPage(IWebDriver driver) {

            this._driver = driver;
        }


        //Defining properties
        public IWebElement firstNameTxt => _driver.FindElement(By.Id(FIRSTNAME_TEXTFIELD));
        public IWebElement lastNameTxt => _driver.FindElement(By.Id(LASTNAME_TEXTFIELD));
        public IWebElement checkButtonBBtn => _driver.FindElement(By.Id(CHECKBUTTONB_BUTTON));
        public IWebElement checkButtonCBtn => _driver.FindElement(By.Id(CHECKBUTTONC_BUTTON));
        public IWebElement checkButtonPlusBtn => _driver.FindElement(By.Id(CHECKBUTTONPLUS_BUTTON));
        public IWebElement checkButtonPBtn => _driver.FindElement(By.Id(CHECKBUTTONP_BUTTON));
        public IWebElement dropDown1DD => _driver.FindElement(By.XPath(SELECTELEMENT1_DROPDOWN));
        public IWebElement dropDown2DD => _driver.FindElement(By.XPath(SELECTELEMENT2_DROPDOWN));
        public IWebElement submitBtn => _driver.FindElement(By.XPath(SUBMIT_BUTTON));

        //Interacting with the objects
        public IWebElement GetFirstNameTxtField() {

            return firstNameTxt;
        }
        public void EnterFirstName(string strFirstName) {
            firstNameTxt.SendKeys(strFirstName);

        }
        public void EnterLastName(string strLastName) {
            lastNameTxt.SendKeys(strLastName);

        }
        public void CleanButtons() {
            if (checkButtonBBtn.Selected)
            {
                checkButtonBBtn.Click();
            }
            if (checkButtonCBtn.Selected)
            {
                checkButtonCBtn.Click();
            }
            if (checkButtonPlusBtn.Selected)
            {
                checkButtonPlusBtn.Click();
            }
            if (checkButtonPBtn.Selected)
            {
                checkButtonPBtn.Click();
            }
        }
        public void ClickBBox() {
            checkButtonBBtn.Click();
        }
        public void ClickPBox() {
            checkButtonPBtn.Click();
        }
        public void ClickCBox() {
            checkButtonCBtn.Click();
        }
        public void ClickPlusBox() {
            checkButtonPlusBtn.Click();
        }
        public void SelectDropDown1(string option) {

            var selectElement = new SelectElement(dropDown1DD);
            selectElement.SelectByText(option);

        }
        public void SelectDropDown2(string option2) {

            var selectElement = new SelectElement(dropDown2DD);
            selectElement.SelectByText(option2);
        }
        public void ClickSubmitBtn() {
            submitBtn.Click();

        }
        public IWebElement GetSingInButton() {

            return submitBtn;
        }
        public void Alert(string message) {

            var alert = _driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (!alertText.Contains(message))
            {
                Console.WriteLine("User creation fail");
            }
            else
            {
                Console.WriteLine("User created");
                alert.Accept();
            }
        }
        public void Refresh() {
            _driver.Navigate().Refresh();
        }
    }
}
