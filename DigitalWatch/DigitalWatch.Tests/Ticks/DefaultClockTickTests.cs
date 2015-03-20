using DigitalWatch.Ticks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading;

namespace DigitalWatch.Tests.Ticks
{
    [TestFixture]
    public class DefaultClockTickTests
    {
        private ITick _tick;

        [SetUp]
        public void SetUp()
        {
            _tick = new DefaultClockTick();
        }

        [Test]
        public void IsDerivedFromTickInterface()
        {
            _tick.Should().BeAssignableTo<ITick>();
        }

        [Test]
        public void TriggersEverySecond()
        {
            var counter = 0;
            Action a = () => counter++;
            _tick.Start(a);
            Thread.Sleep(3000);
            counter.Should().Be(3);
        }
    }
}