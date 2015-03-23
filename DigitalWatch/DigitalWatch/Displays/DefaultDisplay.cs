using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    public class DefaultDisplay : IClockDisplay
    {
        /// <summary>
        /// The Update-Routine for the display
        /// </summary>
        /// <param name="displayData"></param>
        public void TriggerUpdate(string displayData)
        {
            if (Update != null)
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