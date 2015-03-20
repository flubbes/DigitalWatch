using System;
using DigitalWatch.Behaviors;
using DigitalWatch.Tests.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class TimeChangeBehaviorTests
    {
        private TimeChangeBehavior _behavior;
        private TestableClock _testableClock;

        [SetUp]
        public void SetUp()
        {
            _behavior = new TimeChangeBehavior();
            _testableClock = new TestableClock();
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<ClockBehavior>();
        }

        [Test]
        public void CanIncrementSecondValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementSecond();
            _behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }

        [Test]
        public void CanIncrementMinuteValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementMinute();
            _behavior.Time.Should().Be(previousValue.AddMinutes(1.0));
        }

        [Test]
        public void CanIncrementHourValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementHour();
            _behavior.Time.Should().Be(previousValue.AddHours(1.0));
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsWhenTriggered()
        {
            var previousValue = DateTime.Now;
            _behavior.Time = previousValue;
            _testableClock.TriggerTickEvent();
            _behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }
    }
}
