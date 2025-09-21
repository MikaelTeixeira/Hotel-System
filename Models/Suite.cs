using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Suite
    {
        public Suite(int number, string type, decimal priceDay)
        {
            this.Number = number;
            this.Type = type;
            this.PriceDay = priceDay;
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

        public bool UpdateStatus(bool newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
                return true;
            }

            return false;
        }

        public bool UpdateType(Hotel nomeHotel, string newType)
        {
            foreach (var suite in nomeHotel.SuitesTypes)
            {
                if (string.Equals(suite, newType, StringComparison.OrdinalIgnoreCase))
                {
                    Type = newType;
                    return true;
                }
            }

            return false;
        }

        
    }
    
}