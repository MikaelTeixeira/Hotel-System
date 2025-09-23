using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Utils
    {
        public int IntValidate(string input)
        {
            int number = 0;

            int.TryParse(input, out number);

            return number;
        }
    }
}