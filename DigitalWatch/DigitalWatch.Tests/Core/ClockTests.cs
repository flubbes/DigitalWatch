using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using DigitalWatch.Ticks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DigitalWatch.Tests.Core
{
    [TestFixture]
    public class ClockTests : Clock
    {
        private IClock _clock;

        [SetUp]
        public void SetUp()
        {
            _clock = new Clock();
        }

        [Test]
        public void CanSwitchBehavior()
        {
            _clock.SwitchBehavior<TestBehavior>();
            _clock.Behavior.Should().BeOfType<TestBehavior>();
        }

        [Test]
        public void CanRegisterClick()
        {
            var behavior = A.Fake<ClockBehavior>();
            _clock.Behavior = behavior;
            var buttonClick = new TestClick();
            _clock.RegisterClick(buttonClick);

            A.CallTo(() => behavior.OnClick(buttonClick)).MustHaveHappened();
        }

        [Test]
        public void CallsSetClock_AfterSwitchingBehavior()
        {
            _clock.SwitchBehavior<TestBehavior>();
            (_clock.Behavior as TestBehavior).IsLoadCalled.Should().BeTrue();
        }

        [Test]
        public void StartsTickControlAfterDeclaration()
        {
            var tickControl = A.Fake<ITickControl>();
            _clock.TickControl = tickControl;
            A.CallTo(() => tickControl.Start(A<Action>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void CanSwitchBehavior_And_GivesDateTimeToNewBehavior()
        {
            var expected = DateTime.Now;
            _clock.SwitchBehavior<TestBehavior>(expected);
            _clock.Behavior.Should().BeOfType<TestBehavior>();
            var testBehavior = _clock.Behavior as TestBehavior;
            testBehavior.LoadDateTime.Should().Be(expected);
        }

        [Test]
        public void WhenSwitchingBehavior_UnloadsOldOneFirst()
        {
            var clockBehavior = A.Fake<ClockBehavior>();
            _clock.Behavior = clockBehavior;
            _clock.SwitchBehavior<TestBehavior>();
            A.CallTo(() => clockBehavior.Unload()).MustHaveHappened();
        }

        [Test]
        public void WhenSwitchingBehaviorWithDateTime_UnloadsOldOneFirst()
        {
            var clockBehavior = A.Fake<ClockBehavior>();
            _clock.Behavior = clockBehavior;
            _clock.SwitchBehavior<TestBehavior>(new DateTime());
            A.CallTo(() => clockBehavior.Unload()).MustHaveHappened();
        }

        [Test]
        public void WhenSwitchingBehavior_And_BehaviorIsNull_DoesNotThrowException()
        {
            _clock.Behavior = null;
            _clock.SwitchBehavior<TestBehavior>();
        }

        [Test]
        public void WhenSwitchingBehaviorWithDateTime_And_BehaviorIsNull_DoesNotThrowException()
        {
            _clock.Behavior = null;
            _clock.SwitchBehavior<TestBehavior>(DateTime.Now);
        }

        private class TestBehavior : ClockBehavior
        {
            public bool IsLoadCalled { get; private set; }

            public DateTime LoadDateTime { get; private set; }

            public override void Load(IClock clock, DateTime data)
            {
                LoadDateTime = data;
            }

            public override void Unload()
            {
                throw new NotImplementedException();
            }

            public override void Load(IClock clock)
            {
                IsLoadCalled = true;
            }

            public override void OnClick(IClockButtonClick buttonClick)
            {
                throw new System.NotImplementedException();
            }

            public bool IsClickRegistered { get; set; }
        }

        private class TestClick : IClockButtonClick
        {
        }
    }
}