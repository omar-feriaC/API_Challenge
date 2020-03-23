using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using BaseFramework.Rest;
using BaseFramework.clsRest;
using BaseFramework.Model;
namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        [TestMethod]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employee/2";
            clsRest objRest = new clsRest(baseUrl);
            HTTP_RESPONSE resp = objRest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.
        }
        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create/";
            User user = new User();
            user.Name = "";
            user.Salary = "";
            user.Age = "";
            //Rest rest = new Rest(baseUrl);
            clsRest objRest = new clsRest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, "");
            //Need some assertions here to check the response.
        }

    }
    
}
