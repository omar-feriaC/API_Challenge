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
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(resp.MessageBody);
           
            ////We should probably do some more assertions here on the response to check that our GET request was successful.
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            pUser user = new pUser();
            user.name = "Jon";
            user.salary = "10";
            user.age = "21";

            string serlzUser = JsonConvert.SerializeObject(user);

            Rest rest = new Rest(baseUrl);

            //Will be sent to post method in order to have String body=not null POST(end url, data from Post method) 
            HTTP_RESPONSE resp = rest.POST(endpoint, serlzUser);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(resp.MessageBody);

            //Need some assertions here to check the response.
        }

    }
    
}
