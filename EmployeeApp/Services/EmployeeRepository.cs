using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Models;

namespace TestApp.Services
{
    public class EmployeeRepository
    {
        private const string CacheKey = "EntityStorage";
        List<Employee> Employees { get; set; }
        static private Dictionary<string,Employee> dict;
        public EmployeeRepository()
        {
            dict = new Dictionary<string, Employee>();
           
            //var ctx = HttpContext;

            //if (ctx != null)
            //{
            //    if (ctx.Cache[CacheKey] == null)
            //    {
            //        var contacts = new Employee[]{};
            //        ctx.Cache[CacheKey] = contacts;
            //    }
            //}
        }
        //public EmployeeRepository(Employee[] list)
        //{
        //    var ctx = HttpContext.Current;
        //    ctx.Cache[CacheKey] = list;

        //}
        //public Employee[] GetAllEmployees()
        //{
        //    var ctx = HttpContext.Current;
        //    return  ((Employee[])ctx.Cache[CacheKey]).ToArray();
        //}

        public Employee AddEmployee(Employee person)
        {
            //var ctx = HttpContext.Current;
            //var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            person.Id = Guid.NewGuid().ToString();
            //currentData.Add(person);
            //ctx.Cache[CacheKey] = currentData.ToArray();
            dict[person.Id] = person;
            return person;
        }
        //public void RemoveEmployee(string id)
        //{
        //    var ctx = HttpContext.Current;
        //    if (ctx != null)
        //    {
        //        var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
        //        Employee obj = currentData.Find(x => x.Id == id);
        //        currentData.Remove(obj);
        //        ctx.Cache[CacheKey] = currentData.ToArray();

        //        return;
        //    }
        //}
        //public Employee GetEmployee(string id)
        //{
        //    var ctx = HttpContext.Current;
        //    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
        //    return currentData.Find(x => x.Id == id);
        //}
        //public void UpdateEmployee(Employee update)
        //{
        //    var ctx = HttpContext.Current;
        //    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
        //    Employee old = currentData.Find(x => x.Id == update.Id);
        //    currentData.Remove(old);
        //    currentData.Add(update);
        //    ctx.Cache[CacheKey] = currentData.ToArray();
        //}
    }
}