using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Hotel
    {

        
        public Hotel()
        {
            List<string> SuitesTypes = new List<string> { "Standard", "Deluxe", "Suite" };
        }
        public List<string> SuitesTypes { get; private set; }
    }
}