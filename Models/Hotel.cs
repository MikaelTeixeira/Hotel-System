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
            this.Name = name;
            this.SuitesTypes = new Dictionary<string, decimal> { { "Standard", 100m }, { "Premium", 150m }, { "Deluxe", 200m } };
            SeedSuites();
            this.Reservations = new List<Reservation>();
            this.Guests = new List<Guest>();
        }

        public string Name { get; set; }
        public Dictionary<string, decimal> SuitesTypes { get; private set; }

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
                    Console.WriteLine("\nThis guest already exists.");
                    return false;
                }
            }

            Guests.Add(guest);
            Console.WriteLine("\nGuest added.");
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

        public bool AddSuitesType(string name, decimal price)
        {
            if (SuitesTypes.ContainsKey(name))
            {
                Console.WriteLine("\nThis suite type already exists.");
                return false;
            }
            else
            {
                SuitesTypes.Add(name, price);
                return true;
            }
        }

        public bool RemoveSuiteType(string name)
        {
            return SuitesTypes.Remove(name);
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
                switch (suiteType)
                {
                    case "Standard":
                        break;
                    case "Premium":
                        break;
                    case "Deluxe":
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
            if (Reservations.Count == 0)
            {

                Console.WriteLine("\nThere are no reservations.");

                return;
            }

            int count = 1;

            foreach (var item in Reservations)
            {
                Console.WriteLine($"[{count}]Suite Number: {item.Suite.Number} - remaining days: {item.RemainingDays}");
                count++;
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

        public Reservation GetReservation(string guestCPF)
        {
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Guest.CPF == guestCPF)
                {
                    return reservation;
                }
            }

            Console.WriteLine("\nReservation not found");
            return null;
        }

        public void ShowGuests()
        {

            if (this.Guests.Count == 0)
            {
                Console.WriteLine("\nThere are no guests.");
                return;
            }
            int count = 1;
            foreach (Guest guest in Guests)
            {
                Reservation reservation = GetReservation(guest.CPF);
                Console.WriteLine("===============================================================");
                Console.WriteLine($"\nGUEST NUMBER {count}");
                count++;
                Console.WriteLine($"\nName: {guest.Name}" +
                $"\nSuite: {reservation.Suite.Number}" +
                $"\nRemaining days: {reservation.RemainingDays}");
                Console.WriteLine("===============================================================");
            }
            return;
        }

        public void ShowInformations()
        {
            int numberOfSuites = this.Suites.Count;
            int numberOfSuiteTypes = this.SuitesTypes.Count;


            Console.WriteLine("\nHotel informations:\n");
            Console.WriteLine($"\nHotel name: {this.Name}");
            Console.WriteLine($"\n: Number of suites: {numberOfSuites}");
            Console.WriteLine($"\n: Number of suite types: {numberOfSuiteTypes}");
        }

        public bool ChangeName(string name)
        {
            this.Name = name;
            return true;
        }

        
    }

}