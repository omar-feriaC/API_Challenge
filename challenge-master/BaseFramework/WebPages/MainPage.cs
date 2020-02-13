
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaseFramework.WebPages
{
    public class MainPage
    {

       
        private IWebDriver driver2;

        readonly static string  FIRSTNAME = "_fNameInput";
        readonly static string  LASTNAME = "_lNameInput";
        readonly static string  CHECKBXB = "DX3GY_CBX1";
        readonly static string  CHECKBXC = "AGSRO_CBX2";
        readonly static string  CHECKBXPLUS = "EZSMF_CBX3";
        readonly static string  CHECKBXP = "VEX8W_CBX4";
        readonly static string  DROPDWN1 = "//div[@name='selOpt']//select";
        readonly static string  DROPDWN2 = "//div[@name='noSel']//select";
        readonly static string  SUBMITBTN = "//button[text()='Submit']";




        private IWebElement objFirstName => driver2.FindElement(By.Id(FIRSTNAME));
        private IWebElement objLastName => driver2.FindElement(By.Id(LASTNAME));
        private IWebElement objCheckBxB => driver2.FindElement(By.Id(CHECKBXB));
        private IWebElement objCheckBxC => driver2.FindElement(By.Id(CHECKBXC));
        private IWebElement objCheckBxPlus => driver2.FindElement(By.Id(CHECKBXPLUS));
        private IWebElement objCheckBxP => driver2.FindElement(By.Id(CHECKBXP));
        private IWebElement objDropDwn1 => driver2.FindElement(By.XPath(DROPDWN1));
        private IWebElement objDropDwn2 => driver2.FindElement(By.XPath(DROPDWN2));
        private IWebElement objSubmitBtn => driver2.FindElement(By.XPath(SUBMITBTN));

        

        public MainPage(IWebDriver driver)
        {
            this.driver2 = driver;
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
            if (objCheckBxB.Selected)
            {
                objCheckBxB.Click();
            }
            if (objCheckBxC.Selected)
            {
                objCheckBxC.Click();
            }
            if (objCheckBxPlus.Selected)
            {
                objCheckBxPlus.Click();
            }
            if (objCheckBxP.Selected)
            {
                objCheckBxP.Click();
            }
        }

        public void clickBCheckbox()
        {
            objCheckBxB.Click();
        }

        public void clickCCheckbox()
        {
            objCheckBxC.Click();
        }

        public void clickPlusCheckbox()
        {
            objCheckBxPlus.Click();
        }

        public void clickPCheckbox()
        {
            objCheckBxP.Click();
        }

        public void clickSubmitButton()
        {
            objSubmitBtn.Click();
        }

        public void selectDropDownOption1(string item)
        {
            var selectElement = new SelectElement(objDropDwn1);
            selectElement.SelectByText(item);
        }

        public void selectDropDownOption2(string item)
        {
            var selectElement = new SelectElement(objDropDwn2);
            selectElement.SelectByText(item);
        }

        public string ConfirmationWindow(string message)
        {
            var window = driver2.SwitchTo().Alert();
            string messageinwindow = window.Text;
            if (messageinwindow.Contains(message))
            {
                window.Accept();
               
            }


            return messageinwindow;

        }

        
    }
}
