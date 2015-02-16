using System;
using System.Diagnostics;
using System.Threading;
using DigitalWatch.Ticks;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Ticks
{
    [TestFixture]
    public class ThreadProxyTests
    {
        private IThreadProxy _proxy;

        [SetUp]
        public void SetUp()
        {
            _proxy = new ThreadProxy();
        }

        [Test]
        public void CanRunActionInThread()
        {
            var mainThread = Thread.CurrentThread;
            var actuallyExecutingThread = mainThread;
            var isThreadDone = false;
            Action action = () =>
            {
                actuallyExecutingThread = Thread.CurrentThread;
                isThreadDone = true;
            };

            _proxy.Run(action);

            WaitUntilBooleanIsTrue(ref isThreadDone);
            actuallyExecutingThread.Should().NotBe(mainThread);
        }

        private static void WaitUntilBooleanIsTrue(ref bool threadIsDone)
        {
            while (!threadIsDone)
            {
                Debug.WriteLine("Waiting for boolean to be true...");
            }
        }
    }
}
