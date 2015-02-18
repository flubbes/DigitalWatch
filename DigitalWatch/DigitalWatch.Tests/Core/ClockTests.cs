using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Core
{
    [TestFixture]
    public class ClockTests
    {
        [Test]
        public void CanSwitchBehavior()
        {
            IClock clock = new Clock();
            var previousBehavior = clock.Behavior;
            clock.SwitchBehavior<TestBehavior>();
            clock.Behavior.Should().BeOfType<TestBehavior>();
        }

        public class TestBehavior : IClockBehavior
        {

        }
    }
}
