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
        public bool RemoveEmployee(string id)
        {
            var check = dict.ContainsKey(id);
            if (check)
                dict.Remove(id);
            return check;        
        }
        public Employee GetEmployee(string id)
        {        
            return dict.ContainsKey(id) ? dict[id] : null;        
        }
        public void UpdateEmployee(Employee update)
        {
            if (dict.ContainsKey(update.Id))
                dict[update.Id] = update;            
        }
    }
}