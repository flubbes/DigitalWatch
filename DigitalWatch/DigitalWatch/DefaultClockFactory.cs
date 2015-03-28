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
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;

namespace DigitalWatch
{
    /// <summary>
    /// A factory to create a default clock and all of its properties
    /// </summary>
    public class DefaultClockFactory
    {
        /// <summary>
        /// Creates a new default clock with all of its properties
        /// </summary>
        /// <returns>The built clock</returns>
        public Clock Create()
        {
            var defaultBehavior = new TimeBehavior();
            defaultBehavior.Time = DateTime.Now;
            var defaultDisplay = new DefaultDisplay();

            var defaultClock = new Clock
            {
                Behavior = defaultBehavior,
                Display = defaultDisplay,
                TickControl = new DefaultClockTickControl()
            };
            defaultBehavior.Load(defaultClock);
            return defaultClock;
        }
    }
}