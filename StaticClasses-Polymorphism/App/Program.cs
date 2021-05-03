using Domain;
using Domain.Classes;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            
          foreach(Vehicle vehicle in Database.Vehicles)
            {
                if (Validator.Validate(vehicle))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The vehicle was successfully validated");
                    Console.ForegroundColor = ConsoleColor.White;
                    vehicle.PrintVehicle();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unsuccessfull vehicle validation!");
                }
            }

            Console.ReadLine();
        }
    }
}
