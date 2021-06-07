using System;

namespace SEDC.TrackingTime.Services.Helpers
{
    public static class ValidationHelper
    {
        public static bool PasswordValidation(string password)
        {
            if(password.Length < 6)
            {
                return false;
            }

            bool isNum = false;
            bool isUpperCase = false;
            foreach(char ch in password)
            {
                isNum = int.TryParse(ch.ToString(), out int number);
                if (isNum)
                    isNum = true;

                if (char.IsUpper(ch))
                    isUpperCase = true;
            }

            if (!isNum || !isUpperCase)
                return false;
 
            return true;       
        }
        
        public static bool ValidateUsername(string username)
        {
            if(username.Length < 5)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateName(string name)
        {
            if (name.Length < 2)
                return false;

            bool isNum = false;
            foreach(char ch in name)
            {
                isNum = int.TryParse(ch.ToString(), out int number);
                if (isNum)
                {
                    isNum = true;
                    break;
                }    
            }

            if (isNum)
                return false;

            return true;
        }

        public static bool ValidateAge(int age)
        {
            return age > 18 && age < 120;
        }
        public static int ValidateNumber(string number, int numberRange)
        {
            bool isNum = int.TryParse(number.ToString(), out int num);
            if (!isNum)
            {
                return -1;
            }
            if(num < 1 || num > numberRange)
            {
                return -1;
            }
            return num;
        }

    }
}
