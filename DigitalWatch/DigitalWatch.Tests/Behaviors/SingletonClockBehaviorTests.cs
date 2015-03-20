using DigitalWatch.Behaviors;
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
            typeof (SingletonClockBehavior).IsAbstract.Should().BeTrue();
        }

        private class SingletonTestBehavior : SingletonClockBehavior
        {
            
        }
    }
}
