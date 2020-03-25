using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Challenge.Test
{

    public class Web_Tests : MainPage
    {
        public static POM_SeleniumTestPage objPOM_Selenium;
        public static WebDriverWait _objDriverWait;

        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            
            try
            {
                //Initiate object
                objPOM_Selenium = new POM_SeleniumTestPage(objdriver);
                string strPopUpText;
                _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));

                //Call methods
                string FName = "Alex";
                string LName = "Last";
                objPOM_Selenium.fnScenarioPositive1(FName,LName);
                NUnit.Framework.Assert.Pass("Test has passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }
    }
}
