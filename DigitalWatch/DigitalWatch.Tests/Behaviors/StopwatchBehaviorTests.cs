using System;
using DigitalWatch.Behaviors;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class StopwatchBehaviorTests
    {
        private StopwatchBehavior _behavior;

        [SetUp]
        public void SetUp()
        {
            _behavior = new StopwatchBehavior();
        }

        [Test]
        public void IsDerivedFromBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<IClockBehavior>();
        }

        [Test]
        public void CanIncrementTimeSpanByASecond()
        {
            _behavior.TimeSpan = new TimeSpan();
            _behavior.IncrementTimeSpan();
            _behavior.TimeSpan.Should().Be(new TimeSpan(0, 0, 0, 1));
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsWhenTriggered()
        {
            var previousValue = new TimeSpan();

        }
    }

    public class StopwatchBehavior : IClockBehavior
    {
        public TimeSpan TimeSpan { get; set; }

        public void IncrementTimeSpan()
        {
            TimeSpan = TimeSpan.Add(new TimeSpan(0, 0, 0, 1));
        }
    }
}
