using HotelSystem.Models;
using Microsoft.VisualBasic;

Hotel hotel = new Hotel("Mornigstar Hotel");

bool finish = false;

do
{
    int firstDecision = 0;
    
    do
    {

        Console.WriteLine($"\nwelcome to {hotel.Name}!\n");

        Console.WriteLine("\nPlease, select the area that you want to view or change something:\n");

        Console.WriteLine(
            "\n[1] Suites" + //JÁ FOI
            "\n[2] Reservations" +
            "\n[3] Guests" +
            "\n[4] Hotel" +
            "\n[5] Exit");

        string input = Console.ReadLine();

        if (int.TryParse(input, out firstDecision))
        {
            if (firstDecision >= 1 && firstDecision <= 5)
            {
                break;
            }
            Console.WriteLine("\nPlease, select a number between 1 and 5.");
        }
        else
        {
            Console.WriteLine("\nPlease, type a valid number.");
        }
        continue;
    } while (firstDecision < 1 || firstDecision > 5);

    switch (firstDecision)
    {
        case 1:  //FEITO
            {
                bool inSubmenu = true;
                while (inSubmenu)
                {

                    Console.WriteLine("\nOkay, now select what do you want to do:\n");

                    Console.WriteLine(
                        "\n[1] See Suites" +
                        "\n[2] Add Suite" +
                        "\n[3] Remove Suite" +
                        "\n[4] See Suites Types" +
                        "\n[5] Add Suite Type" +
                        "\n[6] Remove Suite Type" +
                        "\n[7] Return.\n");

                    string input2 = Console.ReadLine();

                    if (int.TryParse(input2, out int secondDecision))
                    {
                        if (secondDecision >= 1 && secondDecision <= 7)
                        {
                            switch (secondDecision)
                            {
                                case 1: //FEITO
                                    {
                                        hotel.ShowSuites();
                                        continue;
                                    }

                                case 2: //FEITO
                                    {
                                        bool isNumberValid = false;
                                        bool isTypeValid = false;
                                        string typeAnswer = "";
                                        int number = 0;

                                        //Number block
                                        do
                                        {
                                            Console.WriteLine("\nPlease, type the new suite Number: ");

                                            string numberAnswer = Console.ReadLine();

                                            number = int.TryParse(numberAnswer, out number) ? number : 0;

                                            if (Suite.NumberValidate(number, hotel))
                                            {
                                                isNumberValid = true;
                                            }

                                        } while (isNumberValid == false);

                                        //Type block
                                        do
                                        {
                                            Console.WriteLine("\nPlease, type the new suite type: ");
                                            typeAnswer = Console.ReadLine();

                                            if (Suite.TypeValidate(typeAnswer, hotel))
                                            {
                                                isTypeValid = true;
                                            }

                                        } while (isTypeValid == false);

                                        decimal newSuitePrice = Suite.PriceDefine(typeAnswer);

                                        Suite suite = new Suite(number, typeAnswer, newSuitePrice);

                                        hotel.AddSuite(suite);

                                        Console.WriteLine($"\nSuite number {suite.Number} was added in hotel.");
                                        break;
                                    }

                                case 3: //FEITO

                                    {
                                        bool suiteRemoved = false;
                                        bool cantRemove = false;
                                        bool exit = false;
                                        do
                                        {
                                            Console.WriteLine("\nPlease, type the suite number that you want to remove or type 'exit' to return: ");
                                            string strNumber = Console.ReadLine();

                                            if (strNumber.ToLower() == "exit")
                                            {
                                                break;
                                            }

                                            int suiteNumber;

                                            if (!int.TryParse(strNumber, out suiteNumber))

                                            {
                                                suiteNumber = 0;
                                            }

                                            foreach (Suite suite in hotel.Suites)
                                            {
                                                if (suite.Number == suiteNumber)
                                                {
                                                    if (suite.Status == true)
                                                    {
                                                        Console.WriteLine("\nThis suite is currently reserved. Please, try delete this suite when the reservation is over.");
                                                        cantRemove = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        hotel.RemoveSuite(suite);
                                                        suiteRemoved = true;
                                                        Console.WriteLine($"\nThe suite number {suiteNumber} was removed from hotel.");
                                                        break;
                                                    }
                                                }
                                            }

                                            if (suiteRemoved == false && cantRemove == false)
                                            {
                                                Console.WriteLine("\nSuite not found!\n");
                                            }

                                            if (suiteRemoved == true || cantRemove == true)
                                            {
                                                exit = true;
                                            }

                                        } while (exit == false);
                                        break;
                                    }

                                case 4: //FEITO
                                    hotel.ShowSuitesTypes();

                                    break;
                                
                                case 5: //FEITO

                                    bool typeConfirmation = false;
                                    bool priceConfirmation = false;
                                    string suiteTypeName = "";
                                    decimal suiteTypePrice = 0;
            
                                    do
                                    {

                                        Console.WriteLine("\nPlease, type the new suite type: ");
                                        suiteTypeName = Console.ReadLine();

                                        Console.WriteLine("\nAre you sure you want to add this type? (y/n)");
                                        string newTypeConfirmation = Console.ReadLine();

                                        if (newTypeConfirmation.ToLower() == "y")
                                        {

                                            typeConfirmation = true;
                                        }
                                        else if (newTypeConfirmation.ToLower() == "n")
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou didin't type 'y' or 'n. You will be asked again about the suite type name.");
                                            continue;
                                        }

                                    } while (typeConfirmation == false);

                                    do
                                    {
                                        Console.WriteLine("\nPlease, type the new suite type price per day: ");
                                        string newSuiteTypePriceStr = Console.ReadLine();

                                        if (decimal.TryParse(newSuiteTypePriceStr, out suiteTypePrice))
                                        {
                                            priceConfirmation = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou didin't type a valid price. You will be asked again about the suite type price.");
                                        }
                                    } while (priceConfirmation == false);



                                    hotel.AddSuitesType(suiteTypeName, suiteTypePrice);
                                    break;

                                case 6: //FEITO

                                    Console.WriteLine("\nAll suites types: ");
                                    int count = 1;

                                    foreach (var item in hotel.SuitesTypes)
                                    {
                                        Console.WriteLine($"\n[{count}] -{item.Key}");
                                        count++;
                                    }

                                    bool typeRemoved = false;

                                    do
                                    {
                                        Console.WriteLine("\nSelect the suite type that you want to remove: ");
                                        string typeToRemove = Console.ReadLine();
                                        int index = int.TryParse(typeToRemove, out index) ? index : -1;

                                        if (index <= hotel.SuitesTypes.Count && index >= 0)
                                        {
                                            hotel.RemoveSuiteType(hotel.SuitesTypes.ElementAt(index - 1 ).Key);
                                            Console.WriteLine("\nThe suite type was removed.");
                                            typeRemoved = true;
                                        }

                                    } while (typeRemoved == false);
                                    break;
                                
                                case 7: //FEITO
                                    inSubmenu = false;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease, type a valid number.");
                    }
                }

                break;
            }

        case 2: //feito
            {
                bool inSubmenu = true;

                while (inSubmenu == true)
                {

                    Console.WriteLine("\nPlease, select what you want to do: ");
                    Console.WriteLine(
                        "\n[1] See Reservations" + //FEITO 
                        "\n[2] Add Reservation" +
                        "\n[3] Remove Reservation" +
                        "\n[4] Return.\n");
                    Console.WriteLine("Select: ");
                    string decision = Console.ReadLine();
                    int decisionNumber;
                    decisionNumber = int.TryParse(decision, out decisionNumber) ? decisionNumber : -1;

                    if (decisionNumber <= 0 || decisionNumber > 4)
                    {
                        Console.WriteLine("\nPlease, type a valid number (a number between 1 and 4).");
                        continue;
                    }

                    switch (decisionNumber)
                    {
                        case 1: //feito

                            hotel.ShowReservations();
                            break;

                        case 2: //feito
                            {

                                bool chooseSuite = false; //Já foi
                                bool chooseCheckout = false;

                                int? suiteNumber = null;
                                DateTime checkout = new DateTime();

                                Suite reservationSuite = null;

                                decimal pricePerDay = 0;



                                do
                                {
                                    Console.WriteLine("\nPlease, type the suite number: ");

                                    string strNumber = Console.ReadLine();

                                    int number = int.TryParse(strNumber, out number) ? number : -1;

                                    foreach (Suite suite in hotel.Suites)
                                    {
                                        if (suite.Number == number)
                                        {

                                            Console.WriteLine($"\nSuite status: {suite.Status}");
                                            if (suite.Status == true)
                                            {
                                                Console.WriteLine("\nThis suite is currently reserved. Please, try again.");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nSuite {suite.Number} was reserved.");
                                                suite.Status = false;

                                                reservationSuite = suite;

                                                chooseSuite = true;

                                                pricePerDay = suite.PriceDay;

                                                suiteNumber = number;
                                            }
                                        }
                                    }
                                } while (chooseSuite == false);


                                int howManyDays = 0;

                                do
                                {
                                    Console.WriteLine("\nType how many days do you want to reserve this suite: ");
                                    string strDays = Console.ReadLine();

                                    howManyDays = int.TryParse(strDays, out howManyDays) ? howManyDays : -1;

                                    DateTime today = DateTime.Now;

                                    checkout = Utils.doCheckout(howManyDays, today);

                                    chooseCheckout = Utils.validateCheckout(checkout.Day);

                                    if (chooseCheckout == false)
                                    {
                                        Console.WriteLine("\nPlease, type a valid number of days.");
                                    }


                                } while (chooseCheckout == false);

                                Guest guest = new Guest();

                                guest = hotel.CreateGuest();

                                decimal totalPrice = Utils.CalculatePrice(howManyDays, pricePerDay);

                                int id = hotel.Reservations.Count + 1;
                                DateTime checkin = DateTime.Now;



                                Reservation reservation = new Reservation(id, reservationSuite, guest, checkin, checkout, totalPrice);

                                hotel.Reservations.Add(reservation);
                            }

                            break;

                        case 3: //feito
                            hotel.ShowReservations();

                            Console.WriteLine("\nSelect the reservation that you want to remove: ");
                            string reservationToRemove = Console.ReadLine();
                            int index = int.TryParse(reservationToRemove, out index) ? index : -1;

                            if (index <= hotel.Reservations.Count && index >= 0)
                            {
                                Reservation reservation = hotel.Reservations.ElementAt(index - 1);
                                hotel.RemoveReservation(reservation);

                                Console.WriteLine("\nThe reservation was removed.");
                            }

                            break;
                        case 4:
                            inSubmenu = false;
                            break;

                        default:
                            break;
                    }
                }
                break;

            }
        
        case 3:
            continue;
        case 4:
            continue;
    }
} while (!finish);