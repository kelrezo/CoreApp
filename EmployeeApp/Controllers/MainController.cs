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
        const int pagesize = 2;
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
           var worker = employeeRepository.GetEmployee(id);
            if (worker == null)
            {
                var x = HttpContext.Response;
                x.StatusCode = 404;
                return null;
            }
            return worker;
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
        public string Delete(string id)
        {
            timeCardRepository.RemoveTimeCards(id);
            if (!employeeRepository.RemoveEmployee(id))
            {
                var x = HttpContext.Response;
                x.StatusCode = 404;
                //return "Employee unsuccessfully removed, employee with id: " +id";
            }
            return "Employee Successfully removed";
        }

        [HttpPost, Route("{id}/time")]
        public TimeCard PostCard([FromBody] TimeCard time, string id)
        {
            Employee worker = Get(id);
            if (worker == null)
            {
                return null;
            }
            else
            {
               if(worker.Active)
               {
                    time.Id = id;
                    time.Date = DateTime.UtcNow;
                    timeCardRepository.AddTimeCard(time);
                   return time;
                }
                return null;
            }
        }

        [HttpGet, Route("{id}/time")]
        public TimeCard[] GetCard(string id)
        {
            var timeCards = timeCardRepository.GetTimeCards(id);
            if (Get(id) == null ||  timeCards == null)
            {
                var x = HttpContext.Response;
                x.StatusCode = 404;
                return null;
            }
            return timeCards;
        }

        [HttpGet, Route("time")]
        public TimeCard[] GetCards([FromQuery] int start)
        {
            var card = timeCardRepository.GetTimeCards();
            return  card.Skip(pagesize * (start-1)).Take(pagesize).ToArray();
        }
     
    }
}
