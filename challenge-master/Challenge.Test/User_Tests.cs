using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BaseFramework.Rest;
using BaseFramework.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Challenge.Tests
{
    public class User_Tests
    {
        private readonly String baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        Random rand = new Random();

        [Test]
        public void API_GET_Test()
        {
            String endpoint = "/api/v1/employees";
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.GET(endpoint);
            //We should probably do some more assertions here on the response to check that our GET request was successful.   

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(resp.MessageBody);

            DesUserList userList = JsonConvert.DeserializeObject<DesUserList>(resp.MessageBody); //Getting the message body to deserialize the JSON list

            for (int i = 0; i < userList.data.Count; i++)
            {
                Assert.IsNotNull(userList.data.ElementAt(i).id);
                Assert.IsNotNull(userList.data.ElementAt(i).employee_name);
                Assert.IsNotNull(userList.data.ElementAt(i).employee_salary);
                Assert.IsNotNull(userList.data.ElementAt(i).employee_age);
                Console.WriteLine($"ID: {userList.data.ElementAt(i).id}, " +
                    $"Name: {userList.data.ElementAt(i).employee_name}, " +
                    $"Salary: {userList.data.ElementAt(i).employee_salary}, " +
                    $"Age: {userList.data.ElementAt(i).employee_age}, " +
                    $"Profile Image: {userList.data.ElementAt(i).profile_image}");
            }
        }

        [Test]
        public void API_POST_Test()
        {
            String endpoint = "/api/v1/create";
            User user = new User();
            user.name = "Carlos" + rand.Next(999);
            user.salary = "2345" + rand.Next(999);
            user.age = "34";
            string json = JsonConvert.SerializeObject(user);
            Rest rest = new Rest(baseUrl);
            HTTP_RESPONSE resp = rest.POST(endpoint, json);
      
            DesUser userList = JsonConvert.DeserializeObject<DesUser>(resp.MessageBody); //Getting the message body to deserialize the JSON list

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode, $"Expected Status Code {HttpStatusCode.OK}, Received {resp.StatusCode}");
            Assert.IsNotNull(userList.data.id);
            Assert.IsNotNull(userList.data.name);
            Assert.IsNotNull(userList.data.salary);
            Assert.IsNotNull(userList.data.age);
        }
    }
}
    
