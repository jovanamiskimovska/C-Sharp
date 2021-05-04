using Domain1.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain1
{
   public static class GenericDatabase<T> where T : Shape
    {
        public static List<T> GenericObjectsList { get; set; }
        static GenericDatabase()
        {
            GenericObjectsList = new List<T>();
        }
         public static void PrintArea()
        {
            foreach(T shape in GenericObjectsList)
            {
                Console.WriteLine($"The area of the shape with id {shape.Id} is: {shape.GetArea()}");
            }
        }
        public static void PrintPerimeter()
        {
            foreach(T shape in GenericObjectsList)
            {
                Console.WriteLine($"The perimeter of the shape with id {shape.Id} is: {shape.GetPerimeter()}");
            }
        }
    }
}
