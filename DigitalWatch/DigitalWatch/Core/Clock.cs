using DigitalWatch.Behaviors;

namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            Behavior = new T();
        }
    }
}