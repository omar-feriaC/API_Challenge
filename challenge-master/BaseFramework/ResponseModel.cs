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

    public class Data
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }

    public class MemberGetData
    {
        public string status { get; set; }
        public GetData data { get; set; }
    }

    public class MemberGetAllData
    {
        public string status { get; set; }
        public GetData[] data { get; set; }
    }

    public class GetData
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
