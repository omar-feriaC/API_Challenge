using System;
using System.Configuration;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseFramework.clsRest;
using BaseFramework.Model;
using Newtonsoft.Json;
namespace Challenge.Tests
{
    [TestClass]
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        [TestMethod]//GET ALL THE EMPLOYEES TEST
        public void API_GET_Test()
        {
            mdlGetEmployees employeeList;
            String endpoint = "/api/v1/employees";
            clsRest objRest = new clsRest(baseUrl);
            try
            {
                clsHTTP_RESPONSE resp = objRest.fnGET(endpoint);
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
                employeeList = JsonConvert.DeserializeObject<mdlGetEmployees>(resp.strMessageBody);
                foreach (mdlGetEmployee employee in employeeList.data)
                {
                    Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                Assert.Fail();
            }
        }
        [TestMethod]//POST AN EMPLOYEE
        public void API_POST_Test()
        {
            mdlGetPostedEmployee respEmployee;
            String endpoint = "/api/v1/create";
            mdlPostEmployee bodyPostEmployee = new mdlPostEmployee();
            bodyPostEmployee.name = "test";
            bodyPostEmployee.salary = "123";
            bodyPostEmployee.age = "23";
            string strEmployeeBody = JsonConvert.SerializeObject(bodyPostEmployee);
            clsRest objRest = new clsRest(baseUrl);
            try
            {
                clsHTTP_RESPONSE resp = objRest.fnPOST(endpoint, strEmployeeBody);
                respEmployee = JsonConvert.DeserializeObject<mdlGetPostedEmployee>(resp.strMessageBody);
                Console.WriteLine($"Status is: {respEmployee.status}");
                Console.WriteLine($"id: {respEmployee.data.id}, Name: {respEmployee.data.name}, Age: {respEmployee.data.age}");
                Assert.AreEqual("success", respEmployee.status);
                Assert.AreEqual(bodyPostEmployee.name, respEmployee.data.name);
                Assert.AreEqual(bodyPostEmployee.age, respEmployee.data.age);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                Assert.Fail();
            }
        }
    }
}