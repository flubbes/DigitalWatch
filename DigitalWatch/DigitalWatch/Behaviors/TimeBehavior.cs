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
    /// The behavior that contains the functionality for displaying the time of the watch
    /// </summary>
    public class TimeBehavior : SingletonClockBehavior<TimeBehavior>
    {
        private IClock _clock;
        private DateTime _time;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        private TimeBehavior Container
        {
            get { return Instance; }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTime Time
        {
            get { return Container._time; }
            set { Container._time = value; }
        }

        /// <summary>
        /// Contains all actions that are executed when the Tick Event occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Tick(object sender, EventArgs eventArgs)
        {
            Container._time = Time.AddSeconds(1.0);

            if (Container._clock.Behavior is TimeBehavior)
            {
                Container._clock.Display.TriggerUpdate(Time.ToDigitalClockFormat());
            }
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void Load(IClock clock)
        {
            Container._clock = clock;
            clock.Tick += Container.Tick;
            clock.Display.TriggerUpdate(Container._time.ToDigitalClockFormat());
        }

        /// <summary>
        /// Decides what happens if a certain button is clicked
        /// </summary>
        /// <param name="buttonClick"></param>
        public override void OnClick(IClockButtonClick buttonClick)
        {
            if (buttonClick is ModeClick)
            {
                Container._clock.SwitchBehavior<StopwatchBehavior>();
            }
            else if (buttonClick is SetClick)
            {
                Container._clock.SwitchBehavior<TimeChangeBehavior>(Time);
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
            Time = data;
            Load(clock);
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public override void Unload()
        {
        }
    }
}