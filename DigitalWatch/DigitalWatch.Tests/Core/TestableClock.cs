using System;
using DigitalWatch.Behaviors;
using DigitalWatch.Core;

namespace DigitalWatch.Tests.Core
{
    public class TestableClock : IClock
    {
        public event ClockTickEventHandler Tick;

        public IClockBehavior Behavior
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SwitchBehavior<T>() where T : IClockBehavior, new()
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