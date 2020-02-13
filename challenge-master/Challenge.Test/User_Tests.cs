using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseFramework.Rest;
using BaseFramework.Model;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
//using Microsoft.VisualC.StlClr;

namespace Challenge.Tests
{
    //[TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [Test]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees"; //to get all the employees, the validations will be made for member id 2
            String strEmpId = "2";
            String strEmpName = "Garrett Winters";
            String strEmpSalary = "170750";
            String strEmpAge = "63";
            String strEmpProfileImage = "";

            Rest restCall = new Rest(baseUrl);
            
            HTTP_RESPONSE resp = restCall.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.

            EmployeeGet EmpGetDesSerialized = JsonConvert.DeserializeObject<EmployeeGet>(resp.MessageBody);
            try
            {
                for (int i = 0; i < EmpGetDesSerialized.data.Count; i++)
                {
                    if (i == 1)//because the exercise asked for member id 2
                    {
                        Console.WriteLine("Employee Id is: " + EmpGetDesSerialized.data.ElementAt(i).id);
                        Console.WriteLine("Employee Name is: " + EmpGetDesSerialized.data.ElementAt(i).employee_name);
                        Console.WriteLine("Employee Salary is: " + EmpGetDesSerialized.data.ElementAt(i).employee_salary);
                        Console.WriteLine("Employee Age is: " + EmpGetDesSerialized.data.ElementAt(i).employee_age);
                        Console.WriteLine("Employee Profile Image is: " + EmpGetDesSerialized.data.ElementAt(i).profile_image);
                        Assert.AreEqual(strEmpId, EmpGetDesSerialized.data.ElementAt(i).id);
                        Assert.AreEqual(strEmpName, EmpGetDesSerialized.data.ElementAt(i).employee_name);
                        Assert.AreEqual(strEmpSalary, EmpGetDesSerialized.data.ElementAt(i).employee_salary);
                        Assert.AreEqual(strEmpAge, EmpGetDesSerialized.data.ElementAt(i).employee_age);
                        Assert.AreEqual(strEmpProfileImage, EmpGetDesSerialized.data.ElementAt(i).profile_image);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }
        }


        [Test]
        public void API_POST_Test()
        {
            try
            {
                String endpoint = "/api/v1/create";
                User user = new User();
                user.name = "test";
                user.salary = "123";
                user.age = "23";
                user._id = 0;
                Rest rest = new Rest(baseUrl);
                String jsonUser = JsonConvert.SerializeObject(user);
                HTTP_RESPONSE resp = rest.POST(endpoint, jsonUser);
                //Need some assertions here to check the response.
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");

                Employee jDesUser = JsonConvert.DeserializeObject<Employee>(resp.MessageBody);
                Console.WriteLine("Name is: " + jDesUser.data.name);
                Console.WriteLine("Salary is: " + jDesUser.data.salary);
                Console.WriteLine("Age is: " + jDesUser.data.age);

                Assert.IsNotNull(jDesUser.data.id);
                Assert.IsNotNull(jDesUser.data.name);
                Assert.IsNotNull(jDesUser.data.salary);
                Assert.IsNotNull(jDesUser.data.age);
                Assert.AreNotEqual(jDesUser.data.id, user._id);
                Assert.AreEqual(jDesUser.data.name, user.name);
                Assert.AreEqual(jDesUser.data.salary, user.salary);
                Assert.AreEqual(jDesUser.data.age, user.age);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }

        }

    }
    
}
