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
            GetResponse response;
            String endpoint = "/api/v1/employees"; 
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            response = JsonConvert.DeserializeObject<GetResponse>(resp.MessageBody);
            //We should probably do some more assertions here on the response to check that our GET request was successful.
            Assert.AreEqual("success", response.status, $"Expected success, Received {response.status}");

            Console.WriteLine(resp.MessageBody);
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create/";
            User user = new User();
            user.Name = "Eduardo";
            user.Salary = "100";
            user.Age = "27";

            string serialize = JsonConvert.SerializeObject(user);

            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, serialize);
            //Need some assertions here to check the response.
        }

    }
    
}