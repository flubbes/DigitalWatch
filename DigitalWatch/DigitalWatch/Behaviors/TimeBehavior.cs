using System;
using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    public class TimeBehavior : IClockBehavior
    {
        public TimeBehavior(IClock clock)
        {
            clock.Tick += Tick;
        }

        public DateTime Time { get; set; }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
        }
    }
}