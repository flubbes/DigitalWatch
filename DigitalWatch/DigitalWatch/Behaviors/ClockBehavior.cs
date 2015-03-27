using DigitalWatch.Core;
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The base class for every behavior that might be implemented
    /// </summary>
    public abstract class ClockBehavior
    {
        /// <summary>
        /// Sets the clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public abstract void Load(IClock clock);

        /// <summary>
        /// Called when a button is clicked.
        /// </summary>
        /// <param name="buttonClick">The button click.</param>
        public abstract void OnClick(IClockButtonClick buttonClick);

        /// <summary>
        /// Loads the behavior.
        /// </summary>
        /// <param name="clock">The clock.</param>
        /// <param name="data">The data.</param>
        public abstract void Load(IClock clock, DateTime data);
    }
}