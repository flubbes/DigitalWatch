using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Core
{
    [TestFixture]
    public class ClockTests
    {
        private IClock _clock;

        [SetUp]
        public void SetUp()
        {
            _clock = new Clock();
        }

        [Test]
        public void CanSwitchBehavior()
        {
            var previousBehavior = _clock.Behavior;
            _clock.SwitchBehavior<TestBehavior>();
            _clock.Behavior.Should().BeOfType<TestBehavior>();
        }

        private class TestBehavior : ClockBehavior
        {
            public override void SetClock(IClock clock)
            {
            }
        }
    }
}