using System;
using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    public class StopwatchBehavior : ClockBehavior
    {
        public TimeSpan TimeSpan { get; set; }

        public void IncrementTimeSpan()
        {
            TimeSpan = TimeSpan.Add(new TimeSpan(0, 0, 0, 1));
        }

        private void Tick(object sender, EventArgs eventArgs)
        {
            IncrementTimeSpan();
        }

        public override void SetClock(IClock clock)
        {
            clock.Tick += Tick;
        }
    }
}