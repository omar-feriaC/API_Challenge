using System;
using System.Collections.Generic;
using System.Text;

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
    public class Employee
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class GetEmployee
    {
        public string status { get; set; }
        public List<GetData> data { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }

    public class GetData
    {
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string id { get; set; }
    }

    public class GetEmp
    {
        public string status { get; set; }
        public IList<string> Getdata = new List<string>();
    }
}
