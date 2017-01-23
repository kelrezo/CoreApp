using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services;
using TestApp.Models;

namespace BasicApi.Controllers
{
    [Route("employees")]
    public class MainController : Controller
    {
        private EmployeeRepository EmployeeRepository { get; }
        private TimeCardRepository TimeCardRepository { get; }
        public MainController()
        {
            this.EmployeeRepository = new EmployeeRepository();
            this.TimeCardRepository = new TimeCardRepository();
        }

        //[HttpGet, Route("")]
        //public Employee[] GetAll()
        //{
        //    return this.EmployeeRepository.GetAllEmployees();
        //}
        [HttpGet, Route("")]
        public string GetAll()
        {
            return "Hello word";
        }

        //[HttpGet, Route("{id}")]
        //public Employee Get(string id)
        //{
        //    return this.EmployeeRepository.GetEmployee(id);
        //}

        //[HttpPut, Route("{id}")]
        //public void Put(string id, [FromBody]Employee person)
        //{
        //    person.Id = id;
        //    this.EmployeeRepository.UpdateEmployee(person);
        //}

        [HttpPost, Route("")]
        public Employee Post([FromBody]Employee value)
        {
            //return this.EmployeeRepository.AddEmployee(value);
            return value;
        }

        //[HttpDelete, Route("{id}")]
        //public void Delete(string id)
        //{
        //    this.TimeCardRepository.RemoveTimeCards(id);
        //    this.EmployeeRepository.RemoveEmployee(id);
        //}
        //[HttpPost, Route("{id}/time")]
        //public TimeCard PostCard([FromBody] TimeCard time, string id)
        //{
        //    //var ctx = HttpContext.Current;
        //    //var data = ctx.Request;
        //    Employee worker = Get(id);
        //    if (worker.Active)
        //    {
        //        time.Id = id;
        //        //time.Date = ctx.Timestamp;
        //        this.TimeCardRepository.AddTimeCard(time);
        //    }
        //    return time;
        //}
        //[HttpGet, Route("{id}/time")]
        //public TimeCard[] GetCard(string id)
        //{
        //    return this.TimeCardRepository.GetTimeCards(id);
        //}
        //[HttpGet, Route("time")]
        //public TimeCard[] GetCards()
        //{
        //    return this.TimeCardRepository.GetTimeCards();
        //}
    }
}
