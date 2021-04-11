using Domain.Classes;
using Domain.Enums;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager managerOne = new Manager("Tom", "Ericssen");
            managerOne.AddBonus(800);
            Manager managerTwo = new Manager("Jane", "Johnson");
            managerTwo.AddBonus(1000); 
            SalesPerson salesOne = new SalesPerson("Lia", "Collins");
            salesOne.AddSuccessRevenue(500); 
            Contractor contractorOne = new Contractor("John", "Hopkins",7, 100, managerOne); 
            Contractor contractorTwo = new Contractor("Conor", "Lee",8, 200, managerTwo);

            Employee[] allEmployees = new Employee[]
            {
                managerOne,
                managerTwo,
                salesOne,
                contractorOne,
                contractorTwo
            };

            CEO ceo = new CEO("Jovana", "Miskimovska", allEmployees, 550);
            ceo.AddSharesPrice(25); //13750

            ceo.PrintEmployees();

            Console.WriteLine($"The CEO's salary is: {ceo.GetSalary()}$");
            
            Console.ReadLine(); 
        }
    }
}
