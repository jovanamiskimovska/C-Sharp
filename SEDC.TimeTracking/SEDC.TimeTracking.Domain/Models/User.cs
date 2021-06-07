
using SEDC.TimeTracking.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SEDC.TimeTracking.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Activity> Activities { get; set; }
        public double ExercisingGeneralTime { get; set; }
        public double ExercisingSportTime { get; set; }
        public double ExercisingRunningTime { get; set; }
        public double WorkingHomeTime { get; set; }
        public double WorkingOfficeTime { get; set; }
        public double ReadingLettersTime { get; set; }
        public double ReadingFictionTime { get; set; }
        public double ReadingProfessionalTime { get; set; }
        public double OtherPartyingTime { get; set; }
        public double OtherShoppingTime { get; set; }
        public double TotalTimeReading { get; set; }
        public double TotalTimeExercising { get; set; }
        public double TotalTimeWorking { get; set; }
        public double TotalTimeOther { get; set; }
        public double TotalTimeAll { get; set; }
        public bool isDeactivated { get; set; }

        public User()
        {           
            Activities = new List<Activity>();
        }
        public override string GetInfo()
        {
            return $"User: {Id} - {FirstName} {LastName}, username: {Username}";
        }
    }
}
