using System;
using System.Linq;
using System.Collections.Generic;

namespace JurasicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

        public string Description()
        {
            var newDescription = $"This Dino is called {Name} they are a {DietType}. We got them {WhenAcquired} and weigh {Weight} and are kept in enclosure {EnclosureNumber}";
            return newDescription;
        }

    }

    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("This is not valid input. Using 0 ");
                return 0;
            }
        }


        static void Main(string[] args)
        {
            var dinosaurs = new List<Dinosaur>();

            var dinosaur = new Dinosaur();

            dinosaur.Name = PromptForString("What is the dinosaur name? ");
            dinosaur.DietType = PromptForString("What is the dinosaur DietType? ");
            // dinosaur.WhenAcquired = PromptForInteger("When did we acquire this dinosaur? ");
            dinosaur.Weight = PromptForInteger("What is the weight of the dinosaur");
            dinosaur.EnclosureNumber = PromptForInteger("What is the enclosure number? ");

            dinosaurs.Add(dinosaur);

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("What would you like to do? (V)iew the dinosaurs, Add the dinosaurs, Remove a dinosaur, (T)ransfer a dinosaur, Summary of the dinosaurs, or (Q)uit ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    keepGoing = false;
                }

                else if (choice == "V")
                {
                    Console.Write("mango");
                }

                else if (choice == "R")
                {
                    var name = PromptForString("Which dinosaur would you like to remove? ");
                    Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(s => s.Name == name);
                    if (foundDinosaur == null)
                    {
                        Console.WriteLine("No dinosaurs under that name to remove");
                    }
                    else
                    {
                        dinosaurs.Remove(foundDinosaur);
                        Console.WriteLine($"{name} went extinct sadface ");
                    }
                }

                else if (choice == "T")
                {
                    Console.WriteLine("Transferred my guy");
                }

                else if (choice == "S")
                {
                    Console.WriteLine("Summaried bruh");
                }

                else
                {
                    dinosaur.Name = PromptForString("What is the dinosaur name? ");
                    dinosaur.DietType = PromptForString("What is the dinosaur DietType? ");
                    dinosaur.WhenAcquired = DateTime.Now;
                    dinosaur.Weight = PromptForInteger("What is the weight of the dinosaur? ");
                    dinosaur.EnclosureNumber = PromptForInteger("What is the enclosure number? ");

                    dinosaurs.Add(dinosaur);
                }
            }
        }

    }
}