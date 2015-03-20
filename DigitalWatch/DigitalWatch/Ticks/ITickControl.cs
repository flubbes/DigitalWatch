using System;

namespace DigitalWatch.Ticks
{
    public interface ITickControl
    {
        void Start(Action routine);
    }
}