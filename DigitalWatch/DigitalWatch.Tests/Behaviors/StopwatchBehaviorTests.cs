using DigitalWatch.Behaviors;
using DigitalWatch.Tests.Core;
using FluentAssertions;
using NUnit.Framework;
using System;
using DigitalWatch.Clicks;
using DigitalWatch.Core;
using FakeItEasy;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class StopwatchBehaviorTests
    {
        private StopwatchBehavior _behavior;
        private TestableClock _testableClock;

        [SetUp]
        public void SetUp()
        {
            _testableClock = new TestableClock();
            _behavior = new StopwatchBehavior() { TimeSpan = new TimeSpan() };
            _behavior.SetClock(_testableClock);
        }

        [Test]
        public void IsDerivedFromBehaviorInterface()
        {
            _behavior.Should().BeAssignableTo<ClockBehavior>();
        }

        [Test]
        public void CanIncrementTimeSpanByASecond()
        {
            _behavior.IncrementTimeSpanBySecond();
            _behavior.TimeSpan.Should().Be(new TimeSpan(0, 0, 0, 1));
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_IncrementsWhenTriggered()
        {
            var previousValue = _behavior.TimeSpan;
            _testableClock.TriggerTickEvent();
            _behavior.TimeSpan.Should().Be(previousValue + new TimeSpan(0, 0, 0, 1));
        }

        [Test]
        public void ModeButtonClickTriggersCorrectAction()
        {
            var clock = A.Fake<IClock>();
            _behavior.SetClock(clock);
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => clock.SwitchBehavior<TimeBehavior>()).MustHaveHappened();
        }
    }
}