using Domain2;
using Domain2.Classes;
using System;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All the dogs in the store:");
            PetStoreGeneric<Dog>.PrintPets();

            Console.WriteLine("Enter a dog's name you would like to buy");
            string dogName = Console.ReadLine();
            PetStoreGeneric<Dog>.BuyPet(dogName);

            Console.WriteLine("All the cats in the store:");
            PetStoreGeneric<Cat>.PrintPets();
            Console.WriteLine("Enter a cat's name you would like to buy");
            string catName = Console.ReadLine();
            PetStoreGeneric<Cat>.BuyPet(catName);

            Console.WriteLine("All the fishes in the store:");
            PetStoreGeneric<Fish>.PrintPets();
            Console.WriteLine("Enter a fish's name you would like to buy");
            string fishName = Console.ReadLine();
            PetStoreGeneric<Fish>.BuyPet(fishName);


            Console.ReadLine();
        }
    }
}
