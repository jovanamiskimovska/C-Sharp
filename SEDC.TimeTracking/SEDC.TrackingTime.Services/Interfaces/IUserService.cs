using System;
using System.Collections.Generic;
using SEDC.TimeTracking.Domain.Models;

namespace SEDC.TrackingTime.Services.Interfaces
{
   public interface IUserService<T> where T: User
    {
        void ChangePassword(int id, string oldPassword, string newPassword);
        int LogIn(string username, string password);
        T Register(T userModel);
        T GetById(int id);
        T ChangeFirstName(int userId, string firstName);
        T ChangeLastName(int userId, string lastName);
        void Deactivate(int userId);
        void Track(int userId);
        void UserStatistics(int id);
        void AccountManagement(int id);
        void MainMenu(int id);
        void LogInMenu();
        public int isDeactivated(T user);

    }
}
