using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class User
    {

        public UInt64 _id;
        public String name;
        public String salary;
        public String age;
    }
    public class Employee
    {
        public string status { get; set; }

        public Data data { get; set; }

    }
    public class Data
    {
        public string name { get; set; }

        public string salary { get; set; }

        public string age { get; set; }

        public string id { get; set; }
    }
    public class EmployeeGet
    {
        public string status { get; set; }
        public List<DataGet> data { get; set; }

    }
    public class DataGet
    {
        public String employee_name { get; set; }
        public String employee_salary { get; set; }
        public String employee_age { get; set; }
        public String id { get; set; }
        public String profile_image { get; set; }

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
}
