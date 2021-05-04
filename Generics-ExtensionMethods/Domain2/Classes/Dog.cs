using Domain2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain2.Classes
{
    public class Dog : Pet
    {
        public string FavouriteFood { get; set; }
        public Dog(string name, PetType type, int age, string faveFood):base(name, type, age)
        {
            FavouriteFood = faveFood;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is a {Age} years old {Type} who loves to eat {FavouriteFood}");
        }
    }
}
