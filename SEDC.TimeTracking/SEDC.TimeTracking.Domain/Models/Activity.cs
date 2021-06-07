
using SEDC.TimeTracking.Domain.Enums;
using SEDC.TimeTracking.Domain.Interfaces;
using System;

namespace SEDC.TimeTracking.Domain.Models
{
   public abstract class Activity : BaseEntity
    {
        public ActivityType Type { get; set; }
        public double Time { get; set; }

    }
}
