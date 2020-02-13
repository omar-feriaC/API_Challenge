using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses
    public class Employee
    {
        public String status;
        public Data data;
    
    }

    public class Data
    {

        public String name;
           
        public String salary;

        public String age;

        public String id;

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
