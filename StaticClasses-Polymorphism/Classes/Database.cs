using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class Database
    {
        public static List<Vehicle> Vehicles { get; set; }

      static Database()
        {
            Car car1 = new Car(6, "Hatchback", 2020, 6666666, 45);
            car1.Countries.Add("Spain");
            Car car2 = new Car(7, "Coupe", 2013, 7777777, 60);
            car2.Countries.Add("Korea");
            Car car3 = new Car(8, "SUV", 1995, 8888888, 50);
            car3.Countries.Add("Germany");
            car3.Countries.Add("France");
            Car car4 = new Car(9, "Sedan", 2005, 9999999, 55);
            car4.Countries.Add("USA");
            car4.Countries.Add("China");
            car4.Countries.Add("Japan");
            Car car5 = new Car(10, "Pickup-Truck", 10101010, 6666666, 57);
            car5.Countries.Add("UK");

            Bike bike1 = new Bike(11, "Road-bike", 2011, 1111111, "red");
            Bike bike2 = new Bike(12, "Mountain-bike", 2010, 12121212, "yellow");
            Bike bike3 = new Bike(13, "Hybrid-bike", 2019, 13131313, "blue");
            Bike bike4 = new Bike(14, "Cyclocross-bike", 2017, 14141414, "black");
            Bike bike5 = new Bike(15, "Folding-bike", 2015, 15151515, "brown");

            Vehicles = new List<Vehicle>()
            {
                new Vehicle(1, "Car", 2000, 111111111),
                new Vehicle(2, "Bike", 1996, 22222222),
                new Vehicle(3, "Minivan", 2016, 33333333),
                new Vehicle(4, "Airplane", 2010, 44444444),
                new Vehicle(5, "Bus", 2021, 55555555),
                car1,
                car2,
                car3,
                car4,
                car5,
                bike1,
                bike2,
                bike3,
                bike4,
                bike5
            };
        }
}
}
