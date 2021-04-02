using System;

namespace MinAndMaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int[] numbersArray = new int[10];
            int counter = 0;

            Console.WriteLine("Enter 10 integers");

            while (true && counter<10)
            {
                Console.Write("Integer " + (counter + 1) + "= ");
                string intInput = Console.ReadLine();
                bool success = int.TryParse(intInput, out int number);

                if (success)
                {
                    numbersArray[counter] = number;
                    counter++;
                }
            }

            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (min > numbersArray[i])
                {
                    min = numbersArray[i];
                }

                if (max < numbersArray[i])
                {
                    max = numbersArray[i];
                }
            }
            Console.WriteLine("The max is: " + max + " and the min is: " + min);
            Console.ReadLine();
         }
    }
}
