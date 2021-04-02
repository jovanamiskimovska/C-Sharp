using System;

namespace StudentGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentsG1 = new string[5];
            string[] studentsG2 = { "Hunter", "Axel", "Mad", "Collie", "Aster" };

            bool flag = true;

            Console.WriteLine("Enter the names of the students in the first group");

            for(int i=0; i<5; i++)
            {
                Console.Write("Student " + (i + 1) + ": ");
                string inputName = Console.ReadLine();

                foreach(char c in inputName)
                {
                    if(inputName.Length > 2  && Char.IsLetter(inputName[0]) && Char.IsLetter(inputName[1]) && (Char.IsLetter(c)  || !String.IsNullOrWhiteSpace(inputName)))
                    {
                        studentsG1[i] = inputName;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Enter 1 or 2 if you want to print all the students in the appropriate group");

                string inputNum = Console.ReadLine();
                bool success = int.TryParse(inputNum, out int groupNum);

                if (success && (groupNum == 1 || groupNum == 2))
                {
                    Console.WriteLine($"All the students in Group{groupNum} are: ");

                    for (int i = 0; i < studentsG1.Length; i++)
                    {
                        if (groupNum == 1)
                        {
                            Console.WriteLine((i + 1) + "." + " " + studentsG1[i]);
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + "." + " " + studentsG2[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number, there is no such group!");
                }
            }
            else
            {
                Console.WriteLine("Invalid name entered!");
            }
           
            Console.ReadLine();
        }
    }
}
