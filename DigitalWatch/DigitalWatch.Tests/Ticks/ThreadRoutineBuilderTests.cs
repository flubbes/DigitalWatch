using DigitalWatch.Ticks;
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
            var threadRoutineBuilder = new ThreadRoutineThatImmediatelyShutsDown();
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

        private class ThreadRoutineThatImmediatelyShutsDown : ThreadRoutineBuilder
        {
            protected override bool ShouldRun()
            {
                return false;
            }
        }
    }
}
