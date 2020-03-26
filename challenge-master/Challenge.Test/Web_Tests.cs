using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests : BaseTest
    {
        MainPage objPage;
        [Test, Order(0)]
        public void Positive()
        {
            try { 
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Eduardo");
            MainPage.EnterLastName("Mendoza");
            MainPage.CleanCheckboxes();
            MainPage.SelectCheckBoxB();
            MainPage.SelectCheckBoxPlus();
            MainPage.SelectCheckBoxP();
            MainPage.SelectFirstDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"Congratulations Eduardo! Everything was properly populated.";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            Console.WriteLine("Test case passed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

        [Test, Order(1)]
        public void NegativeFirstNameEmpty()
        {
            try
            {
                objPage = new MainPage(driver);
                MainPage.EnterLastName("Mendoza");
                MainPage.CleanCheckboxes();
                MainPage.SelectCheckBoxB();
                MainPage.SelectCheckBoxPlus();
                MainPage.SelectCheckBoxP();
                MainPage.SelectFirstDropdown("5");
                MainPage.ClickSubmitButton();
                string strActualAlertMsg = MainPage.GetAlertText();
                MainPage.CloseAlert();
                string strExpectedAlertMsg = $"Please enter a first name";
                Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

        [Test, Order(2)]
        public void NegativeLastNameEmpty()
        {
            try
            {
                objPage = new MainPage(driver);
                MainPage.EnterFirstName("Eduardo");
                MainPage.CleanCheckboxes();
                MainPage.SelectCheckBoxB();
                MainPage.SelectCheckBoxPlus();
                MainPage.SelectCheckBoxP();
                MainPage.SelectFirstDropdown("5");
                MainPage.ClickSubmitButton();
                string strActualAlertMsg = MainPage.GetAlertText();
                MainPage.CloseAlert();
                string strExpectedAlertMsg = $"Please enter a last name";
                Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

        [Test, Order(3)]
        public void NegativeWrongCheckBoxSelected()
        {
            try
            {
                objPage = new MainPage(driver);
                MainPage.EnterFirstName("Eduardo");
                MainPage.EnterLastName("Mendoza");
                MainPage.CleanCheckboxes();
                MainPage.SelectCheckBoxB();
                MainPage.SelectCheckBoxC();
                MainPage.SelectCheckBoxPlus();
                MainPage.SelectCheckBoxP();
                MainPage.SelectFirstDropdown("5");
                MainPage.ClickSubmitButton();
                string strActualAlertMsg = MainPage.GetAlertText();
                MainPage.CloseAlert();
                string strExpectedAlertMsg = $"The checkbox selection is not quite right";
                Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

        [Test, Order(4)]
        public void NegativeWrongDropdownSelectedInFirstDropdown()
        {
            try
            {
                objPage = new MainPage(driver);
                MainPage.EnterFirstName("Eduardo");
                MainPage.EnterLastName("Mendoza");
                MainPage.CleanCheckboxes();
                MainPage.SelectCheckBoxB();
                MainPage.SelectCheckBoxPlus();
                MainPage.SelectCheckBoxP();
                MainPage.SelectFirstDropdown("4");
                MainPage.ClickSubmitButton();
                string strActualAlertMsg = MainPage.GetAlertText();
                MainPage.CloseAlert();
                string strExpectedAlertMsg = $"The dropdown selection is not quite right";
                Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

        [Test, Order(5)]
        public void NegativeWrongDropdownSelectedInSecondDropdown()
        {
            try
            {
                objPage = new MainPage(driver);
                MainPage.EnterFirstName("Eduardo");
                MainPage.EnterLastName("Mendoza");
                MainPage.CleanCheckboxes();
                MainPage.SelectCheckBoxB();
                MainPage.SelectCheckBoxPlus();
                MainPage.SelectCheckBoxP();
                MainPage.SelectFirstDropdown("5");
                MainPage.SelectSecondDropdown("5");
                MainPage.ClickSubmitButton();
                string strActualAlertMsg = MainPage.GetAlertText();
                MainPage.CloseAlert();
                string strExpectedAlertMsg = $"A selection was made other than the default in select list 2";
                Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
            }

            catch (Exception e)
            {
                Console.WriteLine("Test case failed: " + e.Message);
                Assert.Fail();
            }
        }

    }
}
