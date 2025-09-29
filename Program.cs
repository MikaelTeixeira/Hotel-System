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
            "\n[1] Suites" +
            "\n[2] Reservations" +
            "\n[3] Guests" +
            "\n[4] Hotel"+
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
                                bool suiteRemoved = false;

                                do
                                {
                                    Console.WriteLine("\nPlease, type the suite number that you want to remove: ");
                                    string strNumber = Console.ReadLine();
                                    int suiteNumber = int.TryParse(strNumber, out suiteNumber) ? suiteNumber : 0;

                                    foreach (Suite suite in hotel.Suites)
                                    {
                                        if (suite.Number == suiteNumber)
                                        {
                                            hotel.RemoveSuite(suite);
                                            Console.WriteLine($"\nThe suite number {suiteNumber} was removed from hotel.");
                                            break;
                                        }
                                    }
                                    if (suiteRemoved == false)
                                    {
                                        Console.WriteLine("\nSuite not found!\n");
                                    }
                                    
                                } while (suiteRemoved == false);
                                break;
                            case 4:
                                hotel.ShowSuitesTypes();
                                break;
                            case 5:
                                hotel.AddSuitesType();
                                break;
                            case 6:
                                hotel.RemoveSuiteType();
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

        case 2:
            continue;
        case 3:
            continue;
        case 4:
            continue;
    }
} while (!finish);