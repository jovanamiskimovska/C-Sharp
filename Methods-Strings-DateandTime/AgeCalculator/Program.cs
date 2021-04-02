using System;

namespace AgeCalculator
{
    class Program
    {

        public static void AgeCalculator(DateTime input)
        {
            DateTime currentDateTime = DateTime.Now;
            int age;

            if ((input.Month == currentDateTime.Month) && (input.Day == currentDateTime.Day))
            {
                if (input.Year == currentDateTime.Year)
                {
                    Console.WriteLine("You are born today!");
                }
                else
                {
                    age = currentDateTime.Year - input.Year;
                    Console.WriteLine($"Today is your birthday! HAPPY BIRHDAY! You are {age} years old.");
                }

            }
            else if (input.Month < currentDateTime.Month)
            {
                age = currentDateTime.Year - input.Year;
                Console.WriteLine($"You are {age} years old!");
            }
            else if(input.Month == currentDateTime.Month)
            {
                if (input.Day <= currentDateTime.Day)
                {
                    age = currentDateTime.Year - input.Year;
                    Console.WriteLine($"This is your birthday month, you are {age} years old!");
                }
                else
                {
                    age = (currentDateTime.Year - input.Year) - 1;
                    Console.WriteLine($"This is your birthday month, you are {age} years old!");
                }
            }
            else
            {
                age = (currentDateTime.Year - input.Year) - 1;
                Console.WriteLine($"You are {age} years old!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth year yyyy");
            string year = Console.ReadLine();

            Console.WriteLine("Enter your birth month mm");
            string month = Console.ReadLine();

            Console.WriteLine("Enter your birth day");
            string day = Console.ReadLine();

            string final = $"{year}, {month}, {day}";
            bool success = DateTime.TryParse(final, out DateTime birthDate);

          if(success)
            {
         
                AgeCalculator(birthDate);
            }
            else
            {
                Console.WriteLine("Invalid birth date");
            }
            Console.ReadLine();
        }
    }
}
