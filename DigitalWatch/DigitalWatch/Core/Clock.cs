using DigitalWatch.Behaviors;

namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;

        public IClockBehavior Behavior { get; set; }

        public void SwitchBehavior<T>() where T : IClockBehavior, new()
        {
            Behavior = new T();
        }
    }
}