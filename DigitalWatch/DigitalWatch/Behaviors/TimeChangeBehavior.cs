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

using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Utilities;
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The behavior to change the time
    /// </summary>
    public class TimeChangeBehavior : ClockBehavior
    {
        private IClock _clock;
        private Mode _mode;
        private bool _isFlashing;

        /// <summary>
        /// The internal  ode of the timeChangeBehavior
        /// </summary>
        private enum Mode
        {
            ChangeHour,
            ChangeMinute
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Increments the property 'Time' by one (1) Minute
        /// </summary>
        public void IncrementMinute()
        {
            var tempTime = Time.AddMinutes(1.0);
            if (tempTime.Hour != Time.Hour)
            {
                tempTime -= TimeSpan.FromHours(1);
            }
            Time = tempTime;
        }

        /// <summary>
        /// Increments the property 'Time' by one(1) Hour
        /// </summary>
        public void IncrementHour()
        {
            Time = Time.AddHours(1.0);
        }

        /// <summary>
        /// Hands the Clock object instance to the Behavior to work with
        /// </summary>
        /// <param name="clock"></param>
        public override void Load(IClock clock)
        {
            clock.Tick += Tick;
            _clock = clock;
        }

        /// <summary>
        /// Contains all actions that are executed when the Tick Event occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            var toUpdate = Time.ToDigitalClockFormat();
            if (_mode == Mode.ChangeHour)
            {
                if (!_isFlashing)
                {
                    toUpdate = Time.Minute.ToString("D2");
                }
            }
            else
            {
                if (!_isFlashing)
                {
                    toUpdate = Time.Hour.ToString("D2") + "__";
                }
            }
            _clock.Display.TriggerUpdate(toUpdate);
            _isFlashing = !_isFlashing;
        }

        /// <summary>
        /// Decides what happens if a certain button is clicked
        /// </summary>
        /// <param name="buttonClick"></param>
        public override void OnClick(IClockButtonClick buttonClick)
        {
            if (buttonClick is ModeClick)
            {
                if (_mode == Mode.ChangeHour)
                {
                    IncrementHour();
                }
                else
                {
                    IncrementMinute();
                }
                _clock.Display.TriggerUpdate(Time.ToDigitalClockFormat());
            }
            else if (buttonClick is SetClick)
            {
                if (_mode == Mode.ChangeHour)
                {
                    _mode = Mode.ChangeMinute;
                }
                else
                {
                    _clock.SwitchBehavior<TimeBehavior>(Time);
                }
            }
        }

        /// <summary>
        /// Loads the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Load(IClock clock, DateTime data)
        {
            Load(clock);
            Time = data;
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public override void Unload()
        {
            _clock.Tick -= Tick;
        }
    }
}