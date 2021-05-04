using Domain2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain2.Classes
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public double Size { get; set; }
        public Fish(string name, PetType type, int age, string color, double size):base(name, type, age)
        {
            Color = color;
            Size = size;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is a {Color}, {Age} years old {Type} that is sized: {Size}");
        }
    }
}
