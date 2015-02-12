using System;
using DigitalWatch.Ticks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Ticks
{
    [TestFixture]
    public class DefaultClockTickTests
    {
        private ITick _tick;
        private IThreadProxy _thread;
        private IThreadRoutineBuilder _builder;

        [SetUp]
        public void SetUp()
        {
            _builder = A.Fake<IThreadRoutineBuilder>();
            _thread = A.Fake<IThreadProxy>();
            _tick = new DefaultClockTick(_thread, _builder);
        }

        [Test]
        public void IsDerivedFromTickInterface()
        {
            _tick.Should().BeAssignableTo<ITick>();
        }

        [Test]
        public void DoesStartThreadWithCorrectAction()
        {
            var testAction = new Action(() => { });
            var modifiedBuilderAction = new Action(() => { });
            A.CallTo(() => _builder.Execute(testAction)).Returns(modifiedBuilderAction);
            _tick.Start(testAction);
            A.CallTo(() => _thread.Run(modifiedBuilderAction)).MustHaveHappened();
        }
    }
}
