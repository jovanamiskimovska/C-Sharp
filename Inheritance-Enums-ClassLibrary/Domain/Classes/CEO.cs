using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class CEO : Employee
    {

        public Employee[] Employees { get; set; }
        public int Shares { get; set; }
        private double _sharesPrice { get; set; }

        public CEO(string firstName, string lastName, Employee[] employeesArray, int shares) : base(firstName, lastName)
        {
            Employees = employeesArray;
            Shares = shares;
        }
        public void AddSharesPrice(double number)
        {
            _sharesPrice = number;
        }
        public void PrintEmployees()
        {
            Console.WriteLine($"All the employees of CEO {FirstName} {LastName} are:");
            foreach(Employee employee in Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}, role : {employee.Role}, with salary of {employee.GetSalary()}$");
            }
        }
        public override double GetSalary()
        {
            if (_sharesPrice == 0)
            {
                AddSharesPrice(10);
            }
            Salary = Salary + (Shares * _sharesPrice);
            return Salary;
        }

    }
}
