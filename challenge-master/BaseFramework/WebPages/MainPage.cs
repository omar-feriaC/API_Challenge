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
        //  public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        private IWebDriver _driver;
        private static readonly string FirstName = "_fNameInput";
        private static readonly string LastName = "_lNameInput";
        private static readonly string CheckBox1 = "DX3GY_CBX1";
        private static readonly string CheckBox2 = "AGSRO_CBX2";
        private static readonly string CheckBox3 = "EZSMF_CBX3";
        private static readonly string CheckBox4 = "VEX8W_CBX4";
        private static readonly string DropDownOption1 = "//div[@name='selOpt']//select";
        private static readonly string DropDownOption2 = "//div[@name='noSel']//select";
        private static readonly string SubmitButton = "//html[1]/body[1]/div[6]/button[1]";

        public IWebElement objFirstName => _driver.FindElement(By.Id(FirstName));
        public IWebElement objLastName => _driver.FindElement(By.Id(LastName));
        public IWebElement objCheckBox1 => _driver.FindElement(By.Id(CheckBox1));
        public IWebElement objCheckBox2 => _driver.FindElement(By.Id(CheckBox2));
        public IWebElement objCheckBox3 => _driver.FindElement(By.Id(CheckBox3));
        public IWebElement objCheckBox4 => _driver.FindElement(By.Id(CheckBox4));
        public IWebElement objDropDownOption1 => _driver.FindElement(By.XPath(DropDownOption1));
        public IWebElement objDropDownOption2 => _driver.FindElement(By.XPath(DropDownOption2));
        public IWebElement objSubmitButton => _driver.FindElement(By.XPath(SubmitButton));

        public string getFirstName()
        {
            return objFirstName.Text;
        }

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void clearFirstName()
        {
            objFirstName.Clear();
        }

        public void enterFirstName(string firstName)
        {
            objFirstName.SendKeys(firstName);
        }

        public void clearLastName()
        {
            objLastName.Clear();
        }

        public void enterLastName(string lastName)
        {
            objLastName.SendKeys(lastName);
        }

        public void clickBCheckbox()
        {
            objCheckBox1.Click();
        }

        public void clickCCheckbox()
        {
            objCheckBox2.Click();
        }

        public void clickPlusCheckbox()
        {
            objCheckBox3.Click();
        }

        public void clickPCheckbox()
        {
            objCheckBox4.Click();
        }

        public void clickSubmitButton()
        {
            objSubmitButton.Click();
        }

        public void selectDropDownOption1(string option)
        {
            var selectElement = new SelectElement(objDropDownOption1);
            selectElement.SelectByText(option);
        }

        public void selectDropDownOption2(string option)
        {
            var selectElement = new SelectElement(objDropDownOption2);
            selectElement.SelectByText(option);
        }

        public string Alert(string message)
        {
            var alert = _driver.SwitchTo().Alert();
            string text = alert.Text;
            if (!text.Contains(message))
            {
                Console.WriteLine("Message not displayed correctly");
            }
            else
            {
                Console.WriteLine("Message displayed correctly");
                alert.Accept();
            }

            return text;
        }

        public void clearButtons()
        {
            if (objCheckBox1.Selected)
            {
                objCheckBox1.Click();
            }
            if (objCheckBox2.Selected)
            {
                objCheckBox2.Click();
            }
            if (objCheckBox3.Selected)
            {
                objCheckBox3.Click();
            }
            if (objCheckBox4.Selected)
            {
                objCheckBox4.Click();
            }
        }

    }
}