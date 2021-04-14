
using BonusDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            List < Employee > allEmployees = new List<Employee>()
            {
               new Employee(){FirstName = "Tom", LastName ="Jackson", Age =25 },
                new Employee(){FirstName = "Lora", LastName ="Larson", Age =32 },
                new Employee(){FirstName = "Harry", LastName ="Henderson", Age =38 },
                new Employee(){FirstName = "Anne", LastName ="Borkowski", Age =21 },
                new Employee(){FirstName = "Alex", LastName ="Turner", Age =55 },
                new Employee(){FirstName = "Ronald", LastName ="Brown", Age =70 },
                new Employee(){FirstName = "Ava", LastName ="Michaels", Age =25 },
                new Employee(){FirstName = "Clare", LastName ="Atkinson", Age =25 },
                new Employee(){FirstName = "Ben", LastName ="Green", Age =38 },
                new Employee(){FirstName = "Flora", LastName ="Nature", Age =29 }
            };

            Dictionary<int, List<string>> employeeDictionary = new Dictionary<int, List<string>>();

            foreach(Employee employee in allEmployees)
            {
                if (employeeDictionary.ContainsKey(employee.Age))
                {
                    List<string> updatedList = employeeDictionary[employee.Age];
                    updatedList.Add($"{employee.FirstName} {employee.LastName}");
                    employeeDictionary[employee.Age] = updatedList;
                }
                else
                {
                    employeeDictionary.Add(employee.Age, new List<string> { $"{ employee.FirstName} {employee.LastName}" });
                }
            };

            foreach(var pair in employeeDictionary)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(pair.Key);
                
                foreach(string fullName in pair.Value)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(fullName);
                }
            }

            Console.ReadLine();
        }
    }
}
