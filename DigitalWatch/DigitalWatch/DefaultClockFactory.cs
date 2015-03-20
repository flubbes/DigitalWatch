using System.Collections.Generic;
using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;

namespace DigitalWatch
{
    public class DefaultClockFactory
    {
        public Clock CreateDefaultClock()
        {
            var defaultBehavior = new TimeBehavior();
            var defaultDisplay = new DefaultDisplay();
            var defaultButtons = new List<IClockButton>();
            var defaultClock = new Clock()
            {
                Behavior = defaultBehavior,
                Display = defaultDisplay,
                Buttons = defaultButtons
            };
            return defaultClock;
        }
    }
}