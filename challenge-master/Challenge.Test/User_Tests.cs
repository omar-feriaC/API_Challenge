using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseFramework.Rest;
using BaseFramework.Model;
using Newtonsoft.Json;

namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [TestMethod]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees";
            Rest objrest = new Rest(baseUrl);
            GetEmployees employeeList;

            try
            {
                HTTP_RESPONSE resp = objrest.GET(endpoint);
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                employeeList = JsonConvert.DeserializeObject<GetEmployees>(resp.MessageBody);
                foreach (GetEmployee employee in employeeList.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void API_POST_Test()
        {
            GetPostEmployee respEmployee;
            String endpoint = "/api/v1/create";
            PostEmployee user = new PostEmployee();
            user.name = "test";
            user.salary = "123";
            user.age = "23";
            Rest objrest = new Rest(baseUrl);
            string strUser = JsonConvert.SerializeObject(user);
            //Need some assertions here to check the response.

            try
            {
                HTTP_RESPONSE resp  = objrest.POST(endpoint, strUser);
                respEmployee = JsonConvert.DeserializeObject<GetPostEmployee>(resp.MessageBody);
                Console.WriteLine($"Status is: {respEmployee.status}");
                Console.WriteLine($"id: {respEmployee.data.id}, Name: {respEmployee.data.name}, Age: {respEmployee.data.age}");
                Assert.AreEqual("success", respEmployee.status);
                Assert.AreEqual(user.name, respEmployee.data.name);
                Assert.AreEqual(user.age, respEmployee.data.age);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                Assert.Fail();
            }
        }

    }
    
}
