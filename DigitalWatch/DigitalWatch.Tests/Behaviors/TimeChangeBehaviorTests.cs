using DigitalWatch.Behaviors;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class TimeChangeBehaviorTests
    {
        private TimeChangeBehavior _behavior;

        [SetUp]
        public void SetUp()
        {
            _behavior = new TimeChangeBehavior();
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<ClockBehavior>();
        }

        [Test]
        public void CanIncrementMinuteValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementMinutes();
            _behavior.Time.Should().Be(previousValue.AddMinutes(1.0));
        }

        [Test]
        public void CanIncrementHourValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementHour();
            _behavior.Time.Should().Be(previousValue.AddHours(1.0));
        }
    }
}
