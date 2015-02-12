using System;

namespace DigitalWatch.Ticks
{
    public interface IThreadRoutineBuilder
    {
        Action Execute(Action routine);
    }
}