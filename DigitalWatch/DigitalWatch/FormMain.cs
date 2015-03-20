using DigitalWatch.Core;
using System;
using System.Windows.Forms;

namespace DigitalWatch
{
    public partial class FormMain : Form
    {
        private readonly Clock _clock;

        public FormMain()
        {
            InitializeComponent();
            _clock = new DefaultClockFactory().Create();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
        }
    }
}