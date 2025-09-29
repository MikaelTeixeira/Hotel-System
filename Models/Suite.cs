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

        public bool ValidateNumber(int number, Hotel hotel)
        {

            string numberString = number.ToString();

            if (numberString.Length != 3)
            {
                Console.WriteLine("\nThe Suite number must have 3 digits.");
                return false;
            }

            else if (numberString[2] > '9' || numberString[2] < 1)
            {
                Console.WriteLine("\nThe suite number is out of range. It must finish between 1 and 9.");
                return false;
            }

            foreach (var suite in hotel.Suites)
            {
                if (suite.Number == number)
                {
                    Console.WriteLine("\nThis suite number is alredy registered.");
                    return false;
                    
                }
            }
            return true;
        }

        public bool ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                return false;
            }
            return true;
        }
        
        // ATRIBUTES VALIDATIONS \\

        public static bool TypeValidate(string type, Hotel hotel)
        {
            if (hotel.SuitesTypes.Contains(type))
            {
                return true;
            }
            Console.WriteLine("\nType not found!\nPlease, select a valid type or add a new one.");
            return false;
        }

        public static bool NumberValidate(int number, Hotel hotel)
        {
            foreach (var suite in hotel.Suites)
            {

                if (number.ToString().EndsWith("0") || number.ToString().EndsWith("9") || number < 0 || number > 908)
                {
                    Console.WriteLine("\nThis number is not allowed!");
                    Console.WriteLine("\nSuites number must end with a number between 1 and 8 and can't be bigger or smaller than 3 digits.\nExamples: 101, 208, 307....");
                    return false;
                }

                if (suite.Number == number)
                {
                    Console.WriteLine("\nThis suite already exists!");
                    return false;
                }
            }
                return true;
        }

        public static decimal PriceDefine(string type)
        {
            switch (type)
            {
                case "Standard":
                    return 100m;
                case "Premium":
                    return 150m;
                case "Deluxe":
                    return 200m;
                default:
                    return 0m;
            }
        }

    }
}
