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
            try
            {
                GetResponse response;
                String endpoint = "/api/v1/employees";
                Rest rest = new Rest(baseUrl);
                HTTP_RESPONSE resp = rest.GET(endpoint);
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                response = JsonConvert.DeserializeObject<GetResponse>(resp.MessageBody);
                foreach (Employee employee in response.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}, Salary: ${employee.employee_salary}");
                }
                Console.WriteLine("******************************************************************");
                Console.WriteLine(resp.MessageBody);
                
                //We should probably do some more assertions here on the response to check that our GET request was successful.
                //added 03/24/2020 8:06 AM
            }
            catch(Exception ex)
            {
                Console.WriteLine("+++++++++++Test Case has failed.+++++++++++");
                Assert.Fail("Execution has failed",ex);
            }

        }


        [TestMethod]
        public void API_POST_Test()
        {
            try
            {
                String endpoint = "/api/v1/create";
                User user = new User();
                user.Name = "Alex TunP";
                user.Salary = 456000.50;
                user.Age = 87;
                Rest rest = new Rest(baseUrl);
                HTTP_RESPONSE resp = rest.POST(endpoint, "{\"name\":\"" + user.Name + "\",\"salary\":\"" + user.Salary + "\",\"age\":\"" + user.Age + "\"}");
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                //Need some assertions here to check the response.
               
            }
            catch(Exception ex)
            {
                Console.WriteLine("+++++++++++Test Case has failed.+++++++++++");
                Console.WriteLine(ex);
                Assert.Fail("Execution has failed", ex);
            }
            
        }

    }
    
}
