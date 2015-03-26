﻿using System;
using System.Threading;
using DigitalWatch.Displays.ToggleLightEvent;
﻿using DigitalWatch.Displays.ToggleLightEvent;
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