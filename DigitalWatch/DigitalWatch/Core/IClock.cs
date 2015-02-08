namespace DigitalWatch.Core
{
    public interface IClock
    {
        event ClockTickEventHandler Tick;
    }
}