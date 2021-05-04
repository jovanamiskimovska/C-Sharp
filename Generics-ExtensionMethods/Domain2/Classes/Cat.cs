using Domain2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain2.Classes
{
    public class Cat : Pet
    {
        public bool IsLazy { get; set; }
        public int LivesLeft { get; set; }
        public Cat(string name, PetType type, int age, bool lazy, int livesLeft) : base(name, type, age)
        {
            IsLazy = lazy;
            LivesLeft = livesLeft;
        }
        public override void PrintInfo()
        {
            if (IsLazy)
            {
                Console.WriteLine($" {Name}, is a lazy {Age} years old {Type} that has {LivesLeft} lives left.");
            }
            else
            {
                Console.WriteLine($"{Name}, is {Age} years old, not a lazy {Type}, that has {LivesLeft} lives left.");
            }
        }
    }
}
