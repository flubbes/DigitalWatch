using System;
using System.Threading;

namespace DigitalWatch.Ticks
{
    public class ThreadProxy : IThreadProxy
    {
        public void Run(Action action)
        {
            new Thread(action.Invoke).Start();
        }
    }
}