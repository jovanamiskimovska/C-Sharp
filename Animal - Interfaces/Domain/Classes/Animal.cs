using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
  public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public abstract void PrintAnimal();
        public Animal(string name, string color, int age)
        {
            Name = name;
            Color = color;
            Age = age;
        }
    }
}
