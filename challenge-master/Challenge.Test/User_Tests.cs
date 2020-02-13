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

namespace Challenge.Test
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
            HTTP_RESPONSE_GET resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(resp.Data[0].id, "Expected any value");
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            User user = new User();
            User RespUser = new User(); ;
            user.name = "Juan";
            user.salary = "60000";
            user.age = "38";
            Rest rest = new Rest(baseUrl);
            string body = JsonConvert.SerializeObject(user);
            HTTP_RESPONSE resp = rest.POST(endpoint, body);
           

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(RespUser.id, $"Expected a Value");
            Assert.AreEqual(user.name, resp.Data.name, $"Expected Name {user.name}, Received {resp.Data.name}");
            Assert.AreEqual(user.age, resp.Data.age, $"Expected Age {user.age}, Received {resp.Data.age}");
            Assert.AreEqual(user.salary, resp.Data.salary, $"Expected Salary {user.salary}, Received {resp.Data.salary}");

        }

    }
    
}
