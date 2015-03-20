using System;
using System.Threading;

namespace DigitalWatch.Ticks
{
    public class DefaultClockTickControl : ITickControl
    {
        private Action _routine;

        public DefaultClockTickControl()
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