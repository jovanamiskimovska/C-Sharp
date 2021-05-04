using Domain1.Classes;
using System;
using Domain1;
using System.Collections.Generic;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(1, 5);
            Circle circle2 = new Circle(2, 10.5);
            Rectangle rectangle1 = new Rectangle(3, 10, 13.7);
            Rectangle rectangle2 = new Rectangle(4, 15.5, 25.3);

            GenericDatabase<Circle>.GenericObjectsList.Add(circle1);
            GenericDatabase<Circle>.GenericObjectsList.Add(circle2);
            GenericDatabase<Rectangle>.GenericObjectsList.Add(rectangle1);
            GenericDatabase<Rectangle>.GenericObjectsList.Add(rectangle2);

            GenericDatabase<Circle>.PrintArea();
            GenericDatabase<Circle>.PrintPerimeter();
            GenericDatabase<Rectangle>.PrintArea();
            GenericDatabase<Rectangle>.PrintPerimeter();

            GenericDatabase<Shape>.GenericObjectsList.GetInfo();

            Console.ReadLine();
        }
    }
}
