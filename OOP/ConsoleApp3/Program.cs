using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Auto autoobj = new Auto();

            Console.WriteLine("---Enter a number of desired action without dot-----\n");
            Console.WriteLine("1) Default car atributes");
            Console.WriteLine("2) Enter new car information");
            Console.WriteLine("3) Entering additional car parts into list");
            Console.WriteLine("4) Exit");

            Console.WriteLine("Input Number:");
            int NumberOfChoice = Convert.ToInt32(Console.ReadLine());

            switch (NumberOfChoice)
            {
                case 1:

                    autoobj.Type = "BMW";
                    autoobj.Used = true;
                    autoobj.Price = 250000;
                    autoobj.EngineType = "Diesel";
                    Console.WriteLine("Default car attributes\n");
                    Console.WriteLine("Type of car: " + autoobj.Type + "\n" + "Car price: " + autoobj.Price + "\n" + "Engine type: " + autoobj.EngineType);
                    Console.WriteLine("Engine power: " + autoobj.EnginePower);
                    autoobj.TraveledKM();
                    autoobj.Kilometers = 42000;
                    Console.WriteLine("Passed km: " + autoobj.Kilometers);

                    break;

                case 2:

                    Console.WriteLine("Enter new car information");
                    Console.WriteLine("Enter car type: ");
                    autoobj.Type = Console.ReadLine();
                    Console.WriteLine("Enter car price: ");
                    autoobj.Price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter engine type: ");
                    autoobj.EngineType = Console.ReadLine();
                    Console.WriteLine("Enter engine power in kW: ");
                    autoobj.EnginePower = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unique generated car ID: ");
                    autoobj.DisplayOfCarID();

                    Console.WriteLine("Output of entered data:");
                    Console.WriteLine("Car Type:" + autoobj.Type + "\nPrice:" + autoobj.Price + "\nEngine Type:" + autoobj.EngineType + "\nEngine Power:" + autoobj.EnginePower);

                    break;


                case 3:

                    Console.WriteLine("Enter additional car parts");
                    List<String> CarAcessories = new List<String>();

                    Console.WriteLine("Enter a number of car parts you want to input:");
                    int CarPartsNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter car parts:\n");
                    for (int IterationNumber = 0; IterationNumber < CarPartsNumber; IterationNumber++)
                    {
                        String ListInput = Console.ReadLine();
                        CarAcessories.Add(ListInput);
                    }

                    Console.WriteLine("---Output of entered list data---\n");
                    foreach (var Acessories in CarAcessories)
                    {
                        Console.WriteLine(Acessories);
                    }

                    break;

                case 4:

                    Console.WriteLine("Enter Y for exiting:");
                    string ExitingChoice = Console.ReadLine();

                    if (ExitingChoice == "Y")
                    {
                        Console.WriteLine("cyaa!");
                    }

                    break;
            }

            Console.ReadLine();
        }
    }
}