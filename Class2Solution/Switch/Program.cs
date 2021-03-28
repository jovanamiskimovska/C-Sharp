using System;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number from 1 to 3");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int result);
         
                switch (result)
                {
                    case 1:
                        Console.WriteLine("You got a new car!");
                        break;
                    case 2:
                        Console.WriteLine("You got a new plane!");
                        break;
                    case 3:
                        Console.WriteLine("You got a new bike!");
                        break;
                default:
                    Console.WriteLine("You have entered a wrong number or character!");
                    break;
            }
          }
        }
    }

