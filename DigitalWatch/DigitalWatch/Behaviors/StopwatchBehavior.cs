using DigitalWatch.Core;
using System;
using DigitalWatch.Clicks;

namespace DigitalWatch.Behaviors
{
    public class StopwatchBehavior : ClockBehavior
    {
        private IClock _clock;
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
            _clock = clock;
            clock.Tick += Tick;
        }

        public override void OnClick(IClockButtonClick buttonClick)
        {
            if (buttonClick is ModeClick)
            {
                _clock.SwitchBehavior<TimeBehavior>();
            }
        }
    }
}