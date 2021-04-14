using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Classes;
using Domain.Enums;



namespace Exercise3Animal
{
    class Program
    {
        public static void AllAnimalsAgedFive(List<Animal> animalList)
        {
             if(animalList != null)
            {
                List<string> filteredList = animalList.Where(x => x.Age >= 5).Select(x => x.Name).ToList();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("All the animals aged 5 or more:");
                foreach (string animalName in filteredList)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(animalName);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
            }
        }
        public static void AllAnimalsNameWithA(List<Animal> animalList)
        {
            if (animalList != null)
            {
                List<string> filteredList = animalList.Where(x => x.Name.StartsWith("A")).Select(x => x.Name).ToList();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("All the animals starting with an A:");
               foreach(string animalName in filteredList)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(animalName);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
            }
        }
        public static void AllMaleBrownAnimals(List<Animal> animalList)
        {
            if (animalList != null)
            {
                List<Animal> filteredList = animalList.Where(x => x.Gender == Gender.Male && x.Color == "brown").ToList();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("All male brown animals are:");
                foreach(Animal animal in filteredList)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(animal.Name);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
            }  
        }
        public static Animal FirstAnimalWith10CharsName(List<Animal> animalList)
        {
            if (animalList != null)
            {
                return animalList.FirstOrDefault(x => x.Name.Length > 10);
            }
            return null;
        }
        static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>()
            {
             new Animal("Kaja", "gold", 5, Gender.Female),
            new Animal("Rocky", "white", 2, Gender.Male),
            new Animal("Baron", "brown", 3, Gender.Male),
            new Animal("Blackie", "black", 5, Gender.Male),
            new Animal("Lea", "grey", 6, Gender.Female),
            new Animal("Kala", "black", 7, Gender.Female),
            new Animal("Aja", "gold", 1, Gender.Female),
            new Animal("Ben", "brown", 3, Gender.Male),
            new Animal("Ava", "white", 8, Gender.Female),
            new Animal("Maximillian", "brown", 5, Gender.Male)
        };

            AllAnimalsAgedFive(allAnimals);
            AllAnimalsNameWithA(allAnimals);
            AllMaleBrownAnimals(allAnimals);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First animal with more than 10 chars in its name:");
            Animal animalWith10Chars = FirstAnimalWith10CharsName(allAnimals);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(animalWith10Chars.Name);

            Console.ReadLine();

        }        
        
        }
     
    }

