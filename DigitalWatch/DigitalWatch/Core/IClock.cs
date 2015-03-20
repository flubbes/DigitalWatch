using DigitalWatch.Behaviors;

namespace DigitalWatch.Core
{
    public interface IClock
    {
        event ClockTickEventHandler Tick;

        ClockBehavior Behavior { get; set; }

        void SwitchBehavior<T>() where T : ClockBehavior, new();
    }
}