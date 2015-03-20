using System.Collections.Generic;
using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests
{
    [TestFixture]
    public class DefaultClockFactoryTests
    {
        private DefaultClockFactory _factory;

        [Test]
        public void CanCreateFactory()
        {
            _factory = new DefaultClockFactory();
        }

        [Test]
        public void ClockPropertiesHaveConcreteTypes()
        {
            var clock = _factory.CreateDefaultClock();
            clock.Behavior.Should().BeOfType<TimeBehavior>();
            clock.Display.Should().BeOfType<DefaultDisplay>();
            clock.Buttons.Should().BeOfType<List<IClockButton>>();
        }
    }
}