using System;
using System.Windows.Forms;

namespace Game
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            this.FormClosing += LogForm_FormClosing;
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void AppendLog(string message)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new MethodInvoker(() =>
                {
                    rtbLog.AppendText(message + Environment.NewLine);
                    rtbLog.ScrollToCaret();
                }));
            }
            else
            {
                rtbLog.AppendText(message + Environment.NewLine);
                rtbLog.ScrollToCaret();
            }
        }
    }
}