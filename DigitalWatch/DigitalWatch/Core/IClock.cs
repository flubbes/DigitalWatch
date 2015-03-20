using DigitalWatch.Behaviors;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;

namespace DigitalWatch.Core
{
    public interface IClock
    {
        event ClockTickEventHandler Tick;

        ClockBehavior Behavior { get; set; }

        void SwitchBehavior<T>() where T : ClockBehavior, new();

        IClockDisplay Display { get; set; }

        ITickControl TickControl { get; set; }

        void RegisterClick(IClockButtonClick clockButtonClick);
    }
}