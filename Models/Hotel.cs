using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using HotelSystem.Models;

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

            Console.Write("\nSuites Types:\n");
            foreach (var item in SuitesTypes)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowReservations()
        {
            foreach (var item in Reservations)
            {
                Console.WriteLine($"{item.Suite.Number} - remaining days: {item.RemainingDays}");
            }
        }
    
        public Guest CreateGuest()
        {
            Guest guest = new Guest();
            bool createdName = false;
            bool createdCPF = false;
            bool createdMoney = false;

            do
            {
                Console.WriteLine("\nPlease, type your name: ");
                guest.Name = Console.ReadLine();

                bool nameCheck = Utils.onlyLetters(guest.Name);

                if (nameCheck == true)
                {
                    createdName = true;
                }
                else
                {
                    Console.WriteLine("\nPlease, type a valid name.");
                    continue;
                }

            } while (createdName == false);

            do
            {
                Console.WriteLine("\nPlease, type your CPF: ");
                guest.CPF = Console.ReadLine();

                if (Utils.checkCPF(guest.CPF) == true)
                {
                    createdCPF = true;
                }
                else
                {
                    Console.WriteLine("\nPlease, type a valid CPF.");
                    continue;
                }

            } while (createdCPF == false);

            do
            {
                Console.WriteLine("\nPlease, type how much money you have: ");
                guest.Money = Convert.ToDecimal(Console.ReadLine());

                if (Utils.checkMoney(guest.Money) == true)
                {
                    createdMoney = true;
                }
                else
                {
                    Console.WriteLine("\nPlease, type a valid amount of money.");
                    continue;
                }

            } while (createdMoney == false);
                       
            return guest;
        }

    }

}