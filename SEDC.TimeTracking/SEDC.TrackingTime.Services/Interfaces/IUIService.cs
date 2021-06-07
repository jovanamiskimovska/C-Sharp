using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TrackingTime.Services.Interfaces
{
   public interface IUIService
    {
        int ChooseMenuItem(List<string> menuItems);
        int LogInMenu();
        int MainMenu();
        int ActivityMenu();
        int ReadingMenu();
        int ExercisingMenu();
        int WorkingMenu();
        int OtherHobbiesMenu();
        int AccountManagementMenu();
        int UserStatisticsMenu();
        int LogOut();
    }
}
