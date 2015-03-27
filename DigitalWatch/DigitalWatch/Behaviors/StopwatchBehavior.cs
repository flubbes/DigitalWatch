using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The behavior that contains the functionality for the stopwatch
    /// </summary>
    public class StopwatchBehavior : ClockBehavior
    {
        private IClock _clock;

        /// <summary>
        /// Gets or sets the time span.
        /// </summary>
        /// <value>
        /// The time span.
        /// </value>
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; set; }

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
            if (IsRunning)
            {
                IncrementTimeSpanBySecond();
                _clock.Display.TriggerUpdate(GetTimeSpanString());
            }
        }

        /// <summary>
        /// Delivers a string containing the timespans data
        /// </summary>
        /// <returns></returns>
        private string GetTimeSpanString()
        {
            var minuteString = TimeSpan.Minutes.ToString();
            var secondString = TimeSpan.Seconds.ToString();
            return minuteString + secondString;
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void Load(IClock clock)
        {
            _clock = clock;
            _clock.Display.TriggerUpdate(GetTimeSpanString());
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

            if (buttonClick is SetClick)
            {
                if (IsRunning)
                {
                    IsRunning = false;
                }
                else
                {
                    IsRunning = true;
                }
            }

            if (buttonClick is LongSetClick)
            {
                IsRunning = false;
                TimeSpan = new TimeSpan(0, 0, 0, 0, 0);
                _clock.Display.TriggerUpdate(GetTimeSpanString());
            }
        }

        /// <summary>
        /// Loads the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Load(IClock clock, DateTime data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public override void Unload()
        {
        }

        /// <summary>
        /// Starts the Stopwatch
        /// </summary>
        public void Start()
        {
            IsRunning = true;
        }

        /// <summary>
        /// Stops the Stopwatch
        /// </summary>
        public void Stop()
        {
            IsRunning = false;
        }
    }
}