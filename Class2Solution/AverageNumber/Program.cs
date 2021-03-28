using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            float sum = 0;
            float average;
            int counter = 0;

            Console.WriteLine("Enter the four numbers:");
            
            for(int i=1; i<=4; i++)
            {
                Console.Write("Number" + i + "=");
                string numInput = Console.ReadLine();
                bool success = float.TryParse(numInput, out float number);
                sum+=number;
                if (success)
                {
                    counter++;
                }   
            }
            average = sum / counter;
           if(average <0 || average>0 || average== 0)
            {
                Console.WriteLine("The average of the numbers is:" + average);
            }
            else
            {
                Console.WriteLine("You have to enter at least one number!");
            }
            Console.ReadLine();
        }
    }
}
