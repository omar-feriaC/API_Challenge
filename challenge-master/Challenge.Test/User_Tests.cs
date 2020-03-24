using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using BaseFramework.Rest;
using BaseFramework.Model;
using NUnit.Framework;


namespace Challenge.Tests
{
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        Rest rest;

       [Test]
       
        public void API_GET_Test()
        {
            try
            {
                rest = new Rest(baseUrl);
                String endpoint = "/api/v1/employees";
                HTTP_RESPONSE resp = rest.GET(endpoint);
                EmployeeRes EmployeeData = rest.DeserializeEmployeeData(resp.MessageBody.ToString());
                Console.WriteLine(EmployeeData.status);
                foreach (var x in EmployeeData.data)
                {
                    Console.WriteLine("ID: " + x.id);
                    Console.WriteLine("Name: " + x.employee_name);
                    Console.WriteLine("Salary: " + x.employee_salary);
                    Console.WriteLine("<------------------->");
                }

                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                Assert.AreEqual("success", EmployeeData.status, $"Expected success, Received {EmployeeData.status}");
                Assert.IsTrue(EmployeeData.data != null);
            }

            catch(Exception e) 
            {
                Console.WriteLine("An error occurred ...." + e.Message);
            }
        }

        [Test]
        public void API_POST_Test()
        {
            
            
                rest = new Rest(baseUrl);
                String endpoint = "/api/v1/create";
                DataReq data = new DataReq();
                data.name = "Hugo";
                data.salary = "123456";
                data.age = "28";
                string jsonData = rest.SerializeEmployeeData(data);
                HTTP_RESPONSE resp = rest.POST(endpoint, jsonData);
                Console.WriteLine(resp.MessageBody);

                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            
        }
    }
}