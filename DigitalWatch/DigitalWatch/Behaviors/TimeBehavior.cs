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