using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseFramework.Model;
using BaseFramework.Rest;



namespace Challenge.Test
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [TestMethod]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employee/2";
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, 
                resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            GetResponse response = JsonConvert.DeserializeObject<GetResponse>(resp.MessageBody);
            Assert.AreEqual("success", response.status, $"Expected success, Received {response.status}");
            Console.WriteLine(resp.MessageBody);
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create/";
            User user = new User
            {
                Name = "Alfonso",
                Salary = "1000",
                Age = "34"
            };
            

            string serialize = JsonConvert.SerializeObject(user);

            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, "");            
        }

    }

}