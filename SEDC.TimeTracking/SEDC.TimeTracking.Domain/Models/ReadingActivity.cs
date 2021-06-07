
using SEDC.TimeTracking.Domain.Enums;
using System;

namespace SEDC.TimeTracking.Domain.Models
{
    public class ReadingActivity : Activity
    {
        public int Pages { get; set; }
        public ReadingType ReadingLiterature { get; set; }
        public ReadingActivity()
        {
            Type = ActivityType.Reading;
        }
        public override string GetInfo()
        {
            return $"Read {Pages} of {ReadingLiterature}";
        }
    }
}
