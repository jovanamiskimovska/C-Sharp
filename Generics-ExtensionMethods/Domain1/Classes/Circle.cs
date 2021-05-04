using System;
using System.Collections.Generic;
using System.Text;

namespace Domain1.Classes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(int id, double radius) : base(id)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            return 3.14 * (Radius * Radius);
        }

        public override double GetPerimeter()
        {
            return 2*3.14*Radius;
        }
    }
}
