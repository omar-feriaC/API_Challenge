using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using BaseFramework.WebPages;
using BaseFramework.Model;

namespace Challenge.Test
{
    [TestClass]
    public class Web_Tests
    {
        static ChromeDriver driver = new ChromeDriver();
        MainPage wpage = new MainPage(driver);

        #region Positive
        [TestMethod]

        public void MainPage_Correct_Selections_Positive()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "Ivan";
            message.LastName = "Rodriguez";
            message.SelectDropdown = "5";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox1();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"Congratulations {message.FirstName}! Everything was properly populated.";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

        #region Negative First Name Empty
        [TestMethod]
        public void MainPage_First_Name_Empty_Negative()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "";
            message.LastName = "Rodriguez";
            message.SelectDropdown = "5";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox1();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"Please enter a first name";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

        #region Negative Last Name Empty
        [TestMethod]
        public void MainPage_Last_Name_Empty_Negative()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "Ivan";
            message.LastName = "";
            message.SelectDropdown = "5";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox1();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"Please enter a last name";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

        #region Negative Wrong Checkbox Selected
        [TestMethod]
        public void MainPage_Wrong_Checkbox_Selected_Negative()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "Ivan";
            message.LastName = "Rodriguez";
            message.SelectDropdown = "5";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox2();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"The checkbox selection is not quite right";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

        #region Negative Wrong Checkbox Selected
        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_First_Negative()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "Ivan";
            message.LastName = "Rodriguez";
            message.SelectDropdown = "4";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox1();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"The dropdown selection is not quite right";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

        #region Negative Wrong Checkbox Selected
        [TestMethod]
        public void MainPage_Wrong_Dropdown_Selected_Second_Negative()
        {
            //Varibles definition 
            Message message = new Message();
            message.FirstName = "Ivan";
            message.LastName = "Rodriguez";
            message.SelectDropdown = "5";
            //Test
            driver.Url = wpage.url;
            wpage.fnInputFirstName(message.FirstName);
            wpage.fnInputLastName(message.LastName);
            wpage.fnClearCheckboxes();
            wpage.fnTicCheckbox1();
            wpage.fnTicCheckbox3();
            wpage.fnTicCheckbox4();
            wpage.fnSelectDropdown1(message.SelectDropdown);
            wpage.fnSelectDropdown2(message.SelectDropdown);
            wpage.fnClickSubmitButton();
            //Handle pupop and message setup
            string alertMessage = driver.SwitchTo().Alert().Text;
            string expectedMessage = $"A selection was made other than the default in select list 2";
            Console.WriteLine($"Expected Alert Message: {expectedMessage}, Actual Message Received: {alertMessage}");
            //Assertion and allow message to be visualized by user
            Assert.AreEqual(alertMessage, expectedMessage);
            System.Threading.Thread.Sleep(1000);
            //Close driver
            driver.Quit();
            driver.Dispose();
        }
        #endregion

    }
}
