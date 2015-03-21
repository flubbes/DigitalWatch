﻿using DigitalWatch.Behaviors;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;

namespace DigitalWatch.Core
{
    /// <summary>
    /// The central class that depicts the Clock
    /// </summary>
    public class Clock : IClock
    {
        /// <summary>
        /// The eventhandler that handles the Ticks
        /// </summary>
        private ITickControl _tickControl;

        public event ClockTickEventHandler Tick;

        /// <summary>
        /// The behavior that is currently active
        /// </summary>
        public ClockBehavior Behavior { get; set; }

        /// <summary>
        /// The display that is currently active
        /// </summary>
        public IClockDisplay Display { get; set; }


        /// <summary>
        /// The control instance that gives the 'heartbeat'
        /// </summary>
        public ITickControl TickControl { get; set; }

        public ITickControl TickControl
        {
            get { return _tickControl; }
            set
            {
                _tickControl = value;
                _tickControl.Start(OnTick);
            }
        }

        /// <summary>
        /// Switches the behavior to a given new one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            Behavior = new T();
            Behavior.SetClock(this);
        }

        /// <summary>
        /// Hands the clicks to the submerged structures
        /// </summary>
        /// <param name="clockButtonClick"></param>
        public void RegisterClick(IClockButtonClick clockButtonClick)
        {
            Behavior.OnClick(clockButtonClick);
        }

        protected void OnTick()
        {
            if (Tick != null)
            {
                Tick(this, new EventArgs());
            }
        }
    }
}