﻿using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    public interface IClockDisplay
    {
        event UpdateEventHandler Update;
    }
}