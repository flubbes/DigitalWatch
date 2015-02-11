using System;
using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    public class StopwatchBehavior : IClockBehavior
    {
        public TimeSpan TimeSpan { get; set; }

        public StopwatchBehavior(IClock clock)
        {
            clock.Tick += Tick;
        }

        public void IncrementTimeSpan()
        {
            TimeSpan = TimeSpan.Add(new TimeSpan(0, 0, 0, 1));
        }

        private void Tick(object sender, EventArgs eventArgs)
        {
            IncrementTimeSpan();
        }
    }
}