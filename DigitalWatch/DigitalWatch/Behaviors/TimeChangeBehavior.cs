using System;
using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    public class TimeChangeBehavior : ClockBehavior
    {
        public DateTime Time { get; set; }

        /// <summary>
        /// Increments the property 'Time' by one (1) Minute
        /// </summary>
        public void IncrementMinutes()
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

        private void Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}