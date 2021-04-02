using System;

namespace SumOfDigits
{
    class Program
    {
        public static ulong SumOfDigits (ulong input)
        {
            ulong sum = 0;

            while (input > 0)
            {
                sum += input % 10;
                input = input / 10;
            }
           
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number!");
            string input = Console.ReadLine();
            bool success = ulong.TryParse(input, out ulong number);

            if (success)
            {
                ulong result = SumOfDigits(number);
                Console.WriteLine($"The sum of the digits in {number} is: {result}");
            }
            else
            {
                Console.WriteLine("Invalid number entered.");
            }
        }
    }
}
