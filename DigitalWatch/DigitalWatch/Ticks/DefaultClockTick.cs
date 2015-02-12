using System;

namespace DigitalWatch.Ticks
{
    public class DefaultClockTick : ITick
    {
        private readonly IThreadProxy _thread;
        private readonly IThreadRoutineBuilder _builder;

        public DefaultClockTick(IThreadProxy thread, IThreadRoutineBuilder builder)
        {
            _thread = thread;
            _builder = builder;
        }

        public void Start(Action routine)
        {
            _thread.Run(_builder.Execute(routine));
        }
    }
}