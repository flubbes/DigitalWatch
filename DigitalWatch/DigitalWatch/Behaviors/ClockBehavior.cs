using DigitalWatch.Core;

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
        public abstract void SetClock(IClock clock);

        /// <summary>
        /// Called when a button is clicked.
        /// </summary>
        /// <param name="buttonClick">The button click.</param>
        public abstract void OnClick(IClockButtonClick buttonClick);
    }
}