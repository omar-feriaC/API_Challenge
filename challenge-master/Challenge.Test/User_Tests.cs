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

namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");

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
            user.Name = "test";
            user.Salary = "123";
            user.Age = "23";
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, $"{{ \"name\" : \"{user.Name}\", \"salary\" : \"{user.Salary}\" , \"age\" : \"{user.Age}\" }}");

            //Need some assertions here to check the response.
        }

    }
    
}
