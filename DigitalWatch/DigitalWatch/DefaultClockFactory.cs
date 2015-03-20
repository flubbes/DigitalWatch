using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;

namespace DigitalWatch
{
    /// <summary>
    /// A factory to create a default clock and all of its properties
    /// </summary>
    public class DefaultClockFactory
    {
        /// <summary>
        /// Creates a new default clock with all of its properties
        /// </summary>
        /// <returns>The built clock</returns>
        public Clock Create()
        {
            var defaultBehavior = new TimeBehavior();
            var defaultDisplay = new DefaultDisplay();

            var defaultClock = new Clock
            {
                Behavior = defaultBehavior,
                Display = defaultDisplay,
                TickControl = new DefaultClockTickControl()
            };
            defaultBehavior.SetClock(defaultClock);
            return defaultClock;
        }
    }
}