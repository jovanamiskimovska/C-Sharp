using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
   public class Car : Vehicle
    {
       public int FuelTank { get; set; }
       public List<string> Countries { get; set; }
        
        public Car(int id, string vehicleType, int productionYear, int batchNum, int fTank) : base(id, vehicleType, productionYear, batchNum)
        {
            FuelTank = fTank;
            Countries = new List<string>();
        }
        public override void PrintVehicle()
        {
            Console.WriteLine($"The car's type is: {Type} and the countries in which it was produced is:");
            foreach(string country in Countries)
            {
                Console.WriteLine(country);
            }
        }
    }
}
