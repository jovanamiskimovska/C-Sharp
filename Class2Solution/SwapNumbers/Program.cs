using System;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            int copy;
            Console.WriteLine("Enter the first number:");
            string numInput1 = Console.ReadLine();
            bool success1 = int.TryParse(numInput1, out num1);
            Console.WriteLine("Enter the second number:");
            string numInput2 = Console.ReadLine();
            bool success2 = int.TryParse(numInput2, out num2);
            Console.WriteLine("The first number is: " + num1 + " and the second number is: " + num2);
            copy = num1;
            num1 = num2;
            num2 = copy;
            Console.WriteLine("After swapping the first number is: " + num1 + " and the second is: " + num2);
            Console.ReadLine();
        }
    }
}
