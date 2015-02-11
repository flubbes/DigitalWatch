using System;

namespace DigitalWatch.Behaviors
{
    public class TimeChangeBehavior : IClockBehavior
    {
        public DateTime Time { get; set; }

        public void IncrementMinutes()
        {
            Time = Time.AddMinutes(1.0);
        }

        public void IncrementHour()
        {
            Time = Time.AddHours(1.0);
        }
    }
}