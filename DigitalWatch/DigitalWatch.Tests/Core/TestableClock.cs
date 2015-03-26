using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;

namespace DigitalWatch.Tests.Core
{
    public class TestableClock : IClock
    {
        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
        }

        public void SwitchBehavior<T>(DateTime time) where T : ClockBehavior, new()
        {
            throw new NotImplementedException();
        }

        public IClockDisplay Display
        {
            get;
            set;
        }

        public ITickControl TickControl { get; set; }

        public void RegisterClick(IClockButtonClick clockButtonClick)
        {
            throw new NotImplementedException();
        }

        public void TriggerTickEvent()
        {
            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }
        }
    }
}