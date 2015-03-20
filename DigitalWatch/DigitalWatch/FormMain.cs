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

        private void btnMode_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new ModeClick());
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new SetClick());
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            _clock.RegisterClick(new LightClick());
        }
    }
}