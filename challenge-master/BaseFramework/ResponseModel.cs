using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class User
    {
        public UInt64 id;
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
        public string FirstName;
        public string LastName;
        public string SelectDropdown;
        public string NoSelectDropdown;
    }
}
