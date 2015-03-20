using DigitalWatch.Clicks;
using DigitalWatch.Core;
using System;
using System.Windows.Forms;

namespace DigitalWatch
{
    public partial class FormMain : Form
    {
        private readonly IClock _clock;

        public FormMain()
        {
            InitializeComponent();
            _clock = new DefaultClockFactory().Create();
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
        /// <param name="e">The </param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new SetClick());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLight_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new LightClick());
        }
    }
}