using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    /// <summary>
    /// The interface from which all the displays must be derived
    /// </summary>
    public interface IClockDisplay
    {
        event UpdateEventHandler Update;

        void TriggerUpdate(string displayData);
    }
}