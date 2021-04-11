using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        protected double Salary { get; set; }
        public RoleEnum Role { get; set; }
        public Employee()
        {
            Salary = 700;
        }
        public Employee(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
            Salary = 700;
        }
        public string PrintInfo()
        {
            return $"{FirstName} {LastName} {Salary}";
        }
        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
