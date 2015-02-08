using System;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Displays
{
    [TestFixture]
    public class DefaultDisplayTests
    {
        private DefaultDisplay _display;

        [SetUp]
        public void SetUp()
        {
            _display = new DefaultDisplay();
        }

        [Test]
        public void IsDerivedFromClockDisplayInterface()
        {
            _display.Should().BeAssignableTo<IClockDisplay>();
        }

        [Test]
        public void EventIsTriggeredWhenUpdateIsCalled()
        {
            var isTriggered = false;
            _display.Update += (sender, args) => isTriggered = true;

            _display.TriggerUpdate("");

            isTriggered.Should().BeTrue();
        }

        [Test]
        public void EventHasDisplayDataParameter()
        {
            var displayData = "";
            _display.Update += (sender, args) =>
            {
                displayData = args.DisplayData;
            };

            _display.TriggerUpdate("Test");

            displayData.Should().Be("Test");
        }
    }

    public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

    public class UpdateEventArgs : EventArgs
    {
        public string DisplayData { get; set; }
    }

    public interface IClockDisplay
    {

    }

    public class DefaultDisplay : IClockDisplay
    {
        public void TriggerUpdate(string displayData)
        {
            Update(this, new UpdateEventArgs
            {
                DisplayData = displayData
            });
        }

        public event UpdateEventHandler Update;
    }
}
