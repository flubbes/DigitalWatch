using System;

namespace DigitalWatch.Utilities
{
    /// <summary>
    /// A static class that provides helpful extensions for formatting DateTime
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Converts the DateTime to a format that is supported by the clocks display
        /// </summary>
        public static string ToDigitalClockFormat(this DateTime time)
        {
            var hour = time.Hour.ToString("D2");
            var minute = time.Minute.ToString("D2");
            return string.Format("{0}{1}", hour, minute);
        }
    }
}