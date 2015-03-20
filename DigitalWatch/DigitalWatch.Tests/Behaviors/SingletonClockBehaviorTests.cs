using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class SingletonClockBehaviorTests
    {
        [Test]
        public void CanCreate()
        {
            var behavior = new SingletonTestBehavior();
            SingletonClockBehavior originalInstance = behavior;

            behavior = new SingletonTestBehavior();

            originalInstance.SingletonContainer.Should().Be(behavior.SingletonContainer).And.NotBeNull();
        }

        [Test]
        public void IsAbstract()
        {
            typeof(SingletonClockBehavior).IsAbstract.Should().BeTrue();
        }

        private class SingletonTestBehavior : SingletonClockBehavior
        {
            public override void SetClock(IClock clock)
            {
                throw new System.NotImplementedException();
            }

            public override void OnClick(IClockButtonClick buttonClick)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}