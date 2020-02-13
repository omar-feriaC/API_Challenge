using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests:BaseTest
    {
        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("Daniel");
            MainPage.fnEnterLName("Luna");
            MainPage.fnCheckboxes(true, false, true, true);
            MainPage.fnDDSelection(5);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(0), MainPage.fnAlert()); 
        }

        [Test]
        public void MainPage_Negative_FirstName_Empty()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("");
            MainPage.fnEnterLName("Luna");
            MainPage.fnCheckboxes(true, false, true, true);
            MainPage.fnDDSelection(5);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(1), MainPage.fnAlert());
        }

        [Test]
        public void MainPage_Negative_LastName_Empty()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("Daniel");
            MainPage.fnEnterLName("");
            MainPage.fnCheckboxes(true, false, true, true);
            MainPage.fnDDSelection(5);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(2), MainPage.fnAlert());
        }

        [Test]
        public void MainPage_Negative_WrongCheckbox_Selected()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("Daniel");
            MainPage.fnEnterLName("Luna");
            MainPage.fnCheckboxes(true, true, true, true);
            MainPage.fnDDSelection(5);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(3), MainPage.fnAlert());
        }

        [Test]
        public void MainPage_Negative_WrongFirstDropdown_Selected()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("Daniel");
            MainPage.fnEnterLName("Luna");
            MainPage.fnCheckboxes(true, false, true, true);
            MainPage.fnDDSelection(4);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(4), MainPage.fnAlert());
        }

        [Test]
        public void MainPage_Negative_WrongSecondDropdown_Selected()
        {
            MainPage objMainPage = new MainPage(driver);
            MainPage.fnClearAll();
            MainPage.fnEnterFName("Daniel");
            MainPage.fnEnterLName("Luna");
            MainPage.fnCheckboxes(true, false, true, true);
            MainPage.fnDDSelection(5);
            MainPage.fnDDNoSelection(5);
            MainPage.fnClickSubmit();
            NUnit.Framework.Assert.AreEqual(MainPage.fnAlertMessages(5), MainPage.fnAlert());
        }


    }
}
