using Domain2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain2.Classes
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public Enum Type { get; set; }
        public int Age { get; set; }
        public Pet(string name, PetType type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
        public abstract void PrintInfo();
    }
}
