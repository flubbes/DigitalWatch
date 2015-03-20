using DigitalWatch.Behaviors;
using DigitalWatch.Displays;

namespace DigitalWatch.Core
{
    public interface IClock
    {
        event ClockTickEventHandler Tick;

        ClockBehavior Behavior { get; set; }

        void SwitchBehavior<T>() where T : ClockBehavior, new();

        IClockDisplay Display { get; set; }

        void RegisterClick(IClockButtonClick clockButtonClick);
    }
}