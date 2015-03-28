using DigitalWatch.Clicks;
using DigitalWatch.Core;
using DigitalWatch.Utilities;
using System;

namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The behavior to change the time
    /// </summary>
    public class TimeChangeBehavior : ClockBehavior
    {
        private IClock _clock;
        private Mode _mode;
        private bool _isFlashing;

        /// <summary>
        /// The internal  ode of the timeChangeBehavior
        /// </summary>
        private enum Mode
        {
            ChangeHour,
            ChangeMinute
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Increments the property 'Time' by one (1) Minute
        /// </summary>
        public void IncrementMinute()
        {
            var tempTime = Time.AddMinutes(1.0);
            if (tempTime.Hour != Time.Hour)
            {
                tempTime -= TimeSpan.FromHours(1);
            }
            Time = tempTime;
        }

        /// <summary>
        /// Increments the property 'Time' by one(1) Hour
        /// </summary>
        public void IncrementHour()
        {
            Time = Time.AddHours(1.0);
        }

        /// <summary>
        /// Hands the Clock object instance to the Behavior to work with
        /// </summary>
        /// <param name="clock"></param>
        public override void Load(IClock clock)
        {
            clock.Tick += Tick;
            _clock = clock;
        }

        /// <summary>
        /// Contains all actions that are executed when the Tick Event occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            var toUpdate = Time.ToDigitalClockFormat();
            if (_mode == Mode.ChangeHour)
            {
                if (!_isFlashing)
                {
                    toUpdate = Time.Minute.ToString();
                }
            }
            else
            {
                if (!_isFlashing)
                {
                    toUpdate = String.Format("{0}__", Time.Hour);
                }
            }
            _clock.Display.TriggerUpdate(toUpdate);
            _isFlashing = !_isFlashing;
        }

        /// <summary>
        /// Decides what happens if a certain button is clicked
        /// </summary>
        /// <param name="buttonClick"></param>
        public override void OnClick(IClockButtonClick buttonClick)
        {
            //TODO clean this method
            if (buttonClick is ModeClick)
            {
                switch (_mode)
                {
                    case Mode.ChangeHour:
                        {
                            IncrementHour();
                        }
                        break;

                    case Mode.ChangeMinute:
                        {
                            IncrementMinute();
                        }
                        break;
                }
                _clock.Display.TriggerUpdate(Time.ToDigitalClockFormat());
            }
            if (!(buttonClick is SetClick))
            {
                return;
            }
            switch (_mode)
            {
                case Mode.ChangeHour:
                    {
                        _mode = Mode.ChangeMinute;
                    }
                    break;

                case Mode.ChangeMinute:
                    {
                        _clock.SwitchBehavior<TimeBehavior>(Time);
                    }
                    break;
            }
        }

        /// <summary>
        /// Loads the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Load(IClock clock, DateTime data)
        {
            Load(clock);
            Time = data;
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public override void Unload()
        {
            _clock.Tick -= Tick;
        }
    }
}