using DigitalWatch.Behaviors;
using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Displays;
using DigitalWatch.Tests.Core;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;

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
            _testableClock = new TestableClock
            {
                Display = A.Fake<IClockDisplay>()
            };
            _behavior = new StopwatchBehavior() { TimeSpan = new TimeSpan() };
            _behavior.Load(_testableClock);
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
        public void CanHookUpToClockTickEvent_And_IncrementsWhenTriggeredAndStopWatchIsRunning()
        {
            var previousValue = _behavior.TimeSpan;
            _behavior.IsRunning = true;
            _testableClock.TriggerTickEvent();
            _behavior.TimeSpan.Should().Be(previousValue + new TimeSpan(0, 0, 0, 1));
        }

        [Test]
        public void CanHookUpToClockTickEvent_And_DoesNotIncrementsWhenTriggeredAndNotRunning()
        {
            var previousValue = _behavior.TimeSpan;
            _behavior.IsRunning = false;
            _testableClock.TriggerTickEvent();
            _behavior.TimeSpan.Should().Be(previousValue);
        }

        [Test]
        public void ModeButtonClickTriggersCorrectAction()
        {
            var clock = A.Fake<IClock>();
            _behavior.Load(clock);
            _behavior.OnClick(new ModeClick());
            A.CallTo(() => clock.SwitchBehavior<TimeBehavior>()).MustHaveHappened();
        }

        [Test]
        public void CanBeStarted()
        {
            _behavior.Load(_testableClock);
            _behavior.Start();
            _behavior.IsRunning.Should().BeTrue();
        }

        [Test]
        public void CanBeStopped()
        {
            _behavior.Load(_testableClock);
            _behavior.Start();
            _behavior.IsRunning.Should().BeTrue();
            _behavior.Stop();
            _behavior.IsRunning.Should().BeFalse();
        }

        [Test]
        public void WhenUnloadingBehavior_UnHooksClockTickEvent()
        {
            _behavior.Unload();
            _testableClock.TriggerTickEvent();
            A.CallTo(() => _testableClock.Display.TriggerUpdate(A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}