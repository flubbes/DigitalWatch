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

using DigitalWatch.Displays.ToggleLightEvent;
using DigitalWatch.Displays.UpdateEvent;
using System;
using System.Threading;

namespace DigitalWatch.Displays
{
    /// <summary>
    /// The default display for the clock
    /// </summary>
    public class DefaultDisplay : IClockDisplay
    {
        private int _countdownSeconds;

        /// <summary>
        /// The update routine for the display
        /// </summary>
        /// <param name="displayData"></param>
        public void TriggerUpdate(string displayData)
        {
            if (Update != null)
            {
                Update(this, new UpdateEventArgs
                {
                    DisplayData = displayData
                });
            }
        }

        /// <summary>
        /// Triggers the switch light on.
        /// </summary>
        public void TriggerSwitchLightOn()
        {
            if (SwitchLightOn != null)
            {
                SwitchLightOn(this, new EventArgs());
            }
            InitiateCountdown();
        }

        /// <summary>
        /// Triggers the switch light off.
        /// </summary>
        public void TriggerSwitchLightOff()
        {
            if (SwitchLightOff != null)
            {
                SwitchLightOff(this, new EventArgs());
            }
        }

        /// <summary>
        /// Initiates the countdown.
        /// </summary>
        private void InitiateCountdown()
        {
            if (IsDisplayLightActivated())
            {
                IncrementCountdownByFiveSeconds();
                new Thread(Countdown) { IsBackground = true }.Start();
            }
            else
            {
                IncrementCountdownByFiveSeconds();
            }
        }

        /// <summary>
        /// Increments the countdown by five seconds.
        /// </summary>
        private void IncrementCountdownByFiveSeconds()
        {
            _countdownSeconds += 5;
        }

        /// <summary>
        /// Determines whether the display light is activated.
        /// </summary>
        /// <returns></returns>
        private bool IsDisplayLightActivated()
        {
            if (_countdownSeconds > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Countdowns this instance.
        /// </summary>
        private void Countdown()
        {
            while (_countdownSeconds > 0)
            {
                Thread.Sleep(1000);
                _countdownSeconds -= 1;
            }
            TriggerSwitchLightOff();
        }

        public event UpdateEventHandler Update;

        public event SwitchLightOnEventHandler SwitchLightOn;

        public event SwitchLightOffEventHandler SwitchLightOff;
    }
}