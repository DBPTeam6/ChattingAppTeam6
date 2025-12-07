using System;
using System.Windows.Forms;
using ChattingAppTeam6.Home.Models;
using ChattingAppTeam6.Home.Utils;
using ChattingAppTeam6.Home.Models;
using ChattingAppTeam6.Home.Utils;

namespace ChattingAppTeam6.Home
{
    
    public partial class ChatListItemControl : UserControl
    {
       
        private ChatListItem _item;

        
        public event EventHandler<ChatListItem> ChatClicked;

        public ChatListItemControl()
        {
            InitializeComponent();

            // 컨트롤 아무 데나 클릭해도 같은 클릭 이벤트로 처리
            this.Click += OnAnyClick;
            chatPIC.Click += OnAnyClick;
            chatName.Click += OnAnyClick;
            lastChat.Click += OnAnyClick;
            lastChatTime.Click += OnAnyClick;
        }

        private void ChatListItemControl_Load(object sender, EventArgs e)
        {
        }

        private void OnAnyClick(object sender, EventArgs e)
        {
            if (_item != null)
                ChatClicked?.Invoke(this, _item);
        }

        public void Bind(ChatListItem item)
        {
            _item = item;

            System.Diagnostics.Debug.WriteLine(
        $"[Bind] other={item.OtherUserId}, name={item.DisplayName}, " +
        $"avatar={(item.AvatarBytes == null ? "null" : item.AvatarBytes.Length.ToString())}"
        );

            chatName.Text = item.DisplayName;
            lastChat.Text = item.LastMessage;
            lastChatTime.Text = item.LastChatTime?.ToString("yyyy-MM-dd HH:mm") ?? "";

            if (item.AvatarBytes != null && item.AvatarBytes.Length > 0)
                chatPIC.Image = ImageUtils.BytesToImage(item.AvatarBytes);
            else
                chatPIC.Image = ImageUtils.CreateInitialsAvatar(item.DisplayName);
        }
    }
}