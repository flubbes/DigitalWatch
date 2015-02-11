using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    public class DefaultDisplay : IClockDisplay
    {
        public void TriggerUpdate(string displayData)
        {
            Update(this, new UpdateEventArgs
            {
                DisplayData = displayData
            });
        }

        public event UpdateEventHandler Update;
    }
}