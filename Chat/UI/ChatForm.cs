using ChatMessage;
using ChattingAppTeam6.Chat.Lib;
using ChattingAppTeam6.Home.Utils;
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

            var targetId = viewModel.room.target.user_id;
            viewModel.On($"{targetId}-SEND_MESSAGE", OnReceiveTextMessage);
            viewModel.On($"{targetId}-DELETE_MESSAGE", OnDeleteMessage);
            viewModel.On($"{targetId}-SEND_FILE", OnReceiveFileMessage);

            Entity.ChatMessage[] messages = viewModel.LoadAllMessages();
            foreach (var message in messages)
            {
                AddChatMessage(message);
            }
        }

        // 텍스트 메시지 수신 처리
        private void OnReceiveTextMessage(Packet packet)
        {
            var message = Entity.ChatMessage.FromPacket(packet);
            
            AddChatMessage(message);
        }

        // 메시지 삭제 처리
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

        // 파일 메시지 수신 처리
        private void OnReceiveFileMessage(Packet packet)
        {
            var message = Entity.ChatFileMessage.FromPacket(packet);

            if (new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }
                .Contains(Path.GetExtension(message.fileName).ToLower()))
            {
                using MemoryStream ms = new MemoryStream(message.fileContent);
                Image image = Image.FromStream(ms);
                AddImageMessage(
                    sender: viewModel.room.me.user_id == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname,
                    image: image
                );
                return;
            }

            AddFileMessage(
                sender: viewModel.room.me.user_id == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname,
                fileName: message.fileName,
                fileContent: message.fileContent
            );
        }

        // 배너 편집 처리
        private void OnEditBanner(Packet packet)
        {
            bannerTextBox.Text = packet.EditBanner.Content;
        }

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitializeControls()
        {
            _sender.Text = viewModel.room.target.nickname;
            if (viewModel.room.target.profileImageBytes.Length > 0)
                _avatar.Image = ImageUtils.BytesToImage(viewModel.room.target.profileImageBytes);

            // OpenFileDialog 초기화
            openFileDialog = new OpenFileDialog
            {
                Title = "파일 선택",
                Filter = "모든 파일|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
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
            
            // 프로필 이미지 설정
            if (sender == viewModel.room.me.nickname && viewModel.room.me.profileImageBytes != null && viewModel.room.me.profileImageBytes.Length > 0)
            {
                chatFile.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.me.profileImageBytes));
            }
            else if (sender == viewModel.room.target.nickname && viewModel.room.target.profileImageBytes != null && viewModel.room.target.profileImageBytes.Length > 0)
            {
                chatFile.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.target.profileImageBytes));
            }

            _chatList.Controls.Add(chatFile);
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
            
            // 프로필 이미지 설정
            if (sender == viewModel.room.me.nickname && viewModel.room.me.profileImageBytes != null && viewModel.room.me.profileImageBytes.Length > 0)
            {
                chatImage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.me.profileImageBytes));
            }
            else if (sender == viewModel.room.target.nickname && viewModel.room.target.profileImageBytes != null && viewModel.room.target.profileImageBytes.Length > 0)
            {
                chatImage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.target.profileImageBytes));
            }

            _chatList.Controls.Add(chatImage);
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
      
            // 프로필 이미지 설정
            if (sender == viewModel.room.me.nickname && viewModel.room.me.profileImageBytes != null && viewModel.room.me.profileImageBytes.Length > 0)
            {
                chatImage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.me.profileImageBytes));
            }
            else if (sender == viewModel.room.target.nickname && viewModel.room.target.profileImageBytes != null && viewModel.room.target.profileImageBytes.Length > 0)
            {
                chatImage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.target.profileImageBytes));
            }

            _chatList.Controls.Add(chatImage);
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
            chatMessage.SetSender(viewModel.room.me.user_id == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname);
            chatMessage.SetMessage(message.message);
            chatMessage.SetTimestamp(message.timestamp);
      
            // 프로필 이미지 설정
        string sender = viewModel.room.me.user_id == message.sender ? viewModel.room.me.nickname : viewModel.room.target.nickname;
        if (sender == viewModel.room.me.nickname && viewModel.room.me.profileImageBytes != null && viewModel.room.me.profileImageBytes.Length > 0)
        {
            chatMessage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.me.profileImageBytes));
        }
        else if (sender == viewModel.room.target.nickname && viewModel.room.target.profileImageBytes != null && viewModel.room.target.profileImageBytes.Length > 0)
        {
            chatMessage.SetProfileImage(Home.Utils.ImageUtils.BytesToImage(viewModel.room.target.profileImageBytes));
        }

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
                sender: viewModel.room.me.user_id,
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

                Entity.ChatMessage message = new Entity.ChatMessage(
                    id: -1,
                    room: viewModel.room.id,
                    sender: viewModel.room.me.user_id,
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
