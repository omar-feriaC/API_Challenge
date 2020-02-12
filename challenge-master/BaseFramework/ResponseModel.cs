﻿using Newtonsoft.Json;
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
    public class DesUser
    {
        public string status { get; set; }
        public Data data { get; set; }

    }
    public class Data
    {
        public string name { get; set; }
        public int salary { get; set; }
        public int age { get; set; }
        public int id { get; set; }
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
