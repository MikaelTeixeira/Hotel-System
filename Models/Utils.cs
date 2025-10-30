using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using System.ComponentModel.Design;
namespace HotelSystem.Models
{
    public class Utils
    {
        public static bool onlyLetters(string value)
        {


            if (Regex.IsMatch(value, @"^[A-Za-zÀ-ÖØ-öø-ÿ]+$"))
            {
                return true;
            }
            return false;
        }

        public static bool checkCPF(string value)
        {

            if (Regex.IsMatch(value, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") && value.Length == 14)
            {
                return true;
            }

            else if (value.Length == 11 && value.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        public static bool checkMoney(decimal value)
        {
            if (value <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool validateCheckout(int value)
        {
            if (value <= 0)
            {
                return false;
            }
            return true;
        }

        public static DateTime doCheckout(int value, DateTime CheckIn)
        {
            DateTime CheckOut = CheckIn.AddDays(value);

            return CheckOut;
        }

        public static decimal CalculatePrice(int totalDays, decimal pricePerDay)
        {

            decimal totalPrice = pricePerDay * totalDays;

            if (totalPrice > 0)
            {
                return totalPrice;
            }

            Console.WriteLine("\nAn error occured.");
            return 0;
        }

    }


}