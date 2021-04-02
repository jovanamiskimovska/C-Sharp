using System;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            int places = 7;
            int number = 1;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = places; j >= 1; j--)
                {
                    Console.Write(" ");
                }
                for (int m = 1; m <= i; m++)
                {
                    Console.Write($"{number++} ");
                }   
                Console.Write("\n");
                places--;
            }

            Console.ReadLine();
            }
        }
    }

