using System;
using System.Collections.Generic;
using System.Text;

namespace classes.Models
{
   public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver CarDriver { get; set; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }
        public Car(string model, int speed, Driver driver)
        {
            Model = model;
            Speed = speed;
            CarDriver = driver;
        }
        public int CalculateSpeed(Driver driverInput)
        {
            int result;

            if (driverInput != null)
            {
                result = driverInput.Skill * Speed;
                return result;
            }
            else
            {
                return -1;
            }
        }
      

    }
}
