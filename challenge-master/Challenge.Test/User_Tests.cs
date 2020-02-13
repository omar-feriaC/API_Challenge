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
        
        #region API GET Test
        [TestMethod]
        public void API_GET_Test()
        {
            try 
            { 
                String endpoint = "/api/v1/employee/2"; 
                Rest rest = new Rest(baseUrl);
                HTTP_RESPONSE resp = rest.GET(endpoint);
                //We should probably do some more assertions here on the response to check that our GET request was successful.
                //Simple assertion to ensure status returned ok with a response
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                Console.WriteLine(resp.MessageBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
        #endregion

        #region API Post Test
        [TestMethod]
        public void API_POST_Test()
        {
            try
            {
                String endpoint = "/api/v1/create";
                User user = new User();
                user.name = "Ivan";
                user.salary = "321";
                user.age = "35";
                string json = JsonConvert.SerializeObject(user);
                Rest rest = new Rest(baseUrl);
                HTTP_RESPONSE resp = rest.POST(endpoint, json);
                //Need some assertions here to check the response.
                DUser uList = JsonConvert.DeserializeObject<DUser>(resp.MessageBody);
                //Assetions
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code: {HttpStatusCode.OK}, Received: {resp.StatusCode}");
                Assert.IsNotNull(uList.data.id);
                Assert.AreEqual(user.name, uList.data.name);
                Assert.AreEqual(user.salary, uList.data.salary);
                Assert.AreEqual(user.age, uList.data.age);
                //Results Printed
                Console.WriteLine(resp.StatusCode);
                Console.WriteLine(uList.data.name);
                Console.WriteLine(uList.data.salary);
                Console.WriteLine(uList.data.age);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
        #endregion
    }

}
