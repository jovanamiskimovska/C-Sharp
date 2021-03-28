using System;

namespace RealCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            string inputNum1 = Console.ReadLine();
            bool success1 = float.TryParse(inputNum1, out float number1);
            Console.WriteLine("Enter the second number");
            string inputNum2 = Console.ReadLine();
            bool success2 = float.TryParse(inputNum2, out float number2);
            Console.WriteLine("Enter an operand (+,-,/,*)");
            string operand = Console.ReadLine();

            float result;
            bool flag = false;

            switch (operand)
            {
                case "+":
                    result = number1 + number2;
                    flag = true;
                    break;
                case "-":
                    result = number1 - number2;
                    flag = true;
                    break;
                case "*":
                    result = number1 * number2;
                    flag = true;
                    break;
                case "/":
                    result = number1 / number2;
                    flag = true;
                    break;
                default:
                    result = 0;
                    Console.WriteLine("Falsy operand entered");
                    break;
            }
            if (flag)
            {
                Console.WriteLine("The result is:" + result.ToString());
            }  
            Console.ReadLine();
        }
    }
}


