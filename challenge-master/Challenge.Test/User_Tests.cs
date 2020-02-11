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
using System.IO;
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
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            User user = new User();
            user.name = "test";
            user.salary = "123";
            user.age = "23";
            Rest rest = new Rest(baseUrl);
            String jsonUser = JsonConvert.SerializeObject(user);
            HTTP_RESPONSE resp = rest.POST(endpoint, jsonUser);
            //Need some assertions here to check the response.
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Employee DesJson = JsonConvert.DeserializeObject<Employee>(resp.MessageBody);
            Assert.IsNotNull(DesJson.data.name);
            Assert.AreEqual(user.name, DesJson.data.name);
            Console.WriteLine("Employee Name Posted: " + DesJson.data.name);
            Assert.IsNotNull(DesJson.data.salary);
            Assert.AreEqual(user.salary, DesJson.data.salary);
            Console.WriteLine("Employee Salary Posted: " + DesJson.data.salary);
            Assert.IsNotNull(DesJson.data.age);
            Assert.AreEqual(user.age, DesJson.data.age);
            Console.WriteLine("Employee Age Posted: " + DesJson.data.age);
            Assert.IsNotNull(DesJson.data.id);
            Console.WriteLine("ID of the call: " + DesJson.data.id);
        }

    }
    
}
