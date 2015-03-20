using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    public class TimeBehavior : ClockBehavior
    {
        public DateTime Time { get; set; }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
        }

        public override void SetClock(IClock clock)
        {
            clock.Tick += Tick;
        }

        public override void OnClick(IClockButtonClick buttonClick)
        {
            throw new NotImplementedException();
        }
    }
}