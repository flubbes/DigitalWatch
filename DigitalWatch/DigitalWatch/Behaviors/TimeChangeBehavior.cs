using DigitalWatch.Core;
using System;
using System.Windows.Forms;

namespace DigitalWatch.Behaviors
{
    public class TimeChangeBehavior : ClockBehavior
    {
        public DateTime Time { get; set; }

        /// <summary>
        /// Increments the property 'Time' by one (1) Second
        /// </summary>
        public void IncrementSecond()
        {
            Time = Time.AddSeconds(1.0);
        }

        /// <summary>
        /// Increments the property 'Time' by one (1) Minute
        /// </summary>
        public void IncrementMinute()
        {
            Time = Time.AddMinutes(1.0);
        }

        /// <summary>
        /// Increments the property 'Time' by one(1) Hour
        /// </summary>
        public void IncrementHour()
        {
            Time = Time.AddHours(1.0);
        }

        /// <summary>
        /// Hands the Clock object instance to the Behavior to work with
        /// </summary>
        /// <param name="clock"></param>
        public override void SetClock(IClock clock)
        {
            clock.Tick += Tick;
        }

        /// <summary>
        /// Contains all actions that are executed when the Tick Event occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            IncrementSecond();
        }

        /// <summary>
        /// Decides what happens if a certain button is clicked
        /// </summary>
        /// <param name="buttonClick"></param>
        public override void OnClick(IClockButtonClick buttonClick)
        {
            //TODO implement full logic
        }
    }
}