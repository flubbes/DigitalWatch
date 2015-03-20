using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{  
    /// <summary>
    /// The behavior that contains the functionality for displaying the time of the watch 
    /// </summary>
    public class TimeBehavior : SingletonClockBehavior
    {
        private IClock _clock;

        public DateTime Time { get; set; }

        /// <summary>
        /// Contains all actions that are executed when the Tick Event occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
            var hourString = (Time.Hour < 10 ? "0" : "") + Time.Hour;
            var minuteString = (Time.Minute < 10 ? "0" : "") + Time.Minute;
            _clock.Display.OnUpdate(string.Format("{0}{1}", hourString, minuteString));
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void SetClock(IClock clock)
        {
            _clock = clock;
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
                _clock.SwitchBehavior<StopwatchBehavior>();
            }
            else if (buttonClick is SetClick)
            {
                _clock.SwitchBehavior<TimeChangeBehavior>();
            }
        }
    }
}