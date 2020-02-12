using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseFramework.WebPages
{
    public class clsDriver : BaseTest
    {
        /*ATTRIBUTES*/
        private static IWebDriver _objDriver;
        private static WebDriverWait _driverWait;
        private static IWebElement objElement;

        /*CONSTRUCTOR*/
        public clsDriver(IWebDriver pobjDriver)
        {
            _objDriver = pobjDriver;
            _driverWait = new WebDriverWait(_objDriver, new TimeSpan(0, 0, 40));
        }

        /*METHODS*/
        private static IWebElement WaitForElementThread(IWebDriver pobjDriver, By by, string pstrDesc)
        {
            Thread.Sleep(5000);
            objElement = pobjDriver.FindElement(by);
            return objElement;
        }

        private static IWebElement fnWaitForElementDriver(IWebDriver pobjDriver, By by)
        {
            objElement = _driverWait.Until(ExpectedConditions.ElementExists(by));
            objElement = _driverWait.Until(ExpectedConditions.ElementIsVisible(by));
            return objElement;
        }

        private static IWebElement WaitForElementDriverFluent(IWebDriver pobjDriver, By by)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.Id("search_result")));
            return objElement;
        }

        /*Wait for element to Exist*/
        public static IWebElement fnWaitForElementToExist(By by)
        {
            objElement = _driverWait.Until(ExpectedConditions.ElementExists(by));
            return objElement;
        }

        /*Wait for element to be visible*/
        public static IWebElement fnWaitForElementToBeVisible(By by)
        {
            objElement = _driverWait.Until(ExpectedConditions.ElementIsVisible(by));
            return objElement;
        }

        /*Wait for element to be clickable*/
        public static IWebElement fnWaitForElementToBeClickable(By by)
        {
            objElement = _driverWait.Until(ExpectedConditions.ElementToBeClickable(by));
            return objElement;
        }

        /*Wait for element to be selected*/
        public static bool fnWaitForElementToBeSelected(By by)
        {
            if (_driverWait.Until(ExpectedConditions.ElementToBeSelected(by)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
