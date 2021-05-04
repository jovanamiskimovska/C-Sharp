using System;
using System.Collections.Generic;
using System.Text;

namespace Domain1.Classes
{
   public abstract class Shape
    {
        public int Id { get; set; }
        public Shape(int id)
        {
            Id = id;
        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
