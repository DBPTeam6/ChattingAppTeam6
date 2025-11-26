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

            Bitmap bitmap = new Bitmap(_avatar.Width, _avatar.Height);
            Graphics g = Graphics.FromImage(bitmap);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, _avatar.Width, _avatar.Height);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);
            Bitmap bmp = Properties.Resources.chat_profile_test;
            g.DrawImage(bmp, new Rectangle(0, 0, _avatar.Width, _avatar.Height)
                           , new Rectangle(0, 0, _avatar.Width, _avatar.Height)
                           , GraphicsUnit.Pixel);

            _avatar.Image = bitmap;
        }

        public void SetSender(string sender)
        {
            this._sender.Text = sender;
        }

        public void SetMessage(string message)
        {
            this._message.Text = message;
        }
    }
}
