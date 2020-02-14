using BaseFramework.WebPages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework
{
    class PageModel : BaseTest
    {
        public static IWebDriver _driver;

        public PageModel(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
