using System;
using System.Threading;

namespace DigitalWatch.Ticks
{
    /// <summary>
    /// The default solution for controlling the clocks ticking
    /// </summary>
    public class DefaultClockTickControl : ITickControl
    {
        /// <summary>
        /// The routine that is executed once the clock is started 
        /// </summary>
        private Action _routine;

        public DefaultClockTickControl()
        {
        }

        /// <summary>
        /// Kicks off the routine
        /// </summary>
        /// <param name="routine"></param>
        public void Start(Action routine)
        {
            _routine = routine;
            new Thread(ThreadMethod) { IsBackground = true }.Start();
        }

        /// <summary>
        /// the thread routine
        /// </summary>
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