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
    public class TimeBehaviorTests
    {
        private TimeBehavior _behavior;
        private TestableClock _testableClock;
        private IClockDisplay _clockDisplay;

        [SetUp]
        public void SetUp()
        {
            _clockDisplay = A.Fake<IClockDisplay>();
            _testableClock = new TestableClock()
            {
                Display = _clockDisplay
            };
            _behavior = new TimeBehavior();
            _behavior.Load(_testableClock);
        }

        [Test]
        public void IsDerivedFromClockBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<ClockBehavior>();
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsTimeWhenTriggered()
        {
            var previousValue = DateTime.Now;
            _behavior.Time = previousValue;
            _testableClock.TriggerTickEvent();
            _behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
        }

        [Test]
        public void WhenModeButtonIsClicked_LoadsStopwatchBehavior()
        {
            var clock = A.Fake<IClock>();
            _behavior.Load(clock);
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => clock.SwitchBehavior<StopwatchBehavior>()).MustHaveHappened();
        }

        [Test]
        public void WhenTimeIncreases_UpdatesDisplay()
        {
            _testableClock.Behavior = _behavior;
            var time = new DateTime(2015, 3, 20, 4, 3, 59);
            _behavior.Time = time;
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _clockDisplay.TriggerUpdate("0404")).MustHaveHappened();
        }

        [Test]
        public void AfterLoadingBehavior_UpdatesDisplay()
        {
            var clock = A.Fake<IClock>();
            var clockDisplay = A.Fake<IClockDisplay>();
            clock.Display = clockDisplay;
            var time = DateTime.Now;
            var behavior = new TimeBehavior
            {
                Time = time
            };
            behavior.Load(clock);

            A.CallTo(() => clockDisplay.TriggerUpdate(time.ToDigitalClockFormat())).MustHaveHappened();
        }

        [Test]
        public void WhenSwitchingToTimeChangeBehavior_GivesCurrentTimeToIt()
        {
            _behavior.Time = DateTime.Now;
            var clock = A.Fake<IClock>();
            _behavior.Load(clock);
            _behavior.OnClick(new SetClick());
            A.CallTo(() => clock.SwitchBehavior<TimeChangeBehavior>(_behavior.Time)).MustHaveHappened();
        }

        [Test]
        public void WhenLoadedWithDateTime_HooksTickEvent_SetsTime_And_UpdatesDisplay()
        {
            var behavior = new TimeBehavior();
            var clock = new TestableClock();
            var clockDisplay = A.Fake<IClockDisplay>();
            clock.Display = clockDisplay;
            var previousValue = DateTime.Now;
            behavior.Load(clock, previousValue);
            clock.TriggerTickEvent();
            behavior.Time.Should().Be(previousValue.AddSeconds(1.0));
            A.CallTo(() => clockDisplay.TriggerUpdate(previousValue.ToDigitalClockFormat())).MustHaveHappened();
        }
    }
}