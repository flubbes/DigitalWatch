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
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;

namespace DigitalWatch.Core
{
    /// <summary>
    /// The interface from which the every clock is derived
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// The eventhandler that handles the Ticks
        /// </summary>
        event ClockTickEventHandler Tick;

        /// <summary>
        /// The behavior that is currently active
        /// </summary>
        ClockBehavior Behavior { get; set; }

        /// <summary>
        /// Switches the behavior to a given new one
        /// </summary>
        void SwitchBehavior<T>() where T : ClockBehavior, new();

        /// <summary>
        /// Switches the behavior.
        /// </summary>
        /// <typeparam name="T">The behavior you want to switch to</typeparam>
        /// <param name="time">The time to give to the loaded behavior.</param>
        void SwitchBehavior<T>(DateTime time) where T : ClockBehavior, new();

        /// <summary>
        /// The display that is currently active
        /// </summary>
        IClockDisplay Display { get; set; }

        /// <summary>
        /// Hands the clicks to the submerged structures
        /// </summary>
        ITickControl TickControl { get; set; }

        /// <summary>
        /// Registers the click.
        /// </summary>
        /// <param name="clockButtonClick">The clock button click.</param>
        void RegisterClick(IClockButtonClick clockButtonClick);
    }
}