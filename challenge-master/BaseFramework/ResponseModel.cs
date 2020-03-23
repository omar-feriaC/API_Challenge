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
        public String error;
    }
    public class Task
    {
        public string task;
        public string data;
    }
    public class Message
    {
        public String message;
    }

    public class GetResponse
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
    }

}
