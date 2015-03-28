/*
 * Copyright (C) 2015  Fabian Berg and Marvin Karaschewski
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;
using System.Linq;

namespace DigitalWatch.Core
{
    /// <summary>
    /// The central class that depicts the Clock
    /// </summary>
    public class Clock : IClock
    {
        private event ClockTickEventHandler _tick;

        /// <summary>
        /// The eventhandler that handles the Ticks
        /// </summary>
        private ITickControl _tickControl;

        /// <summary>
        /// The eventhandler that handles the Ticks
        /// </summary>
        public event ClockTickEventHandler Tick
        {
            add
            {
                if (_tick == null || !_tick.GetInvocationList().ToList().Contains(value))
                {
                    _tick += value;
                }
            }
            remove
            {
                _tick -= value;
            }
        }

        /// <summary>
        /// The behavior that is currently active
        /// </summary>
        public ClockBehavior Behavior { get; set; }

        public void SwitchBehavior<T>(DateTime time) where T : ClockBehavior, new()
        {
            if (Behavior != null)
            {
                Behavior.Unload();
            }
            Behavior = new T();
            Behavior.Load(this, time);
        }

        /// <summary>
        /// The display that is currently active
        /// </summary>
        public IClockDisplay Display { get; set; }

        /// <summary>
        /// The control instance that gives the 'heartbeat'
        /// </summary>
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
        /// Switches the behavior to a given new one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            if (Behavior != null)
            {
                Behavior.Unload();
            }
            Behavior = new T();
            Behavior.Load(this);
        }

        /// <summary>
        /// Hands the clicks to the submerged structures.
        /// </summary>
        /// <param name="clockButtonClick"></param>
        public void RegisterClick(IClockButtonClick clockButtonClick)
        {
            if (clockButtonClick is LightClick)
            {
                Display.TriggerSwitchLightOn();
            }

            Behavior.OnClick(clockButtonClick);
        }

        /// <summary>
        /// Fires the tick event.
        /// </summary>
        protected void OnTick()
        {
            if (_tick != null)
            {
                _tick(this, new EventArgs());
            }
        }
    }
}