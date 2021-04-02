using System;

namespace NextToEachOther
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number of integer elements in the array");
            string numInput = Console.ReadLine();
            bool success1 = int.TryParse(numInput, out int elemNum);

            int[] numbersArray = new int[0];
            int counter = 0;
            bool flag = true;

            if (success1)
            {
                Array.Resize(ref numbersArray, elemNum);

                for(int i = 0; i<elemNum; i++)
                {
                    Console.Write($"Number {i + 1} = ");
                    string enteredNumber = Console.ReadLine();
                    bool success2 = int.TryParse(enteredNumber, out int number);

                    if (success2)
                    {
                        numbersArray[i] = number;   
                    }
                    else
                    {
                        flag = false;
                        Console.WriteLine("Invalid number entered!");
                        break;
                    }
                }
            }
            else
            {
                flag = false;
                Console.WriteLine("Invalid number of elements!");
            }

            for(int i = 0; i<numbersArray.Length-1; i++)
            {
                if(numbersArray[i] ==3 && numbersArray[i+1] ==3 && (i+1)<(numbersArray.Length))
                {
                    counter++;
                }
            }

            if (flag)
            {
             Console.WriteLine($"There are {counter} times threes next to each other!");
            }
            Console.ReadLine();
        }
    }
}
