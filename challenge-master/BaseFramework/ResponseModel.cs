using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.Model
{
    //We probably want to create data models for our different responses


    public class GetPostEmployee
    {
        public string status { get; set; }
        public PostEmployee data { get; set; }
    }
    public class PostEmployee 
    {
        public String id { get; set; }
        public String name { get; set; }
        public String salary { get; set; }
        public String age { get; set; }
    }
    
    public class GetEmployee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public class GetEmployees 
    {
        public string status { get; set; }
        public List<GetEmployee> data { get; set; }
    }
    public class Error
    {
        public String error;
    }
    public class Task
    {
        public string task;
        public string data;
    }
    public class Message
    {
        public String message;
    }
}
