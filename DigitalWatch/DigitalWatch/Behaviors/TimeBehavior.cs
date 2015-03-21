using DigitalWatch.Clicks;
using DigitalWatch.Core;
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
            get { return Instance as TimeBehavior; }
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
            Container.Time = Time.AddSeconds(1.0);
            var hourString = (Time.Hour < 10 ? "0" : "") + Time.Hour;
            var minuteString = (Time.Minute < 10 ? "0" : "") + Time.Minute;
            Container._clock.Display.TriggerUpdate(string.Format("{0}{1}", hourString, minuteString));
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void SetClock(IClock clock)
        {
            Container._clock = clock;
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
                Container._clock.SwitchBehavior<StopwatchBehavior>();
            }
            else if (buttonClick is SetClick)
            {
                Container._clock.SwitchBehavior<TimeChangeBehavior>();
            }
        }
    }
}