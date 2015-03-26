using System;

namespace DigitalWatch.Ticks
{
    /// <summary>
    /// The interface from which all tick controlling units are derived
    /// </summary>
    public interface ITickControl
    {
        void Start(Action routine);
    }
}