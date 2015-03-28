using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Tests.Core;
using DigitalWatch.Utilities;
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
            _behavior.Load(_testableClock);
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

        [Test]
        public void WhenSetButtonPressedOnce_And_ModeButtonIsPressed_IncreasesMinutes()
        {
            var time = DateTime.Now;
            _behavior.Time = time;
            _behavior.OnClick(new SetClick());
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => _clockDisplay.TriggerUpdate(time.AddMinutes(1).ToDigitalClockFormat())).MustHaveHappened();
        }

        [Test]
        public void WhenSetButtonPressedTwice_LoadsTimeBehavior_WithCorrectTime()
        {
            var behavior = new TimeChangeBehavior();
            var clock = A.Fake<IClock>();
            behavior.Time = DateTime.Now;
            behavior.Load(clock);
            behavior.OnClick(new SetClick());
            behavior.OnClick(new SetClick());
            A.CallTo(() => clock.SwitchBehavior<TimeBehavior>(behavior.Time)).MustHaveHappened();
        }

        [Test]
        public void WhenGettingCalledWithDateTimeData_SetsTheTimeToTheData()
        {
            var behavior = new TimeChangeBehavior();
            var clock = A.Fake<IClock>();
            var expected = DateTime.Now;

            behavior.Load(clock, expected);

            behavior.Time.Should().Be(expected);
        }

        [Test]
        public void WhenIncreasingMinutesToMaxValue_DoesNot_IncreaseHours()
        {
            var behavior = new TimeChangeBehavior
            {
                Time = new DateTime(2015, 3, 27, 12, 59, 0)
            };
            behavior.IncrementMinute();
            behavior.Time.Hour.Should().Be(12);
            behavior.Time.Minute.Should().Be(0);
        }

        [Test]
        public void WhenEditingHours_FlashesHourOnAndOffEverySecond()
        {
            _behavior.Time = new DateTime(2015, 3, 28, 13, 20, 0);
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("20")).MustHaveHappened(Repeated.Exactly.Once);
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("1320")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void WhenEditingMinutes_FlashesMinuteOnAndOffEverySecond()
        {
            _behavior.Time = new DateTime(2015, 3, 28, 13, 31, 0);
            _behavior.OnClick(new SetClick());
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("13__")).MustHaveHappened(Repeated.Exactly.Once);
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("1331")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void WhenEditingMinutes_AndHourIsBelow10_UpdatesWithLeadingZero()
        {
            _behavior.Time = new DateTime(2015, 3, 28, 5, 31, 0);
            _behavior.OnClick(new SetClick());
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("05__")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void WhenEditingHours_AndMinuteIsBelow10_UpdatesWithLeadingZero()
        {
            _behavior.Time = new DateTime(2015, 3, 28, 5, 1, 0);
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("01")).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void WhenUnloadingBehavior_UnhooksTickEvent()
        {
            _behavior.Unload();
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate(A<string>.Ignored)).MustNotHaveHappened();
        }
    }
}