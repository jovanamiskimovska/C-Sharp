using Domain2;
using Domain2.Classes;
using System;
using Domain2.Enums;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Kaja", PetType.Dog, 5, "Chicken");
            Dog dog2 = new Dog("Ben", PetType.Dog, 2, "Peanut-butter");

            Cat cat1 = new Cat("Smiti", PetType.Cat, 3, true, 9);
            Cat cat2 = new Cat("White", PetType.Cat, 5, false, 3);

            Fish fish1 = new Fish("Nemo", PetType.Fish, 5, "yellow", 5);
            Fish fish2 = new Fish("Dory", PetType.Fish, 3, "orange", 2.55);

            PetStoreGeneric<Dog>.GenericPets.Add(dog1);
            PetStoreGeneric<Dog>.GenericPets.Add(dog2);
            PetStoreGeneric<Cat>.GenericPets.Add(cat1);
            PetStoreGeneric<Cat>.GenericPets.Add(cat2);
            PetStoreGeneric<Fish>.GenericPets.Add(fish1);
            PetStoreGeneric<Fish>.GenericPets.Add(fish2);

            Console.ResetColor();
            Console.WriteLine("All the dogs in the store:");
            PetStoreGeneric<Dog>.PrintPets();

            Console.WriteLine("Enter a dog's name you would like to buy");
            string dogName = Console.ReadLine();
            PetStoreGeneric<Dog>.BuyPet(dogName);

            Console.ResetColor();
            Console.WriteLine("All the cats in the store:");
            PetStoreGeneric<Cat>.PrintPets();
            Console.WriteLine("Enter a cat's name you would like to buy");
            string catName = Console.ReadLine();
            PetStoreGeneric<Cat>.BuyPet(catName);

            Console.ResetColor();
            Console.WriteLine("All the fishes in the store:");
            PetStoreGeneric<Fish>.PrintPets();
            Console.WriteLine("Enter a fish's name you would like to buy");
            string fishName = Console.ReadLine();
            PetStoreGeneric<Fish>.BuyPet(fishName);

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
