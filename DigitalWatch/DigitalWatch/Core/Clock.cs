using DigitalWatch.Behaviors;
using DigitalWatch.Displays;
using DigitalWatch.Ticks;
using System;

namespace DigitalWatch.Core
{
    public class Clock : IClock
    {
        private ITickControl _tickControl;

        public event ClockTickEventHandler Tick;

        public ClockBehavior Behavior { get; set; }

        public IClockDisplay Display { get; set; }

        public ITickControl TickControl
        {
            get { return _tickControl; }
            set
            {
                _tickControl = value;
                _tickControl.Start(OnTick);
            }
        }

        public void SwitchBehavior<T>() where T : ClockBehavior, new()
        {
            Behavior = new T();
            Behavior.SetClock(this);
        }

        public void RegisterClick(IClockButtonClick clockButtonClick)
        {
            Behavior.OnClick(clockButtonClick);
        }

        protected void OnTick()
        {
            if (Tick != null)
            {
                Tick(this, new EventArgs());
            }
        }
    }
}