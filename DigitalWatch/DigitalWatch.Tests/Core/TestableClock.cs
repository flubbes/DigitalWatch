﻿using DigitalWatch.Behaviors;
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

        public IClockDisplay Display
        {
            get;
            set;
        }

        public ITickControl TickControl
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

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