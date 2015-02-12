using System;

namespace DigitalWatch.Ticks
{
    public interface IThreadProxy
    {
        void Run(Action action);
    }
}