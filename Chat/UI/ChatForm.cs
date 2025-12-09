using ChatMessage;
using ChattingAppTeam6.Chat.Lib;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatForm : Form
    {
        private readonly ChatFormViewModel viewModel;
        private OpenFileDialog openFileDialog;
        private OpenFileDialog openFileDialogForFile;

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
            viewModel.On("SEND_MESSAGE", OnReceiveTextMessage);
            viewModel.On("DELETE_MESSAGE", OnDeleteMessage);
            viewModel.On("SEND_FILE", OnReceiveFileMessage);
            viewModel.Listen();
        }

        private void OnReceiveTextMessage(Packet packet)
        {
            var message = Entity.ChatMessage.FromPacket(packet);
            
            AddChatMessage(message);
        }

        private void OnDeleteMessage(Packet packet)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => OnDeleteMessage(packet)));
                return;
            }

            foreach (var contral in _chatList.Controls)
            {
                ChatMessage message = contral as ChatMessage;

                if (message.id == packet.DeleteMessage.MessageId)
                {
                    _chatList.Controls.Remove(message);
                }
            }
        }

        private void OnReceiveFileMessage(Packet packet)
        {
            var message = Entity.ChatFileMessage.FromPacket(packet);

            AddFileMessage(
                sender: viewModel.room.me.user == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname,
                fileName: message.fileName,
                fileContent: message.fileContent
            );
        }

        private void OnEditBanner(Packet packet)
        {
            bannerTextBox.Text = packet.EditBanner.Content;
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

            // OpenFileDialog for file 초기화
            openFileDialogForFile = new OpenFileDialog
            {
                Title = "파일 선택",
                Filter = "모든 파일|*.*",
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
        /// 파일 메시지를 _chatList에 추가
        /// </summary>
        private void AddFileMessage(string sender, string fileName, byte[] fileContent)
        {
            if (_chatList.InvokeRequired)
            {
                _chatList.Invoke(new Action(() => AddFileMessage(sender, fileName, fileContent)));
                return;
            }

            ChatFile chatFile = new ChatFile();
            chatFile.SetSender(sender);
            chatFile.SetFileName(fileName);
            chatFile.SetFileContent(fileContent);
            chatFile.SetTimestamp(DateTime.Now);

            _chatList.Controls.Add(chatFile);

            // 스크롤을 최신 메시지로 이동
            _chatList.ScrollControlIntoView(chatFile);
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
            chatMessage.SetId(message.id);
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
                id: -1,
                room: viewModel.room.id,
                sender: viewModel.room.me.user,
                message: txtMessage.Text.Trim(),
                timestamp: DateTime.Now,
                isRead: false,
                isDeleted: false
            );

            viewModel.SendTextMessage(message);
        }

        /// <summary>
        /// 파일 전송
        /// </summary>
        private void SendFileMessage(string filePath, Stream stream)
        {
            try
            {
                // 파일 유효성 검사
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("파일을 찾을 수 없습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fileName = Path.GetFileName(filePath);

                // 보낼 파일이 이미지라면 이미지로 처리
                if (new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }
                    .Contains(Path.GetExtension(fileName).ToLower()))
                {
                    SendImage(filePath);
                    return;
                }

                Entity.ChatMessage message = new Entity.ChatMessage(
                    id: -1,
                    room: viewModel.room.id,
                    sender: viewModel.room.me.user,
                    message: fileName,
                    timestamp: DateTime.Now,
                    isRead: false,
                    isDeleted: false
                );

                viewModel.SendFileMessage(message, stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 전송 실패: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBannerButton_Click(object sender, EventArgs e)
        {
            ChattingClient.GetInstance().EditBanner(viewModel.room.id, bannerTextBox.Text);
        }
    }
}
