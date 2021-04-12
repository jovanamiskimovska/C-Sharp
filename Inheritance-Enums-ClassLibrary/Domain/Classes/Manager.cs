using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
    public class Manager : Employee
    {
        private double _bonus { get; set; }
        public Manager(string firstName, string lastName) : base(firstName, lastName)
        {
            Role = RoleEnum.Manager;
            Salary = 750;
        }
        public void AddBonus(double bonusInput)
        {
            _bonus += bonusInput;
        }
        public override double GetSalary()
        {
            return Salary + _bonus;
        }

    }
}
