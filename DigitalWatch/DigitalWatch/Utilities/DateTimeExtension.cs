using System;

namespace DigitalWatch.Utilities
{
    public static class DateTimeExtension
    {
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