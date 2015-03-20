using System;
using DigitalWatch.Behaviors;
using DigitalWatch.Tests.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class TimeBehaviorTests
    {
        private TimeBehavior _behavior;
        private TestableClock _testableClock;

        [SetUp]
        public void SetUp()
        {
            _testableClock = new TestableClock();
            _behavior = new TimeBehavior();
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<ClockBehavior>();
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsTimeWhenTriggered()
        {
            var previousValue = DateTime.Now;
            _behavior.Time = previousValue;
            _testableClock.TriggerTickEvent();
            _behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }
    }
}
