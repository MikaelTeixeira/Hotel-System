using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Hotel.Models
{
    public class Suite
    {
        public Suite(int number, string type, decimal pricePerDay)
        {
            this.Number = number;
            this.Type = type;
            this.PriceDay = pricePerDay;
        }

        public Suite()
        { Status = true; }

        public int Number { get; }
        public string Type { get; private set; }
        
        public decimal PriceDay { get; private set; }

        public bool Status { get; set; }


        public bool UpdatePrice(decimal newPrice)
        {
            if (newPrice > 0)
            {
                PriceDay = newPrice;
                return true;
            }

            return false;
        }
    }
}