
using SEDC.TimeTracking.Domain.Enums;
using System;

namespace SEDC.TimeTracking.Domain.Models
{
    public class WorkingActivity : Activity
    {
        public WorkLocation WorkingLocation { get; set; }
        public WorkingActivity()
        {
            Type = ActivityType.Working;
        }
        public override string GetInfo()
        {
            return $"{Type} from {WorkingLocation}";
        }
    }
}
