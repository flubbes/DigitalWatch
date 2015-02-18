using System;
using DigitalWatch.Behaviors;
using DigitalWatch.Core;

namespace DigitalWatch.Tests.Core
{
    public class TestableClock : IClock
    {
        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            
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