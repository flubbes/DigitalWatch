﻿using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Tests.Core;
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

        [SetUp]
        public void SetUp()
        {
            _testableClock = new TestableClock();
            _behavior = new TimeBehavior();
            _behavior.SetClock(_testableClock);
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
            _behavior.SetClock(clock);
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => clock.SwitchBehavior<StopwatchBehavior>()).MustHaveHappened();
        }

        [Test]
        public void WhenSetButtonIsClicked_LoadsTimeChangeBehavior()
        {
            var clock = A.Fake<IClock>();
            _behavior.SetClock(clock);
            _behavior.OnClick(new SetClick());
            A.CallTo(() => clock.SwitchBehavior<TimeChangeBehavior>()).MustHaveHappened();
        }
    }
}