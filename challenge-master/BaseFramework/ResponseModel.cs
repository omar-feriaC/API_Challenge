using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class User
    {
        public UInt64 id;
        public string name;
        public string salary;
        public string age;
        //"Data":{"name":"Juan","salary":"127","age":"35","id":57}}
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
