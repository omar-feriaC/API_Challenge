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
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status  {HttpStatusCode.OK}, Received {resp.StatusCode}");
            StringAssert.Contains(resp.MessageBody, "Success", "The answer failed");
            Console.WriteLine(resp.MessageBody);
        }





        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
           
            Data data = new Data();
            data.name = "test";
            data.salary = "123";
            data.age = "23";

          
            string json = JsonConvert.SerializeObject(data);
     
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, json);
            Employee json2 = JsonConvert.DeserializeObject<Employee>(resp.MessageBody);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status  {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.AreEqual("success",json2.status);
            Assert.AreEqual("test", json2.data.name);
            Assert.AreEqual("123", json2.data.salary);
            Assert.IsNotNull(json2.data.id);

            Console.WriteLine(resp.MessageBody);
            
        }

    }
    
}
