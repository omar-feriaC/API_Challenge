using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class BaseTest
    {
        public static IWebDriver driver;
        private static string strBrowserName = "http://ztestqa.com/selenium/mainpage.html";

        [SetUp]
        /*Initialize the driver and indicates the url*/
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = strBrowserName;
        }

        [TearDown]
        /*Close the browser and quit the selenium instance*/
        public static void AfterTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
