using System;
using System.IO;

namespace Filesystem.CalculateNumbers
{
    class Program
    {
        public static string CalculateNumbers(double num1, double num2, string operand)
        {
            switch (operand) {
                case "+":
                    return $"num1 + num2 = {num1+num2}" ;
                    break;
                case "-":
                    return $"num1 - num2 = {num1-num2}";
                    break;
                case "*":
                    return $"num1 * num2 = {num1*num2}";
                    break;
                case "/":
                    return $"num1 / num2 = {num1/num2}";
                    break;
                default:
                    return "Invalid operand";
                    break;
            }
        }
        static void Main(string[] args)
        {
            string appPath = @"..\..\..\";
            string txtFilePath = @"\calculations.txt";

            string exerciseFolderPath = appPath + "Exercise";

            if (Directory.Exists(exerciseFolderPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The folder 'Exercise' already exists");
            }
            else
            {
                Directory.CreateDirectory(exerciseFolderPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("'Exercise' folder was successfully created!");
            }
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("Enter the first number:");
                string number1 = Console.ReadLine();
                bool success1 = double.TryParse(number1, out double num1);
                if (success1)
                {
                    Console.WriteLine("Enter the second number:");
                    string number2 = Console.ReadLine();
                    bool success2 = double.TryParse(number2, out double num2);
                    if (success2)
                    {
                        Console.WriteLine("Enter an operand: +, -, *, /");
                        string operand = Console.ReadLine();
                        if (operand == "/" && num2 == 0)
                        {
                            Console.WriteLine("You can not divide with 0");
                            continue;
                        }
                        else
                        {
                            using(StreamWriter calculationWriter = new StreamWriter(exerciseFolderPath + txtFilePath, true))
                            {
                                calculationWriter.WriteLine(CalculateNumbers(num1, num2, operand));
                            }
                            Console.WriteLine("Do you want to continue? 1 - yes");

                            if(Console.ReadLine() == "1")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                           
                        }     
                    }
                    else
                    {
                        Console.WriteLine("Invalid second number");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid first number");
                    continue;
                }
                
            }

            Console.ReadLine();
        }
    }
}
