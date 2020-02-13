using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using BaseFramework.Rest;
using BaseFramework.Model;
using System.Net;
using System.Configuration;

namespace Challenge.Test
{
    [TestClass]
    public class REST_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [TestMethod]
        public void Objective_3_Task1_Positive()
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
