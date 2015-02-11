using System;
using DigitalWatch.Behaviors;
using DigitalWatch.Tests.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class StopwatchBehaviorTests
    {
        private StopwatchBehavior _behavior;
        private TestableClock _testableClock;

        [SetUp]
        public void SetUp()
        {
            _testableClock = new TestableClock();
            _behavior = new StopwatchBehavior(_testableClock) { TimeSpan = new TimeSpan() };
        }

        [Test]
        public void IsDerivedFromBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<IClockBehavior>();
        }

        [Test]
        public void CanIncrementTimeSpanByASecond()
        {
            _behavior.IncrementTimeSpan();
            _behavior.TimeSpan.Should().Be(new TimeSpan(0, 0, 0, 1));
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsWhenTriggered()
        {
            var previousValue = _behavior.TimeSpan;
            _testableClock.TriggerEvent();
            _behavior.TimeSpan.Should().Be(previousValue + new TimeSpan(0, 0, 0, 1));
        }
    }
}