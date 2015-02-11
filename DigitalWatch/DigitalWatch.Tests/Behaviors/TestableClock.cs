using System;
using DigitalWatch.Core;

namespace DigitalWatch.Tests.Behaviors
{
    public class TestableClock : IClock
    {
        public event ClockTickEventHandler Tick;

        public void TriggerEvent()
        {
            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }
        }
    }
}