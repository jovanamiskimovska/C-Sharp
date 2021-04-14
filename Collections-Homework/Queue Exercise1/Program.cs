using System;
using System.Collections.Generic;
using System.Collections;

namespace Queue_Exercise1
{
    class Program
    {
        static void PrintNumbersQueue(Queue<double> input)
        {
            Console.WriteLine("All the numbers in the entered order are:");
            while (input.Count > 0)
            {
                Console.WriteLine(input.Dequeue());
            }
        }
        static void Main(string[] args)
        {
            int counter = 0;
            Queue<double> numberQueue = new Queue<double>();
           

            while (true)
            {
                Console.WriteLine("Enter the number of elements:");
                bool success = int.TryParse(Console.ReadLine(), out int numberOfElements);

                if (success == false)
                {
                    Console.WriteLine("Invalid number, try again");
                    continue;
                }
                while (counter < numberOfElements)
                {
                    Console.Write($"Number {counter + 1} = ");
                    bool success1 = double.TryParse(Console.ReadLine(), out double number);
                    if (success1)
                    {
                        numberQueue.Enqueue(number);
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                        continue;
                    }
                }
                break;  
            }
            
            PrintNumbersQueue(numberQueue);

            Console.ReadLine();
        }
    }
}
