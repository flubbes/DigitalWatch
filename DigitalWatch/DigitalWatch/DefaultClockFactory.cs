using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using System.Collections.Generic;

namespace DigitalWatch
{
    public class DefaultClockFactory
    {
        public Clock Create()
        {
            var defaultBehavior = new TimeBehavior();
            var defaultDisplay = new DefaultDisplay();
            var defaultButtons = new List<IClockButton>();
            var defaultClock = new Clock
            {
                Behavior = defaultBehavior,
                Display = defaultDisplay,
                Buttons = defaultButtons
            };
            return defaultClock;
        }
    }
}