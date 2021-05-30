using Domain.Models;
using Domain.Services;
using Newtonsoft.Json;
using System;
using System.IO;

namespace App
{
   
    class Program
    {
        public static string FolderPath = @"..\..\..\Data";
        public static string FilePath = FolderPath + "\\data.json";

        static void Main(string[] args)
        {
            Dog[] dogs = new Dog[0];

            FileSystemService fileSystemService = new FileSystemService();

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the name of the DOG:");
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new Exception("Invalid dog's name!");
                    }
                    Console.WriteLine("Enter the color of the DOG:");
                    string color = Console.ReadLine();
                    if (string.IsNullOrEmpty(color))
                    {
                        throw new Exception("Invalid dog's color!");
                    }
                    Console.WriteLine("Enter the age of the DOG:");
                    string age = Console.ReadLine();
                   bool success = int.TryParse(age, out int dogAge);
                    if (!success || dogAge < 1)
                    {
                        throw new Exception("Invalid dog's age!");
                    }

                    Array.Resize(ref dogs, dogs.Length + 1);
                    dogs[dogs.Length - 1] = new Dog()
                    {
                        Id = dogs.Length,
                        Name = name,
                        Age = dogAge,
                        Color = color
                    };
                    Console.WriteLine("Do you want to add another dog? Type 'yes'.");
                    if(Console.ReadLine().ToLower() == "yes")
                    {
                        continue;
                    }
                    Console.WriteLine("========================================================================================================");
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }              
            }

            string JsonString = JsonConvert.SerializeObject(dogs);
            fileSystemService.WriteInFile(FilePath, JsonString);


            Dog[] deserializedDog = JsonConvert.DeserializeObject<Dog[]>(JsonString);

            fileSystemService.PrintDogs(deserializedDog);

            Console.ReadLine();
        }
    }
}
