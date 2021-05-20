using Bonus.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bonus.App
{
    class Program
    {
        static void Main(string[] args)
        {
          
            List<Person> duplicateList = new List<Person>();
            string peopleString = ""; 

            List<Person> people = new List<Person>()
            {
                new Person(1, "Philip", "Cors", 23),
                new Person(2, "Carrie", "Collins", 25),
                new Person(3, "Katherine", "Jones", 30),
                new Person(4, "Natalie", "Watt", 27),
                new Person(5, "Jessie", "Peterson", 5)
            };

            string appPath = @"..\..\..\";
            string peopletxtFilePath = @"\people.txt";

            if (File.Exists(appPath + peopletxtFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File already exists!");
            }
            else
            {
                File.Create(appPath + peopletxtFilePath).Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File was successfully created");           
            }
            Console.ResetColor();

            foreach (Person person in people)
            {
                peopleString += $"{person.Id} {person.FirstName} {person.LastName} {person.Age} \n";
                        
                    }
            using (StreamWriter personStreamWriter = new StreamWriter(appPath + peopletxtFilePath))

            {
                personStreamWriter.WriteLine(peopleString);
            }
  
            using(StreamReader streamReader = new StreamReader(appPath + peopletxtFilePath))
            {
                for(int i = 0; i < people.Count; i++)
                {
                    string personLine = streamReader.ReadLine();
                    string[] personArrayString = personLine.Split(" ");
                    Person duplicatePerson = new Person(Convert.ToInt32(personArrayString[0]), personArrayString[1], personArrayString[2], Convert.ToInt32(personArrayString[3]));
                    duplicateList.Add(duplicatePerson);
                }
            }

            foreach (Person person in duplicateList)
            {
                Console.WriteLine($" {person.Id} {person.FirstName} {person.LastName} {person.Age}");
            }


            Console.ReadLine();
        }
    }
}
