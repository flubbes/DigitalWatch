using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;

namespace DigitalWatch.Tests.Core
{
    [TestFixture]
    public class ClockTests
    {
        private IClock _clock;

        [Test]
        public void CanSwitchBehavior()
        {
            _clock = new Clock();
            var previousBehavior = _clock.Behavior;
            _clock.SwitchBehavior<TestBehavior>();
            _clock.Behavior.Should().BeOfType<TestBehavior>();
        }

        [Test]
        public void CanReUseBehavior()
        {
            _clock.SwitchBehavior<TimeBehavior>();
            var behavior = _clock.Behavior;
            _clock.SwitchBehavior<StopwatchBehavior>();
            _clock.SwitchBehavior<TimeBehavior>();
            _clock.Behavior.Should().Be(behavior);
        }

        public class TestBehavior : ClockBehavior
        {
            public override void SetClock(IClock clock)
            {
                
            }
        }
    }
}
