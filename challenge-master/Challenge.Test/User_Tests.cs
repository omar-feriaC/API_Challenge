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
using System.Diagnostics;


namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        [TestMethod]
        public void API_GET_Test()
        {
            string userID = "2";
            String endpoint = "/api/v1/employees";
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            var DataDeserialized = JsonConvert.DeserializeObject<MemberGetAllData>(resp.MessageBody);

            GetData userFound = DataDeserialized.data.SingleOrDefault(items => items.id == userID);
            try
            {
                Trace.WriteLine("Id: " + userFound.id);
                Trace.WriteLine("Name: " + userFound.employee_name);
                Trace.WriteLine("Salary: " + userFound.employee_salary);
                Trace.WriteLine("Age: " + userFound.employee_age);
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                Assert.IsNotNull(resp.MessageBody);
            }

            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                Assert.Fail();
            }
        }


        [TestMethod]
        public void API_POST_Test()
        {
            try
            {
                String endpoint = "/api/v1/create";
                User user = new User();
                user.Name = "Mauricio";
                user.Salary = "500";
                user.Age = "32";
                user._id = 18;
                Rest rest = new Rest(baseUrl);
                string strBody = JsonConvert.SerializeObject(user);
                HTTP_RESPONSE resp = rest.POST(endpoint, strBody);
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");

                var DataSerialized = JsonConvert.DeserializeObject<MemberGetData>(resp.MessageBody);
                Trace.WriteLine("Name: " + DataSerialized.data.employee_name);
                Trace.WriteLine("Salary: " + DataSerialized.data.employee_salary);
                Trace.WriteLine("Age: " + DataSerialized.data.employee_age);
                Assert.IsNull(DataSerialized.data.employee_name);
                Assert.IsNull(DataSerialized.data.employee_salary);
                Assert.IsNull(DataSerialized.data.employee_age);
                Assert.IsNotNull(DataSerialized.data.id);
            }

            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

    }
    
}
