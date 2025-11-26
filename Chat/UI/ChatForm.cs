using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            _chatList.Scroll += (sender, e) =>
            {
                Debug.WriteLine($"{_chatList.VerticalScroll.Value} {_chatList.VerticalScroll.}");
            };
        }
    }
}
