using classes.Models;
using System;

namespace classes
{
    class Program
    {
        public static Driver findDriver(Driver [] allDrivers, string driverNameInput)
        {
            foreach(Driver driver in allDrivers)
            {
                if(driver.Name.ToLower() == driverNameInput.ToLower())
                {
                    return driver;
                }
                
            }
            return null;
        }

        public static Driver[] allDriversWithoutChosen(Driver [] allDrivers, string driverName)
        {
            Driver[] allDriversWithoutChosen = new Driver[0];
            int counter = 0;
            bool flag = false;

            foreach(Driver driver in allDrivers)
            {
                if (driver.Name.ToLower() == driverName.ToLower())
                {
                    flag = true;
                    continue;  
                }
                else
                {
                    Array.Resize(ref allDriversWithoutChosen, counter + 1);
                    allDriversWithoutChosen[counter++] = driver;
                }

            }
            if (flag)
            {
                return allDriversWithoutChosen;
            }

            else
            {
                return null;
            }

        }

        public static Car findCar(Car[] allCars, string carModel)
        {
            bool flag = false;
  
            foreach (Car car in allCars)
            {
                if (car.Model.ToLower() == carModel.ToLower())
                {
                    return car;
                }
            }
                return null;
        }

        public static Car[] allCarsWithoutChosen(Car[] allCars, string carName)
        {
            Car[] allCarsWithoutChosen = new Car[0];
            int counter = 0;
            bool flag = false;

            foreach (Car car in allCars)
            {
                if (car.Model.ToLower() == carName.ToLower())
                {
                    flag = true;
                    continue;
                }
                else
                {
                    Array.Resize(ref allCarsWithoutChosen, counter+1);
                    allCarsWithoutChosen[counter++] = car;
                }
            }
            if (flag)
            {
                return allCarsWithoutChosen;
            }
            else
            {
                return null;
            }
        }

        public static void PrintCars(Car [] allCars)
        {
            foreach(Car car in allCars)
            {
                Console.WriteLine(car.Model);
            }
        }

        public static void PrintDrivers(Driver[] allDrivers)
        {
            foreach (Driver driver in allDrivers)
            {
                Console.WriteLine(driver.Name);
            }
        }
        public static void RaceCars(Car car1, Car car2)
        {
            int firstResult;
            int secondResult;

            if (car1.CarDriver != null && car2.CarDriver !=null)
            {
                firstResult = car1.CalculateSpeed(car1.CarDriver);
                secondResult = car2.CalculateSpeed(car2.CarDriver);

                if(firstResult > secondResult)
                {
                    Console.WriteLine($"The first car was faster than the second one, the model of the faster car was {car1.Model}, its speed was {car1.Speed} km/h and its driver was {car1.CarDriver.Name}");
                }
                else if (secondResult > firstResult)
                {
                    Console.WriteLine($"The second car was faster than the first one, the model of the faster car was {car2.Model}, its speed was {car2.Speed} km/h and its driver was {car2.CarDriver.Name}");
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

        }

        static void Main(string[] args)
        {
            Car[] cars = new Car[]
               {
                new Car("Hyundai", 190),
                new Car("Mazda", 180),
                new Car("Ferrari", 250),
                new Car("Porsche", 300)
               };

            Driver[] drivers = new Driver[]
            {
                new Driver("Bob", 3),
                new Driver("Greg", 9),
                new Driver("Jill", 5),
                new Driver("Anne", 7)
            };

            while (true)
            {
                Driver firstD;
                Driver secondD;
                Car firstCar;
                Car secondCar;

                string secondChosenCar;
                string secondDriver;

                Console.WriteLine("Pick the first car from the list:");
                PrintCars(cars);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                string firstChosenCar = Console.ReadLine();

                Console.WriteLine("Choose the first driver from the list:");
                PrintDrivers(drivers);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                string firstDriver = Console.ReadLine();

                if(String.IsNullOrEmpty(firstChosenCar) || String.IsNullOrEmpty(firstDriver) || findCar(cars,firstChosenCar)==null || findDriver(drivers, firstDriver) == null)
                {
                    Console.WriteLine("Invalid input, try again!");
                    continue;
                }

                    firstCar = findCar(cars, firstChosenCar);
                    firstD = findDriver(drivers, firstDriver);

                Console.WriteLine("Pick the second car from the list:");
                if (allCarsWithoutChosen(cars, firstChosenCar) != null)
                {
                    PrintCars(allCarsWithoutChosen(cars, firstChosenCar));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                secondChosenCar = Console.ReadLine();

                Console.WriteLine("Choose the second driver:");
                if (allDriversWithoutChosen(drivers, firstDriver) != null)
                {
                    PrintDrivers(allDriversWithoutChosen(drivers, firstDriver));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                secondDriver = Console.ReadLine();

                if (String.IsNullOrEmpty(secondChosenCar) || String.IsNullOrEmpty(secondDriver) || findCar(allCarsWithoutChosen(cars, firstChosenCar), secondChosenCar) == null || findDriver(allDriversWithoutChosen(drivers, firstDriver), secondDriver) == null)
                {
                    Console.WriteLine("Invalid input, try again!");
                    continue;
                }

                    secondD = findDriver(allDriversWithoutChosen(drivers, firstDriver), secondDriver);
                    secondCar = findCar(allCarsWithoutChosen(cars, firstChosenCar), secondChosenCar);
                    firstCar.CarDriver = firstD;
                    secondCar.CarDriver = secondD;

                    RaceCars(firstCar, secondCar);

                Console.WriteLine("Do you want to race again? If so, enter yes");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("EXIT");
                    break;
                }

            }
            Console.ReadLine();
           
        }
    }
}
