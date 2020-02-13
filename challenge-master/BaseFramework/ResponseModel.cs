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

    public class DUser
    {
        public string status { get; set; }
        public DataD data { get; set; }
    }
    public class DataD
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }

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
        public string FirstName;
        public string LastName;
        public string SelectDropdown;
        public string NoSelectDropdown;
    }
}
