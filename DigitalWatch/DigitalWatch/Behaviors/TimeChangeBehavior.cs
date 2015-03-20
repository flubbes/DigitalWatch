using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    public class TimeChangeBehavior : ClockBehavior
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

        public override void SetClock(IClock clock)
        {
            throw new NotImplementedException();
        }

        public override void OnClick(IClockButtonClick buttonClick)
        {
            throw new NotImplementedException();
        }
    }
}