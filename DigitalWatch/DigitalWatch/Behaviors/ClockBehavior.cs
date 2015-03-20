using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    public abstract class ClockBehavior
    {
        public abstract void SetClock(IClock clock);

        public abstract void OnClick(IClockButtonClick buttonClick);
    }
}