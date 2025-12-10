using ChattingAppTeam6.Chat.Lib;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatMessage : UserControl
    {
        public int id;
        public ChatMessage()
        {
            InitializeComponent();
        }

        public void SetId(int _id)
        {
            id = _id;
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

        /// <summary>
        /// 프로필 이미지 설정
        /// </summary>
        public void SetProfileImage(Image image)
        {
            if (image != null)
            {
                this._avatar.Image = image;
            }
        }

        /// <summary>
        /// 프로필 ID로 프로필 이미지 설정
        /// </summary>
        public void SetProfileImageByProfileId(int profileId)
        {
            try
            {
                Image profileImage = Notification.ProfileService.GetProfileImage(profileId);
                if (profileImage != null)
                {
                    this._avatar.Image = profileImage;
                }
            }
            catch
            {
                // 실패시 기본 이미지 유지
            }
        }

        private void OnChatMessageRClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem item1 = new ToolStripMenuItem("삭제");
                item1.Click += (s, ev) =>
                {
                    ChattingClient.GetInstance().DeleteMessage(0, id);
                    MessageBox.Show("메시지가 삭제되었습니다.");
                };
                contextMenu.Items.Add(item1);
                contextMenu.Show(this, e.Location);
            }
        }
    }
}
