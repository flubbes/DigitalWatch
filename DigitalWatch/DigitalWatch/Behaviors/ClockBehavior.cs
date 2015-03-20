using DigitalWatch.Core;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The base class for every behavior that might be implemented
    /// </summary>
    public abstract class ClockBehavior
    {
        public abstract void SetClock(IClock clock);

        public abstract void OnClick(IClockButtonClick buttonClick);
    }
}