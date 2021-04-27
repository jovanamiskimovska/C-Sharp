using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class Cat : Animal, ICat
    {
        public string CatRace { get; set; }
        public void Eat(string food)
        {
            Console.WriteLine($"The {CatRace} cat named {Name} is eating her favourite food - {food}");
        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"{CatRace} - named {Name}, has {Age} years and has {Color} fur");
        }
        public Cat(string name, string color, int age, string race) : base(name, color, age)
        {
            CatRace = race;
        }
    }
}
