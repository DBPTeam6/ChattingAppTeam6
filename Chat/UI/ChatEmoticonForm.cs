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

            pictureBox1.Click += OnClickEmoticon;
            pictureBox2.Click += OnClickEmoticon;
            pictureBox3.Click += OnClickEmoticon;
            pictureBox4.Click += OnClickEmoticon;
            pictureBox5.Click += OnClickEmoticon;
            pictureBox6.Click += OnClickEmoticon;
            pictureBox7.Click += OnClickEmoticon;
            pictureBox8.Click += OnClickEmoticon;
            pictureBox9.Click += OnClickEmoticon;
        }

        public void OnClickEmoticon(object sender, EventArgs e)
        {
            PictureBox clickedEmoticon = sender as PictureBox;
            Image image = clickedEmoticon.Image;
            
            OnSendEmoticon?.Invoke(image);
            this.Close();
        }
    }
}
