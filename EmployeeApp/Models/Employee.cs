using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace TestApp.Models
{

    public class Employee
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}