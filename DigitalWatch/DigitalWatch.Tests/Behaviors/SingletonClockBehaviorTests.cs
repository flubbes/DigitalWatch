using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class SingletonClockBehaviorTests
    {
        [Test]
        public void CanCreate()
        {
            var behavior = new SingletonTestBehavior();
            SingletonClockBehavior<SingletonTestBehavior> originalInstance = behavior;

            behavior = new SingletonTestBehavior();

            originalInstance.Instance.Should().Be(behavior.Instance).And.NotBeNull();
        }

        [Test]
        public void IsAbstract()
        {
            typeof(SingletonClockBehavior<SingletonTestBehavior>).IsAbstract.Should().BeTrue();
        }

        private class SingletonTestBehavior : SingletonClockBehavior<SingletonTestBehavior>
        {
            public override void Load(IClock clock)
            {
                throw new System.NotImplementedException();
            }

            public override void OnClick(IClockButtonClick buttonClick)
            {
                throw new System.NotImplementedException();
            }

            public override void Load(IClock clock, DateTime data)
            {
                throw new NotImplementedException();
            }

            public override void Unload()
            {
                throw new NotImplementedException();
            }
        }
    }
}