using System;
using System.Linq;
using BaseFramework.WebPages;
using Challenge.Test.Base_Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests : BaseTest
    {
        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('5')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            //MainPage.FnClickIWebElement(MainPage.GetDropdown1().FindIndex());
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("Congratulations Edd! Everything was properly populated.", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void MainPage_Incorrect_FirstName_Negative()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            //MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('5')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            //MainPage.FnClickIWebElement(MainPage.GetDropdown1().FindIndex());
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("Please enter a first name", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void MainPage_Incorrect_LastName_Negative()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            //MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('5')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            //MainPage.FnClickIWebElement(MainPage.GetDropdown1().FindIndex());
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("Please enter a last name", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void MainPage_Incorrect_CheckboxC_Negative()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxC());
            /* MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());*/
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('5')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            //MainPage.FnClickIWebElement(MainPage.GetDropdown1().FindIndex());
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("The checkbox selection is not quite right", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void MainPage_Incorrect_Dropdown1_Negative()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('2')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            //MainPage.FnClickIWebElement(MainPage.GetDropdown1().FindIndex());
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("The dropdown selection is not quite right", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void MainPage_Incorrect_Dropdown2_Negative()
        {
            //Staring page
            MainPage objMainPage = new MainPage(driver);
            //Validating page is loaded correctly
            NUnit.Framework.Assert.AreEqual(true, driver.Url.Contains("http://ztestqa.com/selenium/mainpage.html"), "Page was not loaded correctly.");
            //Populating fields
            MainPage.FnSendkeyAndClear(MainPage.GetInputFirstName(), "Edd");
            MainPage.FnSendkeyAndClear(MainPage.GetInputLastName(), "Sainz");
            //Unchecking any checked checkbox 
            foreach (var iwebelement in FnCheckedBoxes(MainPage.GetChecboxes()))
                MainPage.FnClickIWebElement(iwebelement);
            //Populating fields
            MainPage.FnClickIWebElement(MainPage.GetCheckboxB());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxPlus());
            MainPage.FnClickIWebElement(MainPage.GetCheckboxP());
            var linqQuery = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('5')
                            select iwebelement;
            foreach (var iwebelement in linqQuery)
                MainPage.FnClickIWebElement(iwebelement);

            var linqQuery2 = from iwebelement in MainPage.GetDropdown1()
                            where iwebelement.Text.Contains('2')
                            select iwebelement;
            foreach (var iwebelement in linqQuery2)
                MainPage.FnClickIWebElement(iwebelement);
            //Click sumit button
            MainPage.FnClickIWebElement(MainPage.GetSubmitButton());

            //Validate popupMessage
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            NUnit.Framework.Assert.AreEqual("The dropdown selection is not quite right", driver.SwitchTo().Alert().Text, "Message was not the expected.");
            driver.SwitchTo().Alert().Accept();
        }
    }
}
