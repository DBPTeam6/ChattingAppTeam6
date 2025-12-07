using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatMessage : UserControl
    {
        public ChatMessage()
        {
            InitializeComponent();
        }

        public void SetSender(string sender)
        {
            this._sender.Text = sender;
        }

        public void SetMessage(string message)
        {
            this._message.Text = message;
        }

        public void SetTimestamp(DateTime timestamp)
        {
            this._sendTime.Text = timestamp.ToString("HH:mm");
        }

        private void OnChatMessageRClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem item1 = new ToolStripMenuItem("삭제");
                item1.Click += (s, ev) =>
                {
                    MessageBox.Show("메시지가 삭제되었습니다.");
                };
                contextMenu.Items.Add(item1);
                contextMenu.Show(this, e.Location);
            }
        }
    }
}
