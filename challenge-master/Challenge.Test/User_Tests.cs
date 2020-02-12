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
using NUnit.Framework;
using Newtonsoft.Json;

namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [Test]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees"; 
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            NUnit.Framework.Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.       
            Employees objEmployee = JsonConvert.DeserializeObject<Employees>(resp.MessageBody);
            NUnit.Framework.Assert.AreEqual("success", objEmployee.status, $"Expected status operation 'success', Received {objEmployee.status}");
            NUnit.Framework.Assert.AreEqual(24, objEmployee.data.Length, $"Expected employes count 24, Received {objEmployee.data.Length}");

        }


        [Test]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            EmployeeCre objEmployeeCre = new EmployeeCre();
            objEmployeeCre.name = "Edmund Carat";
            objEmployeeCre.salary = "123000";
            objEmployeeCre.age = "33";
            string json = JsonConvert.SerializeObject(objEmployeeCre);
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, json);
            //Need some assertions here to check the response.
            NUnit.Framework.Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            EmployeeRes objEmployeeRes = JsonConvert.DeserializeObject<EmployeeRes>(resp.MessageBody);
            NUnit.Framework.Assert.AreEqual("success", objEmployeeRes.status, $"Expected status operation 'success', Received {objEmployeeRes.status}");
            NUnit.Framework.Assert.AreEqual(objEmployeeCre.name, objEmployeeRes.data.name, $"Expected employee name is {objEmployeeCre.name}, Received {objEmployeeRes.data.name}");
            NUnit.Framework.Assert.AreEqual(objEmployeeCre.salary, objEmployeeRes.data.salary, $"Expected employee salary is {objEmployeeCre.salary}, Received {objEmployeeRes.data.salary}");
            NUnit.Framework.Assert.AreEqual(objEmployeeCre.age, objEmployeeRes.data.age, $"Expected employee age is {objEmployeeCre.age}, Received {objEmployeeRes.data.age}");

        }

    }
    
}
