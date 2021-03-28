using System;

namespace FindStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string numInput1 = Console.ReadLine();
            bool success1 = int.TryParse(numInput1, out int num1);
            Console.WriteLine("Enter the second number:");
            string numInput2 = Console.ReadLine();
            bool success2 = int.TryParse(numInput2, out int num2);

            if(success1 && success2)
            {
                if (num1 % 2 == 0 && num2 % 2 == 0)
                {
                    int sum = num1 + num2;
                    Console.WriteLine("Both numbers are even." + " The operation and the result are " + num1.ToString() + " " + "+" + " " + num2.ToString() + " " + "=" + " " + sum.ToString());
                }
                else if (num1 % 2 != 0 && num2 % 2 != 0)
                {
                    int multiplication = num1 * num2;
                    Console.WriteLine("Both numbers are odd. " + " The operation and the result are " + num1.ToString() + " " + "*" + " " + num2.ToString() + " " + "= " + multiplication.ToString());
                }
                else
                {
                    int difference = num1 - num2;
                    Console.WriteLine("At least one of the numbers is odd. " + "The operation and the result are " + num1.ToString() + " " + "-" + " " + num2.ToString() + " " + "= " + difference.ToString());
                }
            }
            else
            {
                Console.WriteLine("You have to enter two integers!");
            }
            
        }
    }
}
