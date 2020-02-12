using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BaseFramework.WebPages;
using BaseFramework.Model;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        static ChromeDriver driver = new ChromeDriver();
        MainPage page = new MainPage(driver);

        [TestMethod]
        public void MainPage_Correct_Selections_Positive()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.LastName = "Castillo";
            message.SelectDropdown = "5";

            driver.Url = page.url;
            page.fnAddFirstName(message.FirstName);
            page.fnAddLastName(message.LastName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"Congratulations {message.FirstName}! Everything was properly populated.";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);
           

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_FirstName_Empty_Negative()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.LastName = "Castillo";
            message.SelectDropdown = "5";

            driver.Url = page.url;
            page.fnAddLastName(message.LastName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = "Please enter a first name";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_LastName_Empty_Negative()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.SelectDropdown = "5";

            driver.Url = page.url;
            page.fnAddFirstName(message.FirstName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = "Please enter a last name";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_Wrong_Checkbox_Selected_Negative()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.LastName = "Castillo";
            message.SelectDropdown = "5";

            driver.Url = page.url;
            page.fnAddFirstName(message.FirstName);
            page.fnAddLastName(message.LastName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnC();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = "The checkbox selection is not quite right";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_Negative()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.LastName = "Castillo";
            message.SelectDropdown = "4";

            driver.Url = page.url;
            page.fnAddFirstName(message.FirstName);
            page.fnAddLastName(message.LastName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = "The dropdown selection is not quite right";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);

            driver.Quit();
        }

        [TestMethod]
        public void MainPage_Wrong_Second_Dropdown_Selected_Negative()
        {
            Message message = new Message();
            message.FirstName = "Hector";
            message.LastName = "Castillo";
            message.SelectDropdown = "5";
            message.NoSelectDropdown = "5";

            driver.Url = page.url;
            page.fnAddFirstName(message.FirstName);
            page.fnAddLastName(message.LastName);
            page.fnClearCheckBox();
            page.fnClickCheckbtnB();
            page.fnClickCheckbtnPlus();
            page.fnClickCheckbtnP();
            page.fnSelectDropdown(message.SelectDropdown);            
            page.fnNoSelectDropdown(message.NoSelectDropdown);
            page.fnClickSubmitBtn();

            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = "A selection was made other than the default in select list 2";
            Console.WriteLine($"Expected Message: {expectedMessage} --- Actual Message: {alertMessage}");
            Assert.AreEqual(alertMessage, expectedMessage);

            driver.Quit();
        }
    }
}
