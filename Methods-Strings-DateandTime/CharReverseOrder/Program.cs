using System;

namespace CharReverseOrder
{
    class Program
    {
        public static void ReverseChar(string input)
        {
            char[] allChars = input.ToCharArray();
            char[] charsCopy = allChars;

           Array.Reverse(charsCopy);

            foreach(char character in charsCopy)
            {
                Console.Write(character);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string you want to reverse!");
            string input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                Console.WriteLine("The result is: ");
                ReverseChar(input);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            
        }
    }
}
