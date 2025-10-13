using HotelSystem.Models;
using Microsoft.VisualBasic;

Hotel hotel = new Hotel("Mornigstar Hotel");

bool finish = false;

do
{
    int firstDecision = 0;
    bool createGuest = false;

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
        case 1:
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
                                case 1:
                                    {
                                        hotel.ShowSuites();
                                        continue;
                                    }
                                case 2:
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

                                case 3:

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


                                case 4:
                                    hotel.ShowSuitesTypes();

                                    break;
                                case 5:

                                    bool typeConfirmation = false;
                                    string newSuiteType = "";
                                    do
                                    {

                                        Console.WriteLine("\nPlease, type the new suite type: ");
                                        newSuiteType = Console.ReadLine();

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
                                            Console.WriteLine("\nYou didin't type 'y' or 'n. You will be asked again about the suiite type name.");
                                        }

                                    } while (typeConfirmation == false);

                                    hotel.AddSuitesType(newSuiteType);
                                    break;

                                case 6:

                                    Console.WriteLine("\nAll suites types: ");
                                    int count = 1;

                                    foreach (string type in hotel.SuitesTypes)
                                    {
                                        Console.WriteLine($"\n[{count}] -{type}");
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
                                            hotel.SuitesTypes.RemoveAt(index - 1);
                                            Console.WriteLine("\nThe suite type was removed.");
                                            typeRemoved = true;
                                        }

                                    } while (typeRemoved == false);
                                    break;
                                case 7:
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

        case 2:
            {
                bool inSubmenu = true;

                while (inSubmenu == true)
                {

                    Console.WriteLine("\nPlease, select what you want to do: ");
                    Console.WriteLine(
                        "\n[1] See Reservations" + //Já foi
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
                        case 1:

                            hotel.ShowReservations();
                            break;

                        case 2:
                            {
                                //O que tenho que adicionar para uma nova reserva: Suite (escolher suite), chekout e guest
                                //Escolher suite
                                bool chooseSuite = false;
                                bool chooseCheckout = false;

                                int testDays = 0;


                                do
                                {
                                    Console.WriteLine("\nPlease, type the suite number: ");

                                    string strNumber = Console.ReadLine();

                                    int number = int.TryParse(strNumber, out number) ? number : -1;

                                    foreach (Suite suite in hotel.Suites)
                                    {
                                        if (suite.Number == number)
                                        {
                                            if (suite.Status == true)
                                            {
                                                Console.WriteLine("\nThis suite is currently reserved. Please, try again.");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nSuite {suite.Number} was reserved.");
                                                suite.Status = false;
                                                chooseSuite = true;

                                                testDays = 10;
                                            }
                                        }
                                    }
                                } while (chooseSuite == false);

                                Console.WriteLine(testDays);


                                do
                                {
                                    Console.WriteLine("\nType how many days do you want to reserve this suite: ");
                                    string strDays = Console.ReadLine();

                                    int howManyDays = int.TryParse(strDays, out howManyDays) ? howManyDays : -1;

                                } while (chooseCheckout == false);

                                Guest guest = new Guest();

                                guest = hotel.CreateGuest();

                                break;
                            }
                        case 3:
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