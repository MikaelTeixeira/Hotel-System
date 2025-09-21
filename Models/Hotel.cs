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

        public string Name { get; set; }

        public double Rate { get; private set; }

        public List<Suite> Suites { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Guest> Guests { get; private set; }

        public bool AddReservation(Reservation reservation)
        {
            foreach (var item in Reservations)
            {
                if (item == reservation)
                {
                    return false;
                }
            }
            Reservations.Add(reservation);
            return true;
        }

        public bool RemoveReservation(Reservation reservation)
        {
            foreach (var item in Reservations)
            {
                if (item.Suite == reservation.Suite)
                {
                    Reservations.Remove(reservation);
                    return true;
                }
            }
            return false;
        }

        public bool AddSuite(Suite suite)
        {
            foreach (var room in Suites)
            {
                if (room.Number == suite.Number)
                {
                    return false;
                }
            }

            Suites.Add(suite);
            return true;
        }

        public bool RemoveSuite(Suite suite)
        {
            foreach (var item in Suites)
            {
                if (item.Number == suite.Number)
                {
                    Suites.Remove(suite);
                    return true;
                }
            }
            return false;
        }

        public bool AddGuest(Guest guest)
        {
            foreach (var people in Guests)
            {
                if (people.CPF == guest.CPF)
                {
                    return false;
                }
            }

            Guests.Add(guest);
            return true;
        }

        public bool RemoveGuest(Guest guest)
        {
            foreach (var people in Guests)
            {
                if (people.CPF == guest.CPF)
                {
                    Guests.Remove(guest);
                    return true;
                }
            }
            return false;
        }


    }
}