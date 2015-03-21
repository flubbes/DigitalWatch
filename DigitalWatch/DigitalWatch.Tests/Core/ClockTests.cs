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
            (_clock.Behavior as TestBehavior).IsSetClockCalled.Should().BeTrue();
        }

        [Test]
        public void StartsTickControlAfterDeclaration()
        {
            var tickControl = A.Fake<ITickControl>();
            _clock.TickControl = tickControl;
            A.CallTo(() => tickControl.Start(A<Action>.Ignored)).MustHaveHappened();
        }

        private class TestBehavior : ClockBehavior
        {
            public bool IsSetClockCalled { get; set; }

            public override void Load(IClock clock)
            {
                IsSetClockCalled = true;
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