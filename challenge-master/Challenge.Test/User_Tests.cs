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
        private readonly String baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");

        [TestMethod]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees"; 
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            GetResponse userResponse = JsonConvert.DeserializeObject<GetResponse>(resp.MessageBody);
            Console.WriteLine("");
            foreach (Employee employee in userResponse.data)
            {
                Assert.IsNotNull(employee.id);
                Assert.IsNotNull(employee.employee_name);
                Assert.IsNotNull(employee.employee_salary);
                Assert.IsNotNull(employee.employee_age);
                Assert.IsNotNull(employee.profile_image);

               Console.WriteLine($"ID: {employee.id}  Name: {employee.employee_name}  Salary: {employee.employee_salary}  Age: {employee.employee_age}  Profile Image: {employee.profile_image}");
            }

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            //We should probably do some more assertions here on the response to check that our GET request was successful.
        }


        [TestMethod]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            User user = new User();
            user.name = "Hector Castillo";
            user.salary = "1000";
            user.age = "25";
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, $"{{ \"name\" : \"{user.name}\", \"salary\" : \"{user.salary}\" , \"age\" : \"{user.age}\" }}");
            PostReponse userResponse = JsonConvert.DeserializeObject<PostReponse>(resp.MessageBody);

            //Need some assertions here to check the response.
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.AreEqual($"{{ \"name\" : \"{user.name}\", \"salary\" : \"{user.salary}\" , \"age\" : \"{user.age}\" }}", $"{{ \"name\" : \"{userResponse.data.name}\", \"salary\" : \"{userResponse.data.salary}\" , \"age\" : \"{userResponse.data.age}\" }}");
            Console.WriteLine("");
            Assert.IsNotNull(userResponse.data.id);
            Console.WriteLine("User Id: " + userResponse.data.id);
            Console.WriteLine("");
            Assert.IsNotNull(userResponse.data.name);
            Console.WriteLine("User Name: " + userResponse.data.name);
            Console.WriteLine("");
            Assert.IsNotNull(userResponse.data.salary);
            Console.WriteLine("User Salary: " + userResponse.data.salary);
            Console.WriteLine("");
            Assert.IsNotNull(userResponse.data.age);
            Console.WriteLine("User Age: " + userResponse.data.age);
            Console.WriteLine("");
            Console.WriteLine($"Expected response: " + $"{{ \"name\" : \"{user.name}\", \"salary\" : \"{user.salary}\" , \"age\" : \"{user.age}\" }}" +  " " + "Actual Response: " + $"{{ \"name\" : \"{userResponse.data.name}\", \"salary\" : \"{userResponse.data.salary}\" , \"age\" : \"{userResponse.data.age}\" }}");
        }

    }

    class GetResponse
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }

    }

    class Employee
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public double employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }

    class PostReponse
    {
        public string status { get; set; }
        public User data { get; set; }
    }
}
