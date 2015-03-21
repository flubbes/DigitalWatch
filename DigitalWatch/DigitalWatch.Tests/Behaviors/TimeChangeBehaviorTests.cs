using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Displays;
using DigitalWatch.Tests.Core;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class TimeChangeBehaviorTests
    {
        private TimeChangeBehavior _behavior;
        private TestableClock _testableClock;
        private IClockDisplay _clockDisplay;

        [SetUp]
        public void SetUp()
        {
            _behavior = new TimeChangeBehavior();
            _testableClock = new TestableClock();
            _clockDisplay = A.Fake<IClockDisplay>();
            _testableClock.Display = _clockDisplay;
            _behavior.SetClock(_testableClock);
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
            _behavior.IncrementMinute();
            _behavior.Time.Should().Be(previousValue.AddMinutes(1.0));
        }

        [Test]
        public void CanIncrementHourValue()
        {
            var previousValue = _behavior.Time;
            _behavior.IncrementHour();
            _behavior.Time.Should().Be(previousValue.AddHours(1.0));
        }

        [Test]
        public void WhenModeButtonIsClicked_UpdatesDisplayWithNewValue()
        {
            _behavior.Time = new DateTime(2000, 1, 1, 12, 0, 0);
            var previousValue = _behavior.Time;
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => _clockDisplay.TriggerUpdate("1300")).MustHaveHappened();
        }
    }
}