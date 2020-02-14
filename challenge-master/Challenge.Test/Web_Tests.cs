using System;
using BaseFramework.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Challenge.Test
{
    //[TestClass]
    public class Web_Tests
    {
        MainPage mainPage = null;


        [Test]
        public void MainPage_Correct_Selections_Positive()
        {
            
            try
            {
                mainPage.fnEnterFirstN("Jose");
                mainPage.fnEnterLastN("Novelo");
                mainPage.fnClickB("Y");
                mainPage.fnClickC("N");
                mainPage.fnClickPlus("Y");
                mainPage.fnClickP("Y");
                mainPage.fnSelFirstDropdownOpt("5");
                //mainPage.fnSelSecondDropdownOpt("5");
                mainPage.fnClickSubmit();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Assert.Fail();
            }
            
        }

        [Test]
        public void MainPage_First_Name_Empty()
        {

        }

        [Test]
        public void MainPage_Last_Name_Empty()
        {

        }

        [Test]
        public void MainPage_Wrong_CheckBox_Selected()
        {

        }

        [Test]
        public void MainPage_Wrong_Dropdown_Selected_1()
        {

        }

        [Test]
        public void MainPage_Wrong_Dropdown_Selected_2()
        {

        }








    }
}
