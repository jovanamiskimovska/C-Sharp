using Domain2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain2
{
    public static class PetStoreGeneric<T> where T : Pet
    {
        public static List<T> GenericPets { get; set; }
        static PetStoreGeneric()
        {
            GenericPets = new List<T>();
        }
        public static void PrintPets()
        {
            foreach(T pet in GenericPets)
            {
                pet.PrintInfo();
            }
        }
        public static void BuyPet(string name)
        {
            T foundPet = GenericPets.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            if (foundPet == null)
            {
                Console.WriteLine("There is no such pet in the list!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You are a pet owner now! You bought {foundPet.Name}");
                GenericPets.Remove(foundPet);              
            }
        }
    }
}
