using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services;
using TestApp.Models;
using Microsoft.AspNetCore.Http;

namespace BasicApi.Controllers
{
    [Route("employees")]
    public class MainController : Controller
    {
        private static EmployeeRepository employeeRepository = new EmployeeRepository();
        private static TimeCardRepository timeCardRepository = new TimeCardRepository();
        public MainController()
        {
                  
        }

        [HttpGet, Route("")]
        public Employee[] GetAll()
        {
            return employeeRepository.GetAllEmployees();
        }

        [HttpGet, Route("{id}")]
        public Employee Get(string id)
        {
            return employeeRepository.GetEmployee(id);
        }

        [HttpPut, Route("{id}")]
        public void Put(string id, [FromBody]Employee person)
        {
            person.Id = id;
            employeeRepository.UpdateEmployee(person);
        }

        [HttpPost, Route("")]
        public Employee Post([FromBody]Employee value)
        {
            return employeeRepository.AddEmployee(value);
        }

        [HttpDelete, Route("{id}")]
        public void Delete(string id)
        {
            timeCardRepository.RemoveTimeCards(id);
            employeeRepository.RemoveEmployee(id);
        }

        [HttpPost, Route("{id}/time")]
        public TimeCard PostCard([FromBody] TimeCard time, string id)
        {
            Employee worker = Get(id);
            if (worker.Active)
            {
                time.Id = id; 
                time.Date = DateTime.UtcNow;
                timeCardRepository.AddTimeCard(time);
            }
            return time;
        }

        [HttpGet, Route("{id}/time")]
        public TimeCard[] GetCard(string id)
        {
            return timeCardRepository.GetTimeCards(id);
        }

        [HttpGet, Route("time")]
        public TimeCard[] GetCards()
        {
            return timeCardRepository.GetTimeCards();
        }
    }
}
