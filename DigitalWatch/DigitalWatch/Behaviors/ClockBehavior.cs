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

using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The base class for every behavior that might be implemented
    /// </summary>
    public abstract class ClockBehavior
    {
        /// <summary>
        /// Sets the clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public abstract void Load(IClock clock);

        /// <summary>
        /// Called when a button is clicked.
        /// </summary>
        /// <param name="buttonClick">The button click.</param>
        public abstract void OnClick(IClockButtonClick buttonClick);

        /// <summary>
        /// Loads the behavior.
        /// </summary>
        /// <param name="clock">The clock.</param>
        /// <param name="data">The data.</param>
        public abstract void Load(IClock clock, DateTime data);

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public abstract void Unload();
    }
}