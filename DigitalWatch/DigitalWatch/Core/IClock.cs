using DigitalWatch.Behaviors;
using DigitalWatch.Displays;

namespace DigitalWatch.Core
{
    /// <summary>
    /// The interface from which the every clock is derived
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// The eventhandler that handles the Ticks
        /// </summary>
        event ClockTickEventHandler Tick;

        /// <summary>
        /// The behavior that is currently active
        /// </summary>
        ClockBehavior Behavior { get; set; }

        /// <summary>
        /// Switches the behavior to a given new one
        /// </summary>
        void SwitchBehavior<T>() where T : ClockBehavior, new();

        /// <summary>
        /// The display that is currently active
        /// </summary>
        IClockDisplay Display { get; set; }

        /// <summary>
        /// Hands the clicks to the submerged structures
        /// </summary>
        void RegisterClick(IClockButtonClick clockButtonClick);
    }
}