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

    public class EmployeeGet {
        public string status { get; set; }
        public List<DataGet> data { get; set; }



    }
    public class DataGet {
        public String nameEmp { get; set; }
        public String salaryEmp { get; set; }
        public String ageEmp { get; set; }
        public String id { get; set; }
        public String proimg { get; set; }



    }
}
