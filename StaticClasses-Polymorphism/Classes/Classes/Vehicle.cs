using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int YearOfProduction { get; set; }
        public int BatchNumber { get; set; }
        public Vehicle(int id, string vehicleType, int productionYear, int batchNum)
        {
            Id = id;
            Type = vehicleType;
            YearOfProduction = productionYear;
            BatchNumber = batchNum;
        }
        public virtual void PrintVehicle()
        {
            Console.WriteLine($"The id of the vehicle is: {Id}, its type is: {Type} and the year when it was produced: {YearOfProduction}");
        }
    }
}
