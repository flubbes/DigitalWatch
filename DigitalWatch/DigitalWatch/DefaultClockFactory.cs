using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;

namespace DigitalWatch
{
    public class DefaultClockFactory
    {
        public Clock Create()
        {
            var defaultBehavior = new TimeBehavior();
            var defaultDisplay = new DefaultDisplay();
            var defaultClock = new Clock
            {
                Behavior = defaultBehavior,
                Display = defaultDisplay
            };
            return defaultClock;
        }
    }
}