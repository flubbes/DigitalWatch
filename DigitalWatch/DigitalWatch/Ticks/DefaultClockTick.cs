using System;
using System.Threading;

namespace DigitalWatch.Ticks
{
    public class DefaultClockTick : ITick
    {
        private Action _routine;

        public DefaultClockTick()
        {
        }

        public void Start(Action routine)
        {
            _routine = routine;
            new Thread(ThreadMethod) { IsBackground = true }.Start();
        }

        private void ThreadMethod()
        {
            while (true)
            {
                _routine.Invoke();
                Thread.Sleep(1000);
            }
        }
    }
}