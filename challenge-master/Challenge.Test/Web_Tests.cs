using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Challenge.Tests
{
    [TestClass]
    public class Web_Tests 
    {

        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "Juan";
            string strLastName = "Lopez";
            string strLocalMmessage = "Congratulations " + strName + "! Everything was properly populated.";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBoxFalse("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("5");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect '"+ strLocalMmessage + "' and we got '" + objTestMainPAge.strMessage + "'");
            BasePage.TearDown();
        }
        [TestMethod]
        public void MainPage_FirstName_Null_Negative()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "";
            string strLastName = "Lopez";
            string strLocalMmessage = "Please enter a first name";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBoxFalse("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("5");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect 'Please enter a first name' and we got '" + objTestMainPAge.strMessage + "'");
            BasePage.TearDown();
        }
        [TestMethod]
        public void MainPage_LastName_Null_Negative()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "Juan";
            string strLastName = "";
            string strLocalMmessage = "Please enter a last name";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBoxFalse("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("5");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect 'Please enter a last name' and we got '" + objTestMainPAge.strMessage + "'");
            BasePage.TearDown();
        }
        [TestMethod]
        public void MainPage_CheckBoxAllON_Negative()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "Juan";
            string strLastName = "Lopez";
            string strLocalMmessage = "The checkbox selection is not quite right";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBox("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("5");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect 'The checkbox selection is not quite right' and we got '"+ objTestMainPAge.strMessage+"'");
            BasePage.TearDown();
        }
        [TestMethod]
        public void MainPage_FirstDropDown_Negative()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "Juan";
            string strLastName = "Lopez";
            string strLocalMmessage = "The dropdown selection is not quite right";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBoxFalse("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("4");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect 'The checkbox selection is not quite right' and we got '" + objTestMainPAge.strMessage + "'");
            BasePage.TearDown();
        }
        [TestMethod]
        public void MainPage_SecondDropDown_Negative()
        {
            BasePage.SetUp();
            MainPage objTestMainPAge = new MainPage(BasePage.driver);
            string strName = "Juan";
            string strLastName = "Lopez";
            string strLocalMmessage = "A selection was made other than the default in select list 2";
            objTestMainPAge.setFirstName(strName);
            objTestMainPAge.setLastNAme(strLastName);
            objTestMainPAge.setCheckBox("1");
            objTestMainPAge.setCheckBoxFalse("2");
            objTestMainPAge.setCheckBox("3");
            objTestMainPAge.setCheckBox("4");
            objTestMainPAge.setDropDownSelect("5");
            objTestMainPAge.setDropDownNot("5");
            objTestMainPAge.setSubmitButton();
            objTestMainPAge.setMessage(strLocalMmessage);
            Assert.IsTrue(objTestMainPAge.boolMessage, "The test fails we expect 'The checkbox selection is not quite right' and we got '" + objTestMainPAge.strMessage + "'");
            BasePage.TearDown();
        }

    }
}
