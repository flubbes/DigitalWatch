using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    public class TimeBehavior : SingletonClockBehavior
    {
        private IClock _clock;

        public DateTime Time { get; set; }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
            var hourString = (Time.Hour < 10 ? "0" : "") + Time.Hour;
            var minuteString = (Time.Minute < 10 ? "0" : "") + Time.Minute;
            _clock.Display.OnUpdate(string.Format("{0}:{1}", hourString, minuteString));
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