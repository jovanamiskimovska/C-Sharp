using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class Dog :Animal, IDog
    {
        public string DogRace { get; set; }

        public Dog(string name, string color, int age, string race):base(name, color, age)
        {
            DogRace = race;
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"{DogRace} - named {Name}, has {Age} years and has {Color} fur");
        }

        public void Bark()
        {
            Console.WriteLine($"The {DogRace} named {Name} says: Bark Bark");
        }

    }
}
