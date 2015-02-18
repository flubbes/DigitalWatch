using DigitalWatch.Behaviors;

namespace DigitalWatch.Core
{
    public interface IClock
    {
        event ClockTickEventHandler Tick;
        IClockBehavior Behavior { get; set; }
        void SwitchBehavior<T>() where T : IClockBehavior, new();
    }
}