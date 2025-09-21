using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Hotel
    {

        public Hotel(string name)
        {
            Name = name;
            SuitesTypes = new List<string> { "Standard", "Premium", "Deluxe" };
            SeedSuites();
        }

        public string Name { get; set; }
        public List<string> SuitesTypes { get; private set; }

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

        public bool AddSuitesType(string type)
        {
            foreach (var item in SuitesTypes)
            {
                if (item == type)
                {
                    return false;
                }
            }
            SuitesTypes.Add(type);
            return true;
        }

        public bool RemoveSuiteType(string type)
        {
            foreach (var item in SuitesTypes)
            {
                if (item == type)
                {
                    SuitesTypes.Remove(type);
                    return true;
                }
            }
            return false;
        }

        private void SeedSuites() //Running
        {
            if (Suites == null) Suites = new List<Suite>();

            int priceMultiply = 0;

            for (int floor = 1; floor <= 5; floor++)
            {
                priceMultiply += 1;

                decimal price = 100m * priceMultiply;
                string suiteType = "";

                switch (floor)
                {
                    case 1:
                        suiteType = "Standard";
                        break;
                    case 2:
                        suiteType = "Standard";
                        break;
                    case 3:
                        suiteType = "Premium";
                        break;
                    case 4:
                        suiteType = "Premium";
                        break;
                    case 5:
                        suiteType = "Deluxe";
                        break;
                }

                int floorCount = (100 * floor) + 1;

                for (int begin = floorCount; begin <= (floorCount + 7); begin++)
                {
                    Suite suite = new Suite(begin, suiteType, price);

                    if (Suites.Any(s => s.Number == suite.Number))
                    {
                        continue;
                    }

                    Suites.Add(suite);
                }
            }


        }

        public void ShowSuites() //Running
        {
            foreach (Suite suite in Suites)
            {
                Console.WriteLine($"Suite {suite.Number}\n" +
                $"Type: {suite.Type}\n" +
                $"Price per day: {suite.PriceDay:C}\n");
            }
        }

        public void ShowSuitesTypes() //Running
        {
            foreach(var item in SuitesTypes)
            {
                Console.WriteLine(item);
            }
        }
    }

}