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
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The behavior that contains the functionality for the stopwatch
    /// </summary>
    public class StopwatchBehavior : ClockBehavior
    {
        private IClock _clock;

        /// <summary>
        /// Gets or sets the time span.
        /// </summary>
        /// <value>
        /// The time span.
        /// </value>
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Increments the stopwatch's timespan by a second
        /// </summary>
        public void IncrementTimeSpanBySecond()
        {
            TimeSpan = TimeSpan.Add(new TimeSpan(0, 0, 0, 1));
        }

        /// <summary>
        /// Increments the TimeSpan of the Stopwatch when a Tick occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Tick(object sender, EventArgs eventArgs)
        {
            if (IsRunning)
            {
                IncrementTimeSpanBySecond();
                _clock.Display.TriggerUpdate(GetTimeSpanString());
            }
        }

        /// <summary>
        /// Delivers a string containing the timespans data
        /// </summary>
        /// <returns></returns>
        private string GetTimeSpanString()
        {
            var minuteString = TimeSpan.Minutes.ToString();
            var secondString = TimeSpan.Seconds.ToString();
            return minuteString + secondString;
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void Load(IClock clock)
        {
            _clock = clock;
            _clock.Display.TriggerUpdate(GetTimeSpanString());
            clock.Tick += Tick;
        }

        /// <summary>
        /// Decides what happens if a certain button is clicked
        /// </summary>
        /// <param name="buttonClick"></param>
        public override void OnClick(IClockButtonClick buttonClick)
        {
            if (buttonClick is ModeClick)
            {
                _clock.SwitchBehavior<TimeBehavior>();
            }

            if (buttonClick is SetClick)
            {
                if (IsRunning)
                {
                    IsRunning = false;
                }
                else
                {
                    IsRunning = true;
                }
            }

            if (buttonClick is LongSetClick)
            {
                IsRunning = false;
                TimeSpan = new TimeSpan(0, 0, 0, 0, 0);
                _clock.Display.TriggerUpdate(GetTimeSpanString());
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public override void Unload()
        {
            _clock.Tick -= Tick;
        }

        /// <summary>
        /// Starts the Stopwatch
        /// </summary>
        public void Start()
        {
            IsRunning = true;
        }

        /// <summary>
        /// Stops the Stopwatch
        /// </summary>
        public void Stop()
        {
            IsRunning = false;
        }
    }
}