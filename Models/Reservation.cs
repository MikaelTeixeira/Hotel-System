using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Reservation
    {
        public int Id { get; }

        public Suite Suite { get; private set; }

        public Guest Guest { get; private set; }

        public DateTime CheckIn { get; private set; }

        public DateTime CheckOut { get; private set; }

        public Reservation(int id, Suite suite, Guest guest, DateTime checkIn, DateTime checkOut)
        {
            Id = id;
            Suite = suite;
            Guest = guest;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }


        public bool UpdateReservationTime(int days)
        {

            int negativeDays = (CheckOut - CheckIn).Days * -1;

            if (days == 0)
            {
                Console.WriteLine("\nYou can't select 0 days. If you want to cancel your reservation, please, select it at the menu.");
                return false;
            }
            else if (days < negativeDays)
            {
                Console.WriteLine("\nYou can't reduce more days than remain to your resevation. If you want to cancel your reservation, please, select it at the menu.");
                return false;
            }
            else
            {
                CheckOut = CheckOut.AddDays(days);
                Console.WriteLine("\nOkay, your checkout was updated to date: " + CheckOut.ToString("dd/MM/yyyy"));
                return true;
            }
        }

        
    }
}