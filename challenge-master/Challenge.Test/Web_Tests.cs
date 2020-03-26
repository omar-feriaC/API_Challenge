using System;
using BaseFramework;
using NUnit.Framework;
using BaseFramework.WebPages;
using System.Threading;

namespace Challenge.Test
{
  
    public class Web_Tests : MainPage

    {
        WebPage objPage;

        [Test]
        public void Positive()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("Hugo");
            WebPage.EnterLastName("Vazquez");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("5");
            WebPage.ClickSubmitButton();
            WebPage.Alert("Congratulations Hugo! Everything was properly populated.");
            WebPage.Refresh();
            

        }
        [Test]
        public void Negative_First_Name_Empty()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("");
            WebPage.EnterLastName("Vazquez");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("5");
            WebPage.ClickSubmitButton();
            WebPage.Alert("Please enter a first name");
            WebPage.Refresh();
           
        }
        [Test]
        public void Negative_Last_Name_Empty()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("Hugo");
            WebPage.EnterLastName("");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("5");
            WebPage.ClickSubmitButton();
            WebPage.Alert("Please enter last name");
            WebPage.Refresh();

        }
        [Test]
        public void Negative_Wrong_Check_Box_Selected()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("Hugo");
            WebPage.EnterLastName("Vazquez");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickCCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("5");
            WebPage.ClickSubmitButton();
            WebPage.Alert("The checkbox selection is not quite right");
            WebPage.Refresh();
        } 
        [Test]
        public void Negative_Wrong_Dropdown_Selected_in_first_dropdown()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("Hugo");
            WebPage.EnterLastName("Vazquez");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("4");
            WebPage.ClickSubmitButton();
            WebPage.Alert("The dropdown selection is not quite righ");
            WebPage.Refresh();

        }
        [Test]
        public void Negative_Wrong_Dropdown_Selected_in_second_dropdown()
        {
            objPage = new WebPage(driver);
            WebPage.EnterFirstName("Hugo");
            WebPage.EnterLastName("Vazquez");
            WebPage.CleanCheckboxes();
            WebPage.ClickBCheckBox();
            WebPage.ClickPlusCheckBox();
            WebPage.ClickPCheckBox();
            WebPage.SelectFirstDropdown("5");
            WebPage.SelectSecondDropdown("5");
            WebPage.ClickSubmitButton();
            WebPage.Alert("A selection was made other than the default in select list 2");
            WebPage.Refresh();
        
        }
    }
}
