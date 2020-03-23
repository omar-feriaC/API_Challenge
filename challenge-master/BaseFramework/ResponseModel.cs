using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class User
    {
        public UInt64 _id;
        public String Name;
        public String Salary;
        public String Age;
    }
    public class Error
    {

    }
    public class Task
    {
        public string task;
        public string data;
    }
    public class Message
    {

    }
    //MODEL FOR GET CALL
    public class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public class GetResponse
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
    }
    //MODEL FOR POST CALL
    public class pUser
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }
    public class PostResponse
    {
        public string status { get; set; }
        public pUser data { get; set; }
    }

}
