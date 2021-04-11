using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Classes
{
   public class SalesPerson : Employee
    {
        private double _successSaleRevenue { get; set; }
        public SalesPerson(string firstName, string lastName) : base(firstName, lastName)
        {
            Salary = 500;
            Role = RoleEnum.Sales;
        }
        public void AddSuccessRevenue(double number)
        {
            _successSaleRevenue = number;
        }
        public override double GetSalary()
        {
            if(_successSaleRevenue <= 2000)
            {
                return Salary += 500;
            }
            else if(_successSaleRevenue>2000 && _successSaleRevenue <= 5000)
            {
                return Salary += 1000;
            }
            else
            {
                return Salary += 1500;
            }
        }
    }
}
