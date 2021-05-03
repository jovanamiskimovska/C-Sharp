using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
   public class Bike : Vehicle
    {
        public string Color { get; set; }
        public Bike(int id, string vehicleType, int productionYear, int batchNum, string color) : base(id, vehicleType, productionYear, batchNum)
        {
            Color = color;
        }
        public override void PrintVehicle()
        {
            Console.WriteLine($"The bike's year of production is: {YearOfProduction} and its color is: {Color}");
        }
    }
}
