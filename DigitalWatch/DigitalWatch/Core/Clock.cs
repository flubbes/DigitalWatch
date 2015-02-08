namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;
    }
}