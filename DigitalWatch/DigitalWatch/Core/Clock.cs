using DigitalWatch.Behaviors;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;

namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }

        public IClockDisplay Display { get; set; }

        public ITickControl TickControl { get; set; }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            Behavior = new T();
            Behavior.SetClock(this);
        }

        public void RegisterClick(IClockButtonClick clockButtonClick)
        {
            Behavior.OnClick(clockButtonClick);
        }
    }
}