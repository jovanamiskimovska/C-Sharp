using System;
using System.Collections.Generic;
using System.Text;

namespace Domain1.Classes
{
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Rectangle(int id, double sideA, double sideB): base(id)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public override double GetArea()
        {
            return SideA * SideB;
        }

        public override double GetPerimeter()
        {
            return (2 * SideA) + (2 * SideB);
        }
    }
}
