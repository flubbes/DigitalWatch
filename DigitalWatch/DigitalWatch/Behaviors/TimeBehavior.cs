using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    public class TimeBehavior : ClockBehavior
    {
        private IClock _clock;

        public DateTime Time { get; set; }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
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
                _clock.SwitchBehavior<StopwatchBehavior>();
            }
            else if (buttonClick is SetClick)
            {
                _clock.SwitchBehavior<TimeChangeBehavior>();
            }
        }
    }
}