using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatForm : Form
    {
        private readonly ChatFormViewModel viewModel;
        private OpenFileDialog openFileDialog;

        public ChatForm(int roomId, int selfUserId)
        {
            this.viewModel = new ChatFormViewModel(roomId, selfUserId);

            InitializeComponent();
            InitializeControls();

            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Maximum = 0;

            // 기존 테스트용 ChatMessage 제거
            _chatList.Controls.Clear();
            viewModel.Listen((message) => OnReceiveMessage(message));
        }

        private void OnReceiveMessage(Entity.ChatMessage message)
        {
            AddChatMessage(message);
        }

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitializeControls()
        {
            // OpenFileDialog 초기화
            openFileDialog = new OpenFileDialog
            {
                Title = "이미지 선택",
                Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.gif;*.bmp|모든 파일|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
        }

        /// <summary>
        /// 이미지 전송 버튼 클릭 이벤트
        /// </summary>
        private void BtnImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                SendImage(filePath);
            }
        }

        /// <summary>
        /// 이미지 전송
        /// </summary>
        private void SendImage(string filePath)
        {
            try
            {
                // 이미지 파일 유효성 검사
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("이미지 파일을 찾을 수 없습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 이미지 로드 테스트
                using (Image testImage = Image.FromFile(filePath))
                {
                    // 이미지가 정상적으로 로드되면 채팅에 추가
                }

                // 내가 보낸 이미지를 채팅 리스트에 추가
                //AddImageMessage(currentUsername ?? "나", filePath);

                // 서버에 이미지 전송 (Base64 인코딩)
                //if (chatClient != null && chatClient.IsConnected)
                //{
                //    byte[] imageBytes = File.ReadAllBytes(filePath);
                //    string base64Image = Convert.ToBase64String(imageBytes);
                //    string imageMessage = $"[IMAGE]{base64Image}";
                //    chatClient.SendMessage(imageMessage);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"이미지 전송 실패: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 이미지 메시지를 _chatList에 추가
        /// </summary>
        private void AddImageMessage(string sender, string imagePath)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddImageMessage(sender, imagePath)));
                return;
            }

            ChatImage chatImage = new ChatImage();
            chatImage.SetSender(sender);
            chatImage.SetImageFromFile(imagePath);
            chatImage.SetTimestamp(DateTime.Now);

            _chatList.Controls.Add(chatImage);

            // 스크롤을 최신 메시지로 이동
            _chatList.ScrollControlIntoView(chatImage);
        }

        /// <summary>
        /// 이미지 메시지를 Image 객체로 _chatList에 추가
        /// </summary>
        private void AddImageMessage(string sender, Image image)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddImageMessage(sender, image)));
                return;
            }

            ChatImage chatImage = new ChatImage();
            chatImage.SetSender(sender);
            chatImage.SetImage(image);
            chatImage.SetTimestamp(DateTime.Now);

            _chatList.Controls.Add(chatImage);

            // 스크롤을 최신 메시지로 이동
            _chatList.ScrollControlIntoView(chatImage);
        } 

        /// <summary>
        /// 채팅 메시지를 _chatList에 추가
        /// </summary>
        private void AddChatMessage(Entity.ChatMessage message)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddChatMessage(message)));
                return;
            }

            ChatMessage chatMessage = new ChatMessage();
            chatMessage.SetSender(viewModel.room.me.user == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname);
            chatMessage.SetMessage(message.message);
            chatMessage.SetTimestamp(message.timestamp);

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

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendTextMessage();
            }
        }

        private void SendTextMessage()
        {
            Entity.ChatMessage message = new Entity.ChatMessage(
                id: null,
                room: viewModel.room.id,
                sender: viewModel.room.me.user,
                message: txtMessage.Text.Trim(),
                timestamp: DateTime.Now,
                isRead: false,
                isDeleted: false
            );

            viewModel.SendTextMessage(message);
        }
    }
}
