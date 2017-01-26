using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Models;
using Microsoft.AspNetCore.Http;

namespace TestApp.Services
{
    public class TimeCardRepository
    {
        static private List<TimeCard> TimeCards { get; set; }
        public TimeCardRepository()
        {
            TimeCards = new List<TimeCard>();
        }
        public TimeCard AddTimeCard(TimeCard time)
        {
            TimeCards.Add(time);
            return time;
        }
        public TimeCard[] GetTimeCards(string id = null)
        {
            if (id == null)
                return TimeCards.OrderBy(x => x.Date).ToArray();

            var array = TimeCards.FindAll(x => x.Id == id);
            return array.OrderBy(x => x.Date).ToArray();
        }
        public void RemoveTimeCards(string id)
        {
                TimeCards.RemoveAll(x => x.Id == id);      
        }
    }
}