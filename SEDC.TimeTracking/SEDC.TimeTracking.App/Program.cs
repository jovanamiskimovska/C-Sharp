
using SEDC.TimeTracking.Domain.Models;
using SEDC.TrackingTime.Services.Implementations;
using SEDC.TrackingTime.Services.Interfaces;
using System;

namespace SEDC.TimeTracking.App
{
    class Program
    {
        public static IUserService<User> _userService = new UserService<User>();

        static void Main(string[] args)
        {
            //Seed();

            Console.Clear();

                _userService.LogInMenu();
            

            Console.ReadLine();
        }
         
        public static void Seed()
        {
            _userService.Register(new User()
            {
                FirstName = "Tom",
                LastName = "Black",
                Age = 25,
                Username = "blackie",
                Password = "TBl25!",
            });
            _userService.Register(new User()
            {
                FirstName = "Ciara",
                LastName = "Atkinson",
                Age = 23,
                Username = "ciarraAt",
                Password = "QueenCiara7"
            });
        }
    }
}
