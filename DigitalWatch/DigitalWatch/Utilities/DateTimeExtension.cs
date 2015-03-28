/*
 * Copyright (C) 2015  Fabian Berg and Marvin Karaschewski
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

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