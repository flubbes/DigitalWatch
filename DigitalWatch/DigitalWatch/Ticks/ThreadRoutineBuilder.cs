using System;

namespace DigitalWatch.Ticks
{
    public class ThreadRoutineBuilder
    {
        public Action Execute(Action routine)
        {
            throw new NotImplementedException();
        }

        protected virtual bool ShouldRun()
        {
            return true;
        }

        public void WrapAction(Action action)
        {
            while (ShouldRun())
            {
                action.Invoke();
            }
        }
    }
}