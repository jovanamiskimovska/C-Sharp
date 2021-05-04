using Domain2.Classes;
using Domain2.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain2
{
    public static class PetDatabase
    {
        static PetDatabase()
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
        }
    }
}
