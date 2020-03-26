using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
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

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"Congratulations {FName}! Everything was properly populated.", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }
        [Test]
        public void MainPage_Empty_FirstName_Negative()
        {
            try
            {
                //Initiate object
                objPOM_Selenium = new POM_SeleniumTestPage(objdriver);
                string strPopUpText;
                _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));

                //Call methods
                string LName = "Last";
                objPOM_Selenium.fnScenarioFNameEmprty(LName);

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"Please enter a first name", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }

        [Test]
        public void MainPage_Empty_LastName_Negative()
        {
            try
            {
                //Initiate object
                objPOM_Selenium = new POM_SeleniumTestPage(objdriver);
                string strPopUpText;
                _objDriverWait = new WebDriverWait(objdriver, new TimeSpan(0, 0, 15));

                //Call methods
                string FName = "AlexFirst";
                objPOM_Selenium.fnScenarioLNameEmprty(FName);

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"Please enter a last name", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }

        [Test]
        public void MainPage_Wrong_CHK_Negative()
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
                objPOM_Selenium.fnScenarioWrongCHK(FName, LName);

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"The checkbox selection is not quite right", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }

        [Test]
        public void MainPage_Wrong_DRPOption_Negative()
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
                objPOM_Selenium.fnScenarioWrongOptionDRP1(FName, LName);

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"The dropdown selection is not quite right", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }

        [Test]
        public void MainPage_Wrong_DRPTWO_Option_Negative()
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
                objPOM_Selenium.fnScenarioWrongOptionDRP2(FName, LName);

                IAlert alert = objdriver.SwitchTo().Alert();
                strPopUpText = objdriver.SwitchTo().Alert().Text;

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual($"A selection was made other than the default in select list 2", strPopUpText, false, "Test has Passed");
                Console.WriteLine(strPopUpText);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test has failed due following error:\n{ex}");
                NUnit.Framework.Assert.Fail();
            }
        }

    }
}
