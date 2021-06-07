
using SEDC.TimeTracking.Domain.Enums;
using System;

namespace SEDC.TimeTracking.Domain.Models
{
    public class ExercisingActivity : Activity
    {
        public ExercisingType Exercising { get; set; }
        public ExercisingActivity()
        {
            Type = ActivityType.Exercising;
        }
        public override string GetInfo()
        {
            return $"{Type}: {Exercising}";
        }

    }
}
