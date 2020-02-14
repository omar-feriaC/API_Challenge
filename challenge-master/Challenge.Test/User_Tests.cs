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
        Rest res;

        [TestMethod]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees"; 
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            res = new Rest(endpoint);
            //We should probably do some more assertions here on the response to check that our GET request was successful.
            Console.WriteLine(resp.MessageBody);
            EmployeeGet EmpGetDesSerialized = JsonConvert.DeserializeObject<EmployeeGet>(resp.MessageBody);
            for (int i = 0; i < EmpGetDesSerialized.data.Count ; i++)
            {
                if(i == 1)
                {
                    Assert.IsNotNull(EmpGetDesSerialized.data.ElementAt(i).id);
                    Assert.IsNotNull(EmpGetDesSerialized.data.ElementAt(i).nameEmp);
                    Assert.IsNotNull(EmpGetDesSerialized.data.ElementAt(i).salaryEmp);
                    Assert.IsNotNull(EmpGetDesSerialized.data.ElementAt(i).ageEmp);
                    Assert.AreEqual(EmpGetDesSerialized.data.ElementAt(i).proimg, "");
                    Assert.AreEqual(EmpGetDesSerialized.data.ElementAt(i).id, "2");
                    Assert.AreEqual(EmpGetDesSerialized.data.ElementAt(i).nameEmp, "Garrett Winters"); 
                    Assert.AreEqual(EmpGetDesSerialized.data.ElementAt(i).salaryEmp, "170750"); 
                    Assert.AreEqual(EmpGetDesSerialized.data.ElementAt(i).ageEmp, "63");
                }
            }
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            User user = new User();
            user.name = "Rodrigo";
            user.salary = "1";
            user.age = "12";
            Rest rest = new Rest(baseUrl);

            string serUser = JsonConvert.SerializeObject(user);

            HTTP_RESPONSE resp = rest.POST(endpoint, serUser);
            //Need some assertions here to check the response.
            Console.WriteLine(resp.MessageBody);
        }

    }
    
}
