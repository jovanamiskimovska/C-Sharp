
using SEDC.TimeTracking.Domain.Enums;
using System;

namespace SEDC.TimeTracking.Domain.Models
{
    public class OtherHobbies : Activity
    {
        public HobbyName HobbyName { get; set; }

        public OtherHobbies()
        {
            Type = ActivityType.OtherHobbies;
        }
        public override string GetInfo()
        {
            return $"Doing {Type} : {HobbyName}";
        }
    }
}
