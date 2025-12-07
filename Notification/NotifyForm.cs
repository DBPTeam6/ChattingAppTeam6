using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingAppTeam6.Notification
{
    public partial class NotifyForm : Form
    {
        private int _chatId;
        private System.Windows.Forms.Timer _closeTimer;

        public NotifyForm(string senderName, DateTime timestamp, string messagePreview, int chatId)
        {
            InitializeComponent();

            _chatId = chatId;

            // Bind UI controls (assumes labels exist in designer)
            lblSender.Text = senderName ?? string.Empty;
            lblTime.Text = timestamp.ToString("hh:mm");
            lblMessage.Text = messagePreview ?? string.Empty;

            // Prepare 5-second auto close timer
            _closeTimer = new System.Windows.Forms.Timer();
            _closeTimer.Interval = 5000;
            _closeTimer.Tick += (s, e) => { try { _closeTimer.Stop(); Close(); } catch { } };
            _closeTimer.Start();

            // Optional: remove window border interactions
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void NotifyForm_Load(object sender, EventArgs e)
        {
        }

        private void lblSender_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                _closeTimer?.Stop();
                ToastManager.Remove(this);
            }
            catch { }
        }
    }
}
