using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;
using System.Windows.Forms;

namespace DigitalWatch
{
    /// <summary>
    /// A Form with all the possibilities
    ///  of displaying a DigitalWatch
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly IClock _clock;
        private DateTime _mouseDownTime;

        /// <summary>
        /// Initializes a new instance of FormMain
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            _clock = new DefaultClockFactory().Create();
            _clock.Display.Update += Display_Update;
        }

        /// <summary>
        /// Gets triggered when the display updates
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The argument data container of the event</param>
        private void Display_Update(object sender, Displays.UpdateEvent.UpdateEventArgs e)
        {
            sevenSegmentArray.Value = e.DisplayData;
        }

        /// <summary>
        /// Is executed when the mode button gets clicked
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The arguments transmitted with the event</param>
        private void btnMode_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new ModeClick());
        }

        /// <summary>
        /// Is executed when the set button is clicked
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The argument container transmitted with the event</param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new SetClick());
        }

        /// <summary>
        /// Is executed when the light button is clicked
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The argument container transmitted with the event</param>
        private void btnLight_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new LightClick());
        }

        /// <summary>
        /// Is executed when the set button is clicked for a prolonged period of time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLongSetClick_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new LongSetClick());
        }

        /// <summary>
        /// Handles the MouseDown event of the btnSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void btnSet_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownTime = DateTime.Now;
        }

        /// <summary>
        /// Handles the MouseUp event of the btnSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void btnSet_MouseUp(object sender, MouseEventArgs e)
        {
            var mouseDownTimespan = DateTime.Now - _mouseDownTime;
            var thresholdValue = new TimeSpan(0, 0, 0, 1, 500);
            if (mouseDownTimespan > thresholdValue)
            {
                btnLongSetClick_Click(this, new EventArgs());
            }
        }
    }
}