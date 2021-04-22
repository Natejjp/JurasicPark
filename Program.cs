using System;
using System.Linq;
using System.Collections.Generic;

namespace JurasicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public DateTime DateAcquired { get; set; } = DateTime.Now;

        public string Description()
        {
            var newDescription = $"Name: {Name} Diet: {DietType} Acquired: {DateAcquired} Weight: {Weight} Enclosure: {EnclosureNumber}";
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

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do? View the dinosaurs, Add the dinosaurs, Remove a dinosaur, Transfer a dinosaur, Summary of the dinosaurs, or Quit "); var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    keepGoing = false;
                }

                else if (choice == "V")
                {
                    foreach (var pineapple in dinosaurs)
                    {
                        Console.Write(pineapple.Description());
                    }

                    var view = dinosaurs.OrderBy(s => s.DateAcquired);
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
                    var transfer = PromptForString("What dinosaur would you like to transfer? ");
                    Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(s => s.Name == transfer);
                    if (foundDinosaur == null)
                    {
                        Console.WriteLine("No dinosaur by that name dummy");
                    }
                    else
                    {
                        var newEnclosure = PromptForInteger($"What {transfer} new enclosure number? ");
                        foundDinosaur.EnclosureNumber = newEnclosure;
                    }
                }

                else if (choice == "S")
                {
                    var herb = PromptForString("Would you like a summary of the herbivore and carnivores? ");
                    var foundHerb = dinosaurs.Where(s => s.DietType == "herbivore").Count();
                    var foundCarn = dinosaurs.Count(s => s.DietType == "herbivore");
                    Console.WriteLine($"There are {foundHerb} herbivores and {foundCarn} carnivore!");
                }

                else
                {
                    dinosaur.Name = PromptForString("What is the dinosaur name? ");
                    dinosaur.DietType = PromptForString("What is the dinosaur DietType? Herbivore or Carnivore? ");
                    dinosaur.Weight = PromptForInteger("What is the weight of the dinosaur? ");
                    dinosaur.EnclosureNumber = PromptForInteger("What is the enclosure number? ");

                    dinosaurs.Add(dinosaur);
                }
            }
        }

    }
}