using System;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class TimeBehaviorTests
    {
        private TimeBehavior _behavior;

        [SetUp]
        public void SetUp()
        {
            _behavior = new TimeBehavior(new Clock());
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<IClockBehavior>();
        }

        [Test]
        public void CanHookUpToClockTickEvent()
        {
            var clock = new TestableClock();
            var behavior = new TimeBehavior(clock);
            var previousValue = DateTime.Now;
            behavior.Time = previousValue;
            clock.TriggerEvent();
            behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }

        private class TestableClock : IClock
        {
            public event ClockTickEventHandler Tick;

            public void TriggerEvent()
            {
                if (Tick != null)
                {
                    Tick(this, EventArgs.Empty);
                }
            }
        }
    }

    public interface IClock
    {
        event ClockTickEventHandler Tick;
    }

    public delegate void ClockTickEventHandler(object sender, EventArgs e);

    public class Clock : IClock
    {
        public event ClockTickEventHandler Tick;
    }

    public interface IClockBehavior
    {

    }

    public class TimeBehavior : IClockBehavior
    {
        public TimeBehavior(IClock clock)
        {
            clock.Tick += Tick;
        }

        public DateTime Time { get; set; }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Time = Time.AddSeconds(1.0);
        }
    }
}
