using SEDC.TimeTracking.Domain.Enums;
using SEDC.TrackingTime.Services.Helpers;
using SEDC.TrackingTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.TrackingTime.Services.Implementations
{
    public class UIService : IUIService
    {
        public int AccountManagementMenu()
        {
            List<string> changeInfoOptions = new List<string> { "Change password", "Change Firstname", "Change Lastname", "Deactivate Account", "Back" };
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(changeInfoOptions);
        }

        public int ActivityMenu()
        {
            List<string> activities = Enum.GetNames(typeof(ActivityType)).ToList();
                Console.WriteLine("Choose an activity");
            return ChooseMenuItem(activities);
        }

        public int ChooseMenuItem(List<string> menuItems)
        {
            while (true)
            {
                for(int i=0; i<menuItems.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {menuItems[i]}");
                }
                int choice = ValidationHelper.ValidateNumber(Console.ReadLine(), menuItems.Count);
                if(choice == -1)
                {
                    MessageHelper.PrintMessage("Please enter a valid option", ConsoleColor.Red);
                    Console.Clear();
                    continue;
                }
                return choice;
            }
        }

        public int ExercisingMenu()
        {
            List<string> exercisingOptions = Enum.GetNames(typeof(ExercisingType)).ToList();
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(exercisingOptions);
        }

        public int LogInMenu()
        {
            List<string> menuItems = new List<string> { "LogIn", "Register" };
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(menuItems);
        }

        public int LogOut()
        {
            Console.WriteLine("Are you sure you want to log out? Type 'yes.");
            if(Console.ReadLine().ToLower() == "yes")
            {
                return LogInMenu();
            }
            else
            {
                return MainMenu();
            }
        }

        public int MainMenu()
        {
            List<string> mainMenuOptions = new List<string> { "Track", "User Statistics", "Account Management", "Log Out" };
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(mainMenuOptions);
        }

        public int OtherHobbiesMenu()
        {
            List<string> otherHobbiesOptions = new List<string> {"Shopping", "Partying"};
            Console.WriteLine("Chooose an option");
            return ChooseMenuItem(otherHobbiesOptions);
        }

        public int ReadingMenu()
        {
            List<string> readingOptions = Enum.GetNames(typeof(ReadingType)).ToList();
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(readingOptions);
        }

        public int UserStatisticsMenu()
        {
            List<string> userStatisticsOptions = new List<string> { "Exercising", "Reading", "Working", "OtherHobbies", "Global", "Back" };
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(userStatisticsOptions);
        }

        public int WorkingMenu()
        {
            List<string> workingOptions = Enum.GetNames(typeof(WorkLocation)).ToList();
            Console.WriteLine("Choose an option");
            return ChooseMenuItem(workingOptions);
        }
    }
}
