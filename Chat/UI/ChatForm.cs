using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();

            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Maximum = 0;
        }
    }
}
