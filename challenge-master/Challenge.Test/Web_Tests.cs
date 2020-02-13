using System;
using BaseFramework.WebPages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace Challenge.Test
{
    public class Web_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["url"];
        private static IWebDriver driver;
        private static WebDriverWait driverWait;
        MainPage mainPage=null;

        private string strFnResponseToVal = "";
        private string strFirstName = "Jose";
        private string strLastName = "Cruz";
        private string strDropDownOption = "5";
        private string strWrongDropDownOption = "4";
        private string strPositiveToVal = "";
        private string strNoFirstName = "";
        private string strNoLastName = "";
        private string strWrongCheckBox = "";
        private string strWrongDropDownBox = "";
        private string strWrongSecondDropDownBox = "";

        [OneTimeSetUp]
        //SetUp Before each test case
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(driver);
            driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        }
        

        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterFirstName(strFirstName);
                mainPage.fnEnterLasttName(strLastName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strPositiveToVal = mainPage.fnPositiveToVal(strFirstName);
                Assert.AreEqual(strPositiveToVal, strFnResponseToVal);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [Test]
        public void MainPage_First_Name_Empty_Negative()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterLasttName(strLastName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strNoFirstName = mainPage.fnNoFirstName();
                Assert.AreEqual(strNoFirstName, strFnResponseToVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [Test]
        public void MainPage_Last_Name_Empty_Negative()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterFirstName(strFirstName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strNoLastName = mainPage.fnNoLastName();
                Assert.AreEqual(strNoLastName, strFnResponseToVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [Test]
        public void MainPage_Wrong_Checkbox_Selected_Negative()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterFirstName(strFirstName);
                mainPage.fnEnterLasttName(strLastName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckCcheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strWrongCheckBox = mainPage.fnWrongCheckboxChecked();
                Assert.AreEqual(strWrongCheckBox, strFnResponseToVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [Test]
        public void MainPage_Wrong_DropDown_Selected_Negative()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterFirstName(strFirstName);
                mainPage.fnEnterLasttName(strLastName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strWrongDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strWrongDropDownBox = mainPage.fnWronDropDownSelected();
                Assert.AreEqual(strWrongDropDownBox, strFnResponseToVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [Test]
        public void MainPage_Wrong_DropDown_Selected_Second_DropDown_Negative()
        {
            try
            {
                mainPage.fnClearAllFields();
                mainPage.fnEnterFirstName(strFirstName);
                mainPage.fnEnterLasttName(strLastName);
                mainPage.fnCheckBCheckBox();
                mainPage.fnCheckPlusCheckBox();
                mainPage.fnCheckPCheckBox();
                mainPage.fnSelectDropDownSelOpt(strDropDownOption);
                mainPage.fnSelectDropDownNoSel(strDropDownOption);
                mainPage.fnSubmitButton();
                strFnResponseToVal = mainPage.fnReadPopUp();
                strWrongSecondDropDownBox = mainPage.fnWronSecondDropDownSelected();
                Assert.AreEqual(strWrongSecondDropDownBox, strFnResponseToVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }
        [OneTimeTearDown]
        public void AfterTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
