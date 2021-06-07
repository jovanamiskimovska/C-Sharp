using SEDC.TimeTracking.Domain.Database;
using SEDC.TimeTracking.Domain.Enums;
using SEDC.TimeTracking.Domain.Models;
using SEDC.TrackingTime.Services.Helpers;
using SEDC.TrackingTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SEDC.TrackingTime.Services.Implementations
{

    public class UserService<T> : IUserService<T> where T : User

    {
        public static IUIService _uiService = new UIService();


        private IDatabase<T> _database;
        public UserService()
        {
            //  _database = new Database<T>();
            _database = new FileDb<T>();
        }
        public int isDeactivated(T user)
        {
            if (user.isDeactivated)
            {
                MessageHelper.PrintMessage("Your account was previously deactivated, if you want to proceed with the login you have to activate your account. Click 'yes' to proceed", ConsoleColor.White);
                if (Console.ReadLine().ToLower() == "yes")
                {
                    user.isDeactivated = false;
                    _database.Update(user);
                    return user.Id;
                }
                MessageHelper.PrintMessage("Login unsuccessful - account still deactivated", ConsoleColor.Red);
                return -1;
            }
            return user.Id;
        }
        public void AccountManagement(int id)
        {
            T userDb = _database.GetById(id);

            int option = _uiService.AccountManagementMenu();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter your old password");
                    string oldPassword = Console.ReadLine();
                    Console.WriteLine("Enter your new password");
                    string newPassword = Console.ReadLine();
                    ChangePassword(userDb.Id, oldPassword, newPassword);
                    break;
                case 2:
                    Console.WriteLine("Enter your new first name");
                    string newFirstName = Console.ReadLine();
                    ChangeFirstName(userDb.Id, newFirstName);
                    break;
                case 3:
                    Console.WriteLine("Enter your new last name");
                    string newLastName = Console.ReadLine();
                    ChangeLastName(userDb.Id, newLastName);
                    break;
                case 4:
                    Console.WriteLine("Are you sure you want to deactivate your account? Enter 'yes'");
                    if(Console.ReadLine().ToLower() == "yes")
                    {
                        Deactivate(userDb.Id);
                        break;
                    }
                    AccountManagement(userDb.Id);
                    break;
                case 5:
                    MainMenu(userDb.Id);
                    break;           
            }
        }

        public T ChangeFirstName(int userId, string firstName)
        {
            T userDb = GetById(userId);
            if (!ValidationHelper.ValidateName(firstName))
            {
                MessageHelper.PrintMessage("Error! Invalid user data entered", ConsoleColor.Red);
            }
            userDb.FirstName = firstName;
            _database.Update(userDb);
            MessageHelper.PrintMessage($"User with id {userId} was successfully updated", ConsoleColor.Green);
            return _database.GetById(userId);
        }
        public T ChangeLastName(int userId, string lastName)
        {
            T userDb = GetById(userId);
            if (!ValidationHelper.ValidateName(lastName)) 
            {
                MessageHelper.PrintMessage("Error! Invalid user data entered", ConsoleColor.Red);
            }
            userDb.LastName = lastName;
            _database.Update(userDb);
            MessageHelper.PrintMessage($"User with id {userId} was successfully updated", ConsoleColor.Green);
            return _database.GetById(userId);
        }

        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            T userDb = _database.GetById(userId);
            if (userDb.Password != oldPassword)
            {
                throw new Exception("The password does not match with the existing password");
            }
            if (!ValidationHelper.PasswordValidation(newPassword))
            {
                throw new Exception("Invalid password!");
            }
            userDb.Password = newPassword;
            _database.Update(userDb);
            MessageHelper.PrintMessage("Password was successfully updated!", ConsoleColor.Green);
        }

        public void Deactivate(int userId)
        {
            T userDb = _database.GetById(userId);
            userDb.isDeactivated = true;
            _database.Update(userDb);
            MessageHelper.PrintMessage("Account - deactivated!", ConsoleColor.Green);
            LogInMenu();
        }

        public T GetById(int id)
        {
            return _database.GetById(id);
        }

        public int LogIn(string username, string password)
        {
            T userDb = _database.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
            if (userDb == null)
            {
                MessageHelper.PrintMessage($"Error, user with username: {username} and password: {password} does not exist!", ConsoleColor.Red);
                MessageHelper.PrintMessage("Please try again", ConsoleColor.White);
                int counter = 0;
                while (counter < 2)
                {
                    Console.WriteLine("Enter your username again:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter your password again:");
                    string passWord = Console.ReadLine();
                    counter++;
                    T userDB = _database.GetAll().FirstOrDefault(x => x.Username == userName && x.Password == passWord);
                    if (userDB == null)
                    {
                        MessageHelper.PrintMessage("Another attempt failed...", ConsoleColor.Red);
                        continue;
                    }
                    else
                    {
                        return isDeactivated(userDB);
                    }
                }
                if(counter == 2)
                {
                    MessageHelper.PrintMessage("Ran out of attempts...Goodbye!", ConsoleColor.Red);
                    return -1;
                }
            }
           return isDeactivated(userDb);
        }       


        public void LogInMenu()
        {
            Console.Clear();
            MessageHelper.PrintMessage("Welcome", ConsoleColor.Blue);
            int option = _uiService.LogInMenu();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter your username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    string password = Console.ReadLine();
                    int id = LogIn(username, password);
                    if(id == -1)
                    {
                        LogInMenu();
                        break;
                    }
                    else
                    {
                        MainMenu(id);
                        break;
                    }
                case 2:
                    Console.WriteLine("Enter your first name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter your last name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter your username:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    string userPassword = Console.ReadLine();
                    T newUser = (T)new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = userName,
                        Password = userPassword
                    };
                    T result = Register(newUser);
                    if(result == null)
                    {
                        MessageHelper.PrintMessage("Register failed...", ConsoleColor.Red);
                        Console.Clear();
                        LogInMenu();
                        break;
                    }
                    MainMenu(newUser.Id);
                    break;
            }
        }

        public void MainMenu(int id)
        {
            T userDb = _database.GetById(id);

            int option = _uiService.MainMenu();
            switch (option)
            {
                case 1:
                    Track(userDb.Id);
                    break;
                case 2:
                    UserStatistics(userDb.Id);
                     break;
                case 3:
                    AccountManagement(userDb.Id);
                    break;
                case 4:
                    Console.WriteLine("Logging out...", ConsoleColor.Blue);
                    LogInMenu();
                    break;
            }
        }

        public T Register(T userModel)
        {
            if (!ValidationHelper.ValidateName(userModel.FirstName) || !ValidationHelper.ValidateName(userModel.LastName)
                || !ValidationHelper.ValidateUsername(userModel.Username) || !ValidationHelper.PasswordValidation(userModel.Password))
            {
                MessageHelper.PrintMessage("Error, user data is invalid", ConsoleColor.Red);
                return null;
            }
            int id = _database.Insert(userModel);
            return _database.GetById(id);
        }

        public void Track(int id)
        {
            T userDb = _database.GetById(id);

            int option = _uiService.ActivityMenu();
            int option2;
            Stopwatch stopwatch = new Stopwatch();

            if (option == 1)
            {
                ReadingActivity newReadingActivity = new ReadingActivity();
                userDb.Activities.Add(newReadingActivity);
                option2 = _uiService.ReadingMenu();
                if (option2 == 1)
                {
                    newReadingActivity.ReadingLiterature = ReadingType.BellesLetters;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ReadingLettersTime += stopwatch.Elapsed.Minutes;
                        newReadingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes reading Belles Letters", ConsoleColor.White);
                    }
                }
                else if (option2 == 2)
                {
                    newReadingActivity.ReadingLiterature = ReadingType.Fiction;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ReadingFictionTime += stopwatch.Elapsed.Minutes;
                        newReadingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes reading Fiction", ConsoleColor.White);
                    }
                }
      
                else if (option2 == 3)
                {
                    newReadingActivity.ReadingLiterature = ReadingType.ProfessionalLiterature;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ReadingProfessionalTime += stopwatch.Elapsed.Minutes;
                        newReadingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes reading Professional Literature", ConsoleColor.White);
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("Invalid option", ConsoleColor.Red);
                }
              
            }
            if (option == 2)
            {
                ExercisingActivity newExercisingActivity = new ExercisingActivity();
                userDb.Activities.Add(newExercisingActivity);
                option2 = _uiService.ExercisingMenu();
                if (option2 == 1)
                {
                    newExercisingActivity.Exercising = ExercisingType.General;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ExercisingGeneralTime += stopwatch.Elapsed.Minutes;
                        newExercisingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes Exercising - General", ConsoleColor.White);
                    }
                }
                else if (option2 == 2)
                {
                    newExercisingActivity.Exercising = ExercisingType.Running;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ExercisingRunningTime += stopwatch.Elapsed.Minutes;
                        newExercisingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes Exercising - Running", ConsoleColor.White);
                    }
                }
                else if (option2 == 3)
                {
                    newExercisingActivity.Exercising = ExercisingType.Sport;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.ExercisingSportTime += stopwatch.Elapsed.Minutes;
                        newExercisingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes Exercising - Sport", ConsoleColor.White);
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("Invalid option", ConsoleColor.Red);
                }
            }
            if (option == 3)
            {
                WorkingActivity newWorkingActivity = new WorkingActivity();
                userDb.Activities.Add(newWorkingActivity);
                option2 = _uiService.WorkingMenu();
                if (option2 == 1)
                {
                    newWorkingActivity.WorkingLocation = WorkLocation.Home;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.WorkingHomeTime += stopwatch.Elapsed.Minutes;
                        newWorkingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes Working - from Home", ConsoleColor.White);
                    }
                }
                else if (option2 == 2)
                {
                    newWorkingActivity.WorkingLocation = WorkLocation.Office;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.WorkingOfficeTime += stopwatch.Elapsed.Minutes;
                        newWorkingActivity.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes Working - at the Office", ConsoleColor.White);
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("Invalid option", ConsoleColor.Red);
                }


            }
            if (option == 4)
            {
                OtherHobbies newOtherHobbies = new OtherHobbies();
                userDb.Activities.Add(newOtherHobbies);
                option2 = _uiService.OtherHobbiesMenu();
                if (option2 == 1)
                {
                    newOtherHobbies.HobbyName = HobbyName.Shopping;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.OtherShoppingTime += stopwatch.Elapsed.Minutes;
                        newOtherHobbies.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes in Other Hobbies -  Shopping", ConsoleColor.White);
                    }
                }
                else if (option2 == 2)
                {
                    newOtherHobbies.HobbyName = HobbyName.Partying;
                    MessageHelper.PrintMessage($"The countdown for activity {option2} starts now! Click 'enter' when you want to stop!", ConsoleColor.Green);
                    stopwatch.Start();
                    if (Console.ReadLine() == "")
                    {
                        stopwatch.Stop();
                        userDb.OtherPartyingTime += stopwatch.Elapsed.Minutes;
                        newOtherHobbies.Time = stopwatch.Elapsed.Minutes;
                        _database.Update(userDb);
                        MessageHelper.PrintMessage($"You've spent {stopwatch.Elapsed.Minutes} minutes in Other Hobbies - Partying", ConsoleColor.White);
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("Invalid option", ConsoleColor.Red);
                }

            }

        }
        public void UserStatistics(int id)
        {
            T userDb = _database.GetById(id);
            int option = _uiService.UserStatisticsMenu();

            int readingActivityCounter = 0;
            int exercisingActivityCounter = 0;
            int workingActivityCounter = 0;
            int otherHobbiesCounter = 0;

            foreach (TimeTracking.Domain.Models.Activity activity in userDb.Activities)
            {
                if (activity.Type == ActivityType.Reading)
                {
                    readingActivityCounter++;
                }
                else if (activity.Type == ActivityType.Exercising)
                {
                    exercisingActivityCounter++;
                }
                else if (activity.Type == ActivityType.Working)
                {
                    workingActivityCounter++;
                }
                else
                {
                    otherHobbiesCounter++;
                }
            }

            if (option == 2)
            {
                MessageHelper.PrintMessage("READING", ConsoleColor.Blue);
                if (readingActivityCounter != 0)
                {
                    userDb.TotalTimeReading = (userDb.ReadingFictionTime + userDb.ReadingLettersTime + userDb.ReadingProfessionalTime) * 60;
                    double averageReadingTime = (userDb.TotalTimeReading) / (60 * readingActivityCounter);
                    MessageHelper.PrintMessage($"The total time of all Reading activities is {userDb.TotalTimeReading}", ConsoleColor.Green);
                    MessageHelper.PrintMessage($"The average time of all Reading activities is {averageReadingTime}", ConsoleColor.Green);
                    List<ReadingActivity> readingActivities = new List<ReadingActivity>()
                {
                 new ReadingActivity()
                {
                    ReadingLiterature = ReadingType.BellesLetters,
                    Time = userDb.ReadingLettersTime
                },
                 new ReadingActivity()
                {
                    ReadingLiterature = ReadingType.Fiction,
                    Time = userDb.ReadingFictionTime
                },
                new ReadingActivity()
                {
                    ReadingLiterature = ReadingType.ProfessionalLiterature,
                    Time = userDb.ReadingProfessionalTime
                }
            };
                    ReadingType favouriteReadingActivity = readingActivities.OrderByDescending(x => x.Time).Select(x => x.ReadingLiterature).FirstOrDefault();
                    MessageHelper.PrintMessage($"The favourite reading activity of all Reading activities is {favouriteReadingActivity}", ConsoleColor.Green);
                }
                else
                {
                    MessageHelper.PrintMessage("You still don't have a reading activity.", ConsoleColor.White);
                }             
            }
            else if (option == 1)
            {
                MessageHelper.PrintMessage("EXERCISING", ConsoleColor.Blue);
                if (exercisingActivityCounter != 0)
                {
                    userDb.TotalTimeExercising = (userDb.ExercisingGeneralTime + userDb.ExercisingRunningTime + userDb.ExercisingSportTime) * 60;
                    double averageExercisingTime = (userDb.TotalTimeExercising) / (60 * exercisingActivityCounter);
                    MessageHelper.PrintMessage($"The total time of all Exercising activities is {userDb.TotalTimeExercising}", ConsoleColor.Green);
                    MessageHelper.PrintMessage($"The average time of all Exercising activities is {averageExercisingTime}", ConsoleColor.Green);
                    List<ExercisingActivity> exercisingActivities = new List<ExercisingActivity>()
                {
                    new ExercisingActivity()
                {
                    Exercising = ExercisingType.General,
                    Time = userDb.ExercisingGeneralTime
                },
                 new ExercisingActivity()
                {
                    Exercising = ExercisingType.Sport,
                    Time = userDb.ExercisingSportTime
                },
                new ExercisingActivity()
                {
                    Exercising = ExercisingType.Running,
                    Time = userDb.ExercisingRunningTime
                }
                };
                    ExercisingType favouriteExercisingType = exercisingActivities.OrderByDescending(x => x.Time).Select(x => x.Exercising).FirstOrDefault();
                    MessageHelper.PrintMessage($"The favourite exercising activity of all Exercising activities is {favouriteExercisingType}", ConsoleColor.Green);
                }
                else 
                {
                    MessageHelper.PrintMessage("You still don't have an exercising activity", ConsoleColor.White);
                }              
            }
            else if (option == 3)
            {
                MessageHelper.PrintMessage("WORKING", ConsoleColor.Blue);
                if (workingActivityCounter != 0)
                {
                    userDb.TotalTimeWorking = (userDb.WorkingHomeTime + userDb.WorkingOfficeTime) * 60;
                    double averageWorkingTime = (userDb.TotalTimeWorking) / (60 * workingActivityCounter);
                    MessageHelper.PrintMessage($"The total time of all Working activities is {userDb.TotalTimeWorking}", ConsoleColor.Green);
                    MessageHelper.PrintMessage($"The average time of all Working activities is {averageWorkingTime}", ConsoleColor.Green);
                    List<WorkingActivity> workingActivities = new List<WorkingActivity>()
                {
                 new WorkingActivity()
                {
                    WorkingLocation = WorkLocation.Home,
                    Time = userDb.WorkingHomeTime
                },
                    new WorkingActivity()
                {
                    WorkingLocation = WorkLocation.Office,
                    Time = userDb.WorkingOfficeTime
                }
                };
                    WorkLocation favouriteWorkingActivity = workingActivities.OrderByDescending(x => x.Time).Select(x => x.WorkingLocation).FirstOrDefault();
                    MessageHelper.PrintMessage($"The favourite working activity of all Working activities is {favouriteWorkingActivity}", ConsoleColor.Green);
                }
                else
                {
                    MessageHelper.PrintMessage("You still don't have a working activity", ConsoleColor.White);
                }  
            }
            else if (option == 4)
            {
                MessageHelper.PrintMessage("OTHER HOBBIES", ConsoleColor.Blue);
                if (otherHobbiesCounter != 0)
                {
                    userDb.TotalTimeOther = (userDb.OtherShoppingTime + userDb.OtherPartyingTime) * 60;
                    double averageOtherHobbiesTime = (userDb.TotalTimeOther) / (60 * otherHobbiesCounter);
                    MessageHelper.PrintMessage($"The average time of all the other hobbies activities is {averageOtherHobbiesTime}", ConsoleColor.Green);
                    List<OtherHobbies> otherHobbies = new List<OtherHobbies>();
                    if (userDb.OtherShoppingTime > 0)
                    {
                        OtherHobbies shoppingActivity = new OtherHobbies()
                        {
                            HobbyName = HobbyName.Shopping,
                            Time = userDb.OtherShoppingTime
                        };
                        otherHobbies.Add(shoppingActivity);
                    }
                    if (userDb.OtherPartyingTime > 0)
                    {
                        OtherHobbies partyingActivity = new OtherHobbies()
                        {
                            HobbyName = HobbyName.Partying,
                            Time = userDb.OtherPartyingTime
                        };
                        otherHobbies.Add(partyingActivity);
                    }
                    if (otherHobbies.Count > 0)
                    {
                        foreach (OtherHobbies activity in otherHobbies)
                        {
                            MessageHelper.PrintMessage($"Recoreded names of hobbies: {activity.HobbyName}", ConsoleColor.White);
                        }
                    }
                }
               
                else
                {
                    MessageHelper.PrintMessage("There is no recored hobbie yet", ConsoleColor.White);
                }    
            }
            else if (option == 5)
            {
                userDb.TotalTimeAll = userDb.TotalTimeExercising + userDb.TotalTimeWorking
                    + userDb.TotalTimeReading + userDb.TotalTimeOther;
                MessageHelper.PrintMessage($"Total time of all activities: {userDb.TotalTimeAll}", ConsoleColor.Green);
                List<TimeTracking.Domain.Models.Activity> allActivities = new List<TimeTracking.Domain.Models.Activity>()
                {
                 new ExercisingActivity()
                {
                    Type = ActivityType.Exercising,
                    Time = userDb.TotalTimeExercising
                },
                    new WorkingActivity()
                {
                    Type = ActivityType.Working,
                    Time = userDb.TotalTimeWorking
                },

                     new ReadingActivity()
                {
                    Type = ActivityType.Reading,
                    Time = userDb.TotalTimeReading
                },
                      new OtherHobbies()
                {
                    Type = ActivityType.OtherHobbies,
                    Time = userDb.TotalTimeOther
                }
                };

                ActivityType favouriteActivity = allActivities.OrderByDescending(x => x.Time).Select(x => x.Type).FirstOrDefault();
                MessageHelper.PrintMessage($"The favourite working activity of all Working activities is {favouriteActivity}", ConsoleColor.Green);
            }
            else if (option == 6)
            {
                MessageHelper.PrintMessage("Logging out...", ConsoleColor.Green);
                Console.Clear();
                 _uiService.LogInMenu();
            }
        }
    }
}
