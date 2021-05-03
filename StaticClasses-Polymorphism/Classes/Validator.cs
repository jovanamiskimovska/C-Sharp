using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class Validator
    {
        public static bool Validate(Vehicle vehicle)
        {
            if(vehicle.Id !=0 && !String.IsNullOrEmpty(vehicle.Type) && vehicle.YearOfProduction != 0)
            {
                return true;
            }
            return false;
        }
    }
}
