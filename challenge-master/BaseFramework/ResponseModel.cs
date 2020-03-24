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

    public class EmployeeReq
    {
        public string status { get; set; }
        public DataReq[] data;
       
    }

    public class DataReq
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
    }

    public class EmployeeRes
    {
        public string status { get; set; }
        public DataRes[] data;
       
    }
    public class DataRes
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
}