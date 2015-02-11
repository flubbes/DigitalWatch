using System;
using DigitalWatch.Behaviors;
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
            _behavior = new TimeBehavior(_testableClock);
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<IClockBehavior>();
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsTimeWhenTriggered()
        {
            var previousValue = DateTime.Now;
            _behavior.Time = previousValue;
            _testableClock.TriggerEvent();
            _behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }
    }
}
