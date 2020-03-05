using System;
using BaseFramework.WebPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Challenge.Test
{
    public class Web_Tests
    {
        public MainPage LoginPage;
        public static IWebDriver driver;
        public static readonly string url = "http://ztestqa.com/selenium/mainpage.html";

        [SetUp]
        public void SetUpTc() {
            driver = new ChromeDriver();
            driver.Url = url;
            LoginPage = new MainPage(driver);
        }
        [Test]
        public void MainPage_Correct_Selections_Positive() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("Testing");
            LoginPage.EnterLastName("QA");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.SelectDropDown1("5");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("Testing");
            LoginPage.Refresh();
        }
        [Test]
        public void MainPage_FirstName_Empty_Negative() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("");
            LoginPage.EnterLastName("QA");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.SelectDropDown1("5");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("Please enter a first name");
            LoginPage.Refresh();

        }
        [Test]
        public void MainPage_LasttName_Empty_Negative() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("Testing");
            LoginPage.EnterLastName("");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.SelectDropDown1("5");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("Please enter a last name");
            LoginPage.Refresh();

        }
        [Test]
        public void MWrong_CheckBox_Selected_Negative() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("Testing");
            LoginPage.EnterLastName("QA");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.ClickCBox();
            LoginPage.SelectDropDown1("5");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("The checkbox selection is not quite right");
            LoginPage.Refresh();

        }
        [Test]
        public void MWrong_Dropdown1_Selected_Negative() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("Testing");
            LoginPage.EnterLastName("QA");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.SelectDropDown1("4");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("The dropdown selection is not quite right");
            LoginPage.Refresh();

        }
        [Test]
        public void MWrong_Dropdown2_Selected_Negative() {
            Utils.AssertIsPresent(LoginPage.GetSingInButton());
            LoginPage.EnterFirstName("Testing");
            LoginPage.EnterLastName("QA");
            LoginPage.CleanButtons();
            LoginPage.ClickBBox();
            LoginPage.ClickPlusBox();
            LoginPage.ClickPBox();
            LoginPage.SelectDropDown1("5");
            LoginPage.SelectDropDown2("5");
            LoginPage.ClickSubmitBtn();
            LoginPage.Alert("A selection was made other than the default in select list 2");
            LoginPage.Refresh();

        }

        [TearDown]
        public void closeBrowser() {
            driver.Quit();
        }
    }
}
