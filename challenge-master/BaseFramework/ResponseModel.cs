using System;
using System.Collections.Generic;
//using System.Text;
namespace BaseFramework.Model
{
    public class mdlPostEmployee //This model allows to POST a new user in http://dummy.restapiexample.com/api/v1/create
    {
        public String id { get; set; }
        public String name { get; set; }
        public String salary { get; set; }
        public String age { get; set; }
    }
    public class mdlGetPostedEmployee //This model allows to GET a new user POSTED in http://dummy.restapiexample.com/api/v1/create
    {
        public string status { get; set; }
        public mdlPostEmployee data { get; set; }
    }
    public class mdlGetEmployee //This model allows to GET the data of ONE employee in http://dummy.restapiexample.com/api/v1/employee/1
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public class mdlGetEmployees //This model allows to GET a list of employees http://dummy.restapiexample.com/api/v1/employees
    {
        public string status { get; set; }
        public List<mdlGetEmployee> data { get; set; }
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