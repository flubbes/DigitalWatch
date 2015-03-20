using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace DigitalWatch.Tests
{
    [TestFixture]
    public class DefaultClockFactoryTests
    {
        private DefaultClockFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DefaultClockFactory();
        }

        [Test]
        public void ClockPropertiesHaveConcreteTypes()
        {
            var clock = _factory.Create();
            clock.Behavior.Should().BeOfType<TimeBehavior>();
            clock.Display.Should().BeOfType<DefaultDisplay>();
            clock.TickControl.Should().BeOfType<DefaultClockTickControl>();
        }

        [Test]
        public void AfterCreation_ClockInBehavior_IsNotNull()
        {
            var clock = _factory.Create();
            clock.Behavior.OnClick(new ModeClick());
        }
    }
}