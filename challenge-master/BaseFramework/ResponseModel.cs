using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class EmployeeCre
    {
        //public UInt64 _id;
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

    public class Employees
    {
        public string status { get; set; }
        public data[] data;
    }

    public class data
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class EmployeeRes
    {
        public string status { get; set; }
        public data2 data;
    }

    public class data2
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }
}
