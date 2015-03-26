using System;

namespace DigitalWatch.Displays.UpdateEvent
{
    /// <summary>
    /// Custom EventArgs for updating Displays
    /// </summary>
    public class UpdateEventArgs : EventArgs
    {
        /// <summary>
        /// the data that is displayed on the display
        /// </summary>
        public string DisplayData { get; set; }
    }
}