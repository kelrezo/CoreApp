using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestApp.Models;

namespace TestApp.Services
{
    public class EmployeeRepository
    {
        static private Dictionary<string, Employee> dict { get; set; }
        public EmployeeRepository()
        {
            dict = new Dictionary<string, Employee>();

        }
        public Employee[] GetAllEmployees()
        {
            return dict.Values.ToArray();
        }

        public Employee AddEmployee(Employee person)
        {
            person.Id = Guid.NewGuid().ToString();
            dict[person.Id] = person;
            return person;
        }
        public void RemoveEmployee(string id)
        {
            dict.Remove(id);          
        }
        public Employee GetEmployee(string id)
        {
            return dict[id];
        }
        public void UpdateEmployee(Employee update)
        {
            dict[update.Id] = update;
        }
    }
}