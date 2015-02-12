using System;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Ticks
{
    [TestFixture]
    public class ThreadRoutineBuilderTests : ThreadRoutineBuilder
    {
        [Test]
        public void ActionIsInvokedMultipleTimes()
        {
            var counter = 0;
            var threadRoutineBuilder = new ThreadRoutineThatRunsMultipleTimes();
            threadRoutineBuilder.WrapAction(() => counter++);
            counter.Should().Be(42);
        }

        [Test]
        public void ActionIsNeverInvoked()
        {
            var counter = 0;
            var threadRoutineBuilder = new ThreadRoutineThatImmediatlyShutsDown();
            threadRoutineBuilder.WrapAction(() => counter++);
            counter.Should().Be(0);
        }

        [Test]
        public void ShouldRunMethodShouldReturnTrue()
        {
            ShouldRun().Should().BeTrue();
        }

        [Test]
        public void CanExecuteAction()
        {

        }

        private class ThreadRoutineThatRunsMultipleTimes : ThreadRoutineBuilder
        {
            private int _internalCounter;

            protected override bool ShouldRun()
            {
                _internalCounter++;
                return _internalCounter <= 42;
            }
        }

        private class ThreadRoutineThatImmediatlyShutsDown : ThreadRoutineBuilder
        {
            protected override bool ShouldRun()
            {
                return false;
            }
        }
    }

    public class ThreadRoutineBuilder
    {
        public Action Execute(Action routine)
        {
            throw new NotImplementedException();
        }

        protected virtual bool ShouldRun()
        {
            return true;
        }

        public void WrapAction(Action action)
        {
            while (ShouldRun())
            {
                action.Invoke();
            }
        }
    }
}
