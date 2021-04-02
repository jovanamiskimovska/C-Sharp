using System;

namespace sumOfEven
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[6];
            int sum = 0;
            bool flag = true;

            Console.WriteLine("Enter 6 integers");

            for(int i=0; i<6; i++)
            {
                Console.Write("Number " + (i+1) + " = ");
                string numInput = Console.ReadLine();
                bool success = int.TryParse(numInput, out int number);

                if (success)
                {
                    intArray[i] = number;
                    if(number % 2 == 0)
                    sum += number;
                }
                else
                {
                    Console.WriteLine("Invalid number entered");
                    flag = false;
                    break;
                }
            }
      
            if(flag)
            Console.WriteLine("The sum of all the even numbers is: " + sum);

            Console.ReadLine();
        }
    }
}
