using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    public class DefaultDisplay : IClockDisplay
    {
        public void TriggerUpdate(string displayData)
        {
            if(Update != null)
            {
                Update(this, new UpdateEventArgs
                {
                    DisplayData = displayData
                });
            }
        }

        public event UpdateEventHandler Update;
    }
}