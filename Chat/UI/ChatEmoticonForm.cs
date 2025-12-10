using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatEmoticonForm : Form
    {
        private readonly Action<Image> OnSendEmoticon;

        public ChatEmoticonForm(Action<Image> OnSendEmoticon)
        {
            InitializeComponent();
            this.OnSendEmoticon = OnSendEmoticon;
        }

        public void OnClickEmoticon(object sender, EventArgs e)
        {
            PictureBox clickedEmoticon = sender as PictureBox;
            Image image = clickedEmoticon.Image;
            
            OnSendEmoticon?.Invoke(image);
        }
    }
}
