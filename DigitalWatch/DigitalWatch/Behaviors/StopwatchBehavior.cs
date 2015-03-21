﻿using DigitalWatch.Core;
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
            var hourString = TimeSpan.Hours.ToString();
            var minuteString = TimeSpan.Minutes.ToString();
            return hourString + minuteString;
        }

        /// <summary>
        /// Hands the Clock object to the behavior and hooks up the tick event
        /// </summary>
        /// <param name="clock"></param>
        public override void SetClock(IClock clock)
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
                TimeSpan = new TimeSpan(0,0,0,0,0);
            }
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