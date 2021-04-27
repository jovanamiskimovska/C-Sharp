using Domain.Classes;
using System;
using System.Collections.Generic;
using Domain.Services;

namespace App
{
    class Program
    {

        static void Main(string[] args)
        {

            var dogType = Services.dogs[0].GetType();
            var catType = Services.cats[0].GetType();


            Services.DogsBark(Services.dogs);
            Services.CatsEat(Services.cats);

            try
            {
                Console.WriteLine("----------------------------------------------------------------------------");
                foreach(Animal animal in Services.allAnimals)
                {
                    if(animal.GetType() == dogType)
                    {
                        ((Dog)animal).Bark();
                    }
                    else if(animal.GetType() == catType)
                    {
                        ((Cat)animal).Eat("fish");
                    }
                    else
                    {
                        throw new Exception("Invalid animal");

                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Bye");
            }

            Console.ReadLine();
        }
    }
}
