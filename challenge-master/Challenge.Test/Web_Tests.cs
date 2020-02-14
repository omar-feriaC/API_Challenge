using BaseFramework;
using BaseFramework.WebPages;
using NUnit.Framework;
using System;

namespace Challenge.Test
{
    class Web_Tests : BaseTest
    {
        MainPage objPage;
        [Test]
        public void Positive()
        {
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Danny");
            MainPage.EnterLastName("Beltran");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"Congratulations Danny! Everything was properly populated.";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
        [Test]
        public void Negative_First_Name_Empty()
        {
            objPage = new MainPage(driver);
            MainPage.EnterLastName("Beltran");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"Please enter a first name";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
        [Test]
        public void Negative_Last_Name_Empty()
        {
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Danny");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"Please enter a last name";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
        [Test]
        public void Negative_Wrong_Check_Box_Selected()
        {
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Danny");
            MainPage.EnterLastName("Beltran");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickCCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"The checkbox selection is not quite right";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
        [Test]
        public void Negative_Wrong_Dropdown_Selected_in_first_dropdown()
        {
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Danny");
            MainPage.EnterLastName("Beltran");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("4");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"The dropdown selection is not quite right";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
        [Test]
        public void Negative_Wrong_Dropdown_Selected_in_second_dropdown()
        {
            objPage = new MainPage(driver);
            MainPage.EnterFirstName("Danny");
            MainPage.EnterLastName("Beltran");
            MainPage.CleanCheckboxes();
            MainPage.ClickBCheckBox();
            MainPage.ClickPlusCheckBox();
            MainPage.ClickPCheckBox();
            MainPage.SelectFirstDropdown("5");
            MainPage.SelectSecondDropdown("5");
            MainPage.ClickSubmitButton();
            string strActualAlertMsg = MainPage.GetAlertText();
            MainPage.CloseAlert();
            string strExpectedAlertMsg = $"A selection was made other than the default in select list 2";
            Assert.AreEqual(strExpectedAlertMsg, strActualAlertMsg);
        }
    }
}
