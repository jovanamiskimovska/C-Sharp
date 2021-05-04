using System;
using System.Collections.Generic;
using System.Text;

namespace Domain1
{
    public static class Extensions
    {
        public static void GetInfo<T>(this List<T> shapeList) 
        {
            foreach(T shape in shapeList)
            {
                Console.WriteLine($"The type of the shape is {shape.GetType()}");
            }  
        }
    }
}
