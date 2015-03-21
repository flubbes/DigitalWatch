using DigitalWatch.Ticks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading;

namespace DigitalWatch.Tests.Ticks
{
    [TestFixture]
    public class DefaultClockTickControlTests
    {
        private ITickControl _tickControl;

        [SetUp]
        public void SetUp()
        {
            _tickControl = new DefaultClockTickControl();
        }

        [Test]
        public void IsDerivedFromTickInterface()
        {
            _tickControl.Should().BeAssignableTo<ITickControl>();
        }

        [Test]
        public void TriggersEverySecond()
        {
            var counter = 0;
            Action a = () => counter++;
            _tickControl.Start(a);
            Thread.Sleep(3000);
            counter.Should().BeInRange(3, 4);
        }
    }
}