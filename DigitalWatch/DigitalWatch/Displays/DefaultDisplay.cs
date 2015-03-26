using System;
using System.Diagnostics;
using System.Threading;
using DigitalWatch.Displays.ToggleLightEvent;
using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
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

        public void TriggerSwitchLightOn()
        {
            if (SwitchLightOn != null)
            {
                SwitchLightOn(this, new EventArgs());
            }
            InitiateCountdown();
        }

        public void TriggerSwitchLightOff()
        {
            if (SwitchLightOff != null)
            {
                SwitchLightOff(this, new EventArgs());
            }
        }

        private void InitiateCountdown()
        {   
            if (DisplayLightIsNotActivated())
            {
                IncrementCountdownByFiveSeconds();
                new Thread(Countdown) { IsBackground = true }.Start();
            }
            else
            {
                IncrementCountdownByFiveSeconds();
            }
        }

        private void IncrementCountdownByFiveSeconds()
        {
            _countdownSeconds += 5;
        }

        private bool DisplayLightIsNotActivated()
        {
            if (_countdownSeconds > 0)
            {
                return false;
            }
            return true;
        }

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