using System;

namespace DigitalWatch.Ticks
{
    public interface ITick
    {
        void Start(Action routine);
    }
}