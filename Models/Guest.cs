using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Guest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public decimal Money { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<Suite> Suites { get; set; }

        public void AddSuites(List<Suite> suites)
        {
            foreach (var suite in suites)
            {
                Suites.Add(suite);
            }
        }
    }
}