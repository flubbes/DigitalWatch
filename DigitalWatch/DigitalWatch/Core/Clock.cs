using System.Collections.Generic;
using DigitalWatch.Behaviors;
using DigitalWatch.Displays;

namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }
        public IClockDisplay Display { get; set; }
        public List<IClockButton> Buttons { get; set; }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            Behavior = new T();
        }
    }
}