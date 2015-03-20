using DigitalWatch.Core;
using System;
using DigitalWatch.Clicks;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The behavior that contains the functionality for the stopwatch 
    /// </summary>
    public class StopwatchBehavior : ClockBehavior
    {
        private IClock _clock;
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// Increments the stopwatch's timespan by a second
        /// </summary>
        public void IncrementTimeSpanBySecond()
        {
            TimeSpan = TimeSpan.Add(new TimeSpan(0, 0, 0, 1));
        }

        /// <summary>
        /// Increments the TimeSpan of the Stopwatch when a Tick occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Tick(object sender, EventArgs eventArgs)
        {
            IncrementTimeSpanBySecond();
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
                _clock.SwitchBehavior<TimeBehavior>();
            }
        }
    }
}