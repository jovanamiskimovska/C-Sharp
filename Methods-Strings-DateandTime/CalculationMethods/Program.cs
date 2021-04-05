using System;

namespace CalculationMethods
{
    class Program
    {
        public static float Sum(float firstNum, float secondNum)
        {

           float sum = firstNum + secondNum;
            return sum;
        }

        public static float Subtract(float firstNum, float secondNum)
        {
           float subtract = firstNum - secondNum;
            return subtract;
        }

        public static float Multiplication(float firstNum, float secondNum)
        {
            float multiplication = firstNum * secondNum;
            return multiplication;
        }

        public static float Division(float firstNum, float secondum)
        {
   
                float division = firstNum / secondum;
                return division;
        }

        public static void Calculator(string operation, float num1, float num2)
        {
            switch (operation.ToLower())
            {
                case "sum":
                    {
                        Console.WriteLine("Sum:" + Sum(num1, num2));
                        break;
                    }
                case "subtract":
                    {
                        Console.Write("Subtract:" + Subtract(num1, num2));
                        break;
                    }
                case "multiplication":
                    {
                       Console.WriteLine("Multiplication:" + Multiplication(num1, num2));
                        break;
                    }
                case "division":
                    {
                        if (num2 == 0)
                        {
                            Console.WriteLine("The second number can't be 0");
                        }
                        else
                        {
                            Console.WriteLine("Division:" + Division(num1, num2));
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid operation!");
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string input1 = Console.ReadLine();
            bool success1 = float.TryParse(input1, out float number1);

            Console.WriteLine("Enter the second number:");
            string input2 = Console.ReadLine();
            bool success2 = float.TryParse(input2, out float number2);

            Console.WriteLine("Enter the operation: sum, subtract, multiplication or division");
            string operation = Console.ReadLine();

            if(success1 && success2)
            {
                Calculator(operation, number1, number2);
            }
            else
            {
                Console.WriteLine("Invalid numbers entered!");
            }
            Console.ReadLine();
        }
    }
}
