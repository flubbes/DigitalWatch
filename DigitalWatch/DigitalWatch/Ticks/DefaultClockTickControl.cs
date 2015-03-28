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

using System;
using System.Threading;

namespace DigitalWatch.Ticks
{
    /// <summary>
    /// The default solution for controlling the clocks ticking
    /// </summary>
    public class DefaultClockTickControl : ITickControl
    {
        /// <summary>
        /// The routine that is executed once the clock is started
        /// </summary>
        private Action _routine;

        /// <summary>
        /// Kicks off the routine
        /// </summary>
        /// <param name="routine"></param>
        public void Start(Action routine)
        {
            _routine = routine;
            new Thread(ThreadMethod) { IsBackground = true }.Start();
        }

        /// <summary>
        /// the thread routine
        /// </summary>
        private void ThreadMethod()
        {
            while (true)
            {
                _routine.Invoke();
                Thread.Sleep(1000);
            }
        }
    }
}