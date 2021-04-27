using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class Services
    {
        public static List<Dog> dogs = new List<Dog>()
            {
                new Dog("Kaja","gold",5,"Labrador Retriever"),
                new Dog("Rex","brown",3,"German Shepherd"),
                new Dog("Hunter","black",1,"Doberman"),
            };

       public static List<Cat> cats = new List<Cat>()
            {
                new Cat("Mac","yellow",2,"British shorthair"),
                new Cat("Blackie","black",5, "Chartreux")
            };

       public static List<Animal> allAnimals = new List<Animal>()
            {
                dogs[0],
                dogs[1],
                dogs[2],
                cats[0],
                cats[1]
            };

        public static void DogsBark(List<Dog> listOfDogs)
        {
            foreach (Dog dog in listOfDogs)
            {
                dog.Bark();
            }
        }

        public static void CatsEat(List<Cat> listOfCats)
        {
            for(int i = 0; i <listOfCats.Count; i++)
            {
                if( listOfCats[i].Age>2)
                {
                    listOfCats[i].Eat("fish");
                }
                else
                {
                    listOfCats[i].Eat("meat");
                }
            } 
        }
    }
}
