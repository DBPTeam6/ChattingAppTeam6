using System;
using System.Drawing;
using System.Windows.Forms;
using ChattingAppTeam6.Chat.Lib;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatForm : Form
    {
        private ChatClient chatClient;
        private string currentUsername;

        // 메시지 입력 UI 컨트롤
        private TextBox txtMessage;
        private Button btnSend;

        public ChatForm()
        {
            InitializeComponent();
            InitializeSendControls();

            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Maximum = 0;

            // 기존 테스트용 ChatMessage 제거
            _chatList.Controls.Clear();
        }

        public ChatForm(string username, string serverIp, int port) : this()
        {
            this.currentUsername = username;
            this.Text = $"채팅 - {username}";
            InitializeChatClient(username, serverIp, port);
        }

        /// <summary>
        /// _chatSend 패널에 메시지 입력 컨트롤 초기화
        /// </summary>
        private void InitializeSendControls()
        {
            // 메시지 입력 TextBox
            txtMessage = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("맑은 고딕", 10F),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            txtMessage.KeyDown += TxtMessage_KeyDown;

            // 전송 버튼
            btnSend = new Button
            {
                Text = "전송",
                Dock = DockStyle.Right,
                Width = 60,
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold)
            };
            btnSend.Click += BtnSend_Click;

            // _chatSend 패널에 컨트롤 추가
            _chatSend.Controls.Add(txtMessage);
            _chatSend.Controls.Add(btnSend);
        }

        private void InitializeChatClient(string username, string serverIp, int port)
        {
            chatClient = new ChatClient(username);

            chatClient.Connected += (s, e) =>
            {
                AddSystemMessage("서버에 연결되었습니다.");
            };

            chatClient.Disconnected += (s, e) =>
            {
                AddSystemMessage("서버와의 연결이 끊어졌습니다.");
            };

            chatClient.MessageReceived += (s, e) =>
            {
                // 서버에서 받은 메시지 파싱 (형식: "발신자: 메시지")
                string receivedMessage = e.Message;
                string senderName = "알 수 없음";
                string messageContent = receivedMessage;

                int colonIndex = receivedMessage.IndexOf(": ");
                if (colonIndex > 0)
                {
                    senderName = receivedMessage.Substring(0, colonIndex);
                    messageContent = receivedMessage.Substring(colonIndex + 2);
                }

                // 시스템 메시지 처리
                if (receivedMessage.StartsWith("[시스템]"))
                {
                    AddSystemMessage(receivedMessage.Substring(6).Trim());
                }
                else
                {
                    AddChatMessage(senderName, messageContent);
                }
            };

            chatClient.ErrorOccurred += (s, error) =>
            {
                AddSystemMessage($"오류: {error}");
            };

            if (!chatClient.Connect(serverIp, port))
            {
                MessageBox.Show("서버 연결에 실패했습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 채팅 메시지를 _chatList에 추가
        /// </summary>
        private void AddChatMessage(string sender, string message)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddChatMessage(sender, message)));
                return;
            }

            ChatMessage chatMessage = new ChatMessage();
            chatMessage.SetSender(sender);
            chatMessage.SetMessage(message);

            _chatList.Controls.Add(chatMessage);

            // 스크롤을 최신 메시지로 이동
            _chatList.ScrollControlIntoView(chatMessage);
        }

        /// <summary>
        /// 시스템 메시지를 _chatList에 추가
        /// </summary>
        private void AddSystemMessage(string message)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddSystemMessage(message)));
                return;
            }

            ChatMessage chatMessage = new ChatMessage();
            chatMessage.SetSender("[시스템]");
            chatMessage.SetMessage(message);

            _chatList.Controls.Add(chatMessage);

            // 스크롤을 최신 메시지로 이동
            _chatList.ScrollControlIntoView(chatMessage);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            if (chatClient == null || !chatClient.IsConnected)
                return;

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            string message = txtMessage.Text.Trim();
            if (chatClient.SendMessage(message))
            {
                // 내가 보낸 메시지도 채팅 리스트에 추가
                AddChatMessage(currentUsername ?? "나", message);
                txtMessage.Clear();
                txtMessage.Focus();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            chatClient?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
