using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BaseFramework.Rest;
using BaseFramework.Model;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Challenge.Tests
{
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [Test]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees";

            Rest restCall = new Rest(baseUrl);

            HTTP_RESPONSE resp = restCall.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.

            EmployeeGet EmpGetDesSerialized = JsonConvert.DeserializeObject<EmployeeGet>(resp.MessageBody);
            try
            {
                for (int i = 0; i < EmpGetDesSerialized.data.Count; i++)
                {
                    if (i == 1)
                    {
                        Console.WriteLine("Id: " + EmpGetDesSerialized.data.ElementAt(i).id);
                        Console.WriteLine("Name: " + EmpGetDesSerialized.data.ElementAt(i).employee_name);
                        Console.WriteLine("Salary: " + EmpGetDesSerialized.data.ElementAt(i).employee_salary);
                        Console.WriteLine("Age: " + EmpGetDesSerialized.data.ElementAt(i).employee_age);
                        Console.WriteLine("Profile Image: " + EmpGetDesSerialized.data.ElementAt(i).profile_image);
                        Assert.AreEqual("2", EmpGetDesSerialized.data.ElementAt(i).id);
                        Assert.AreEqual("Garrett Winters", EmpGetDesSerialized.data.ElementAt(i).employee_name);
                        Assert.AreEqual("170750", EmpGetDesSerialized.data.ElementAt(i).employee_salary);
                        Assert.AreEqual("63", EmpGetDesSerialized.data.ElementAt(i).employee_age);

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
                user.name = "Alejandro";
                user.salary = "1";
                user.age = "20";
                Rest rest = new Rest(baseUrl);
                String jsUser = JsonConvert.SerializeObject(user);
                HTTP_RESPONSE resp = rest.POST(endpoint, jsUser);
                Console.WriteLine(resp.MessageBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail();
            }

        }

    }

}