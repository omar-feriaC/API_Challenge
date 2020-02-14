using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseFramework.WebPages
{
    public class BasePage
    {
        private static readonly string url = "http://ztestqa.com/selenium/mainpage.html";
        public static IWebDriver driver;

        [SetUp]
        public static void SetUp()
        {
            IWebDriver pWebDriver = new ChromeDriver();
            pWebDriver.Url = url;
            driver = pWebDriver;
        }
        [TearDown]
        public static void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
