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
            var result = "";
            if (time.Hour < 10)
            {
                result += string.Format("0{0}", time.Hour);
            }
            else
            {
                result += time.Hour;
            }
            if (time.Minute < 10)
            {
                result += string.Format("0{0}", time.Minute);
            }
            else
            {
                result += time.Minute;
            }
            return result;
        }
    }
}