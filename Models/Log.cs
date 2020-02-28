using System;
using System.ComponentModel.DataAnnotations;

namespace LogAPI.Models
{
    public class Log
    {   [Key]
        public int Id{get;set;}
        public string Message{get;set;}
        public string created_at{get;set;}
        public  string Type {get;set;}
    }

    

}