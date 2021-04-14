using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ListOfNumbers
{
    class Program
    {
        static void PrintNumberInList(List<double> inputList)
        {
            Console.WriteLine("The squares of the numbers are:");
           foreach(double num in inputList)
            {
                Console.WriteLine(num);
            }
        }
        static void Main(string[] args)
        {
            int counter = 1;
            List<double> listOfNumbers = new List<double>();
            
            Console.WriteLine("Enter 10 numbers: ");
            while (true && counter <= 10)
            {
                bool success = double.TryParse(Console.ReadLine(), out double number);
                if (success)
                {
                    listOfNumbers.Add(number);
                    counter++;
                }
                else
                {
                    Console.WriteLine("Try again");
                    continue;
                }  
            }

            List<double> listOfSquares = listOfNumbers.Select(num => num * num).ToList();
            PrintNumberInList(listOfSquares);

            Console.ReadLine();
        }
    }
}
