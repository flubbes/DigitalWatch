﻿using DigitalWatch.Behaviors;
using DigitalWatch.Core;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Core
{
    [TestFixture]
    public class ClockTests
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

        private class TestBehavior : ClockBehavior
        {
            public override void SetClock(IClock clock)
            {
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