using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatFile : UserControl
    {
        private string _filePath;
        private byte[] _fileContent;

        public ChatFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 발신자 이름 설정
        /// </summary>
        public void SetSender(string sender)
        {
            this._sender.Text = sender;
        }

        /// <summary>
        /// 파일 이름 설정
        /// </summary>
        public void SetFileName(string fileName)
        {
            this._fileName.Text = fileName;
        }

        /// <summary>
        /// 전송 시간 설정
        /// </summary>
        public void SetTimestamp(DateTime timestamp)
        {
            this._sendTime.Text = timestamp.ToString("HH:mm");
        }

        /// <summary>
        /// 프로필 이미지 설정
        /// </summary>
        public void SetProfileImage(Image image)
        {
            if (image != null)
            {
                this._avatar.Image = image;
            }
        }

        /// <summary>
        /// 프로필 ID로 프로필 이미지 설정
        /// </summary>
        public void SetProfileImageByProfileId(int profileId)
        {
            try
            {
                Image profileImage = Notification.ProfileService.GetProfileImage(profileId);
                if (profileImage != null)
                {
                    this._avatar.Image = profileImage;
                }
            }
            catch
            {
                // 실패시 기본 이미지 유지
            }
        }

        /// <summary>
        /// 파일 경로 설정
        /// </summary>
        public void SetFilePath(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// 파일 내용 설정 (바이트 배열)
        /// </summary>
        public void SetFileContent(byte[] fileContent)
        {
            this._fileContent = fileContent;
        }

        /// <summary>
        /// 다운로드 버튼 클릭 이벤트
        /// </summary>
        private void BtnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = _fileName.Text,
                Title = "파일 저장"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_fileContent != null)
                    {
                        // 바이트 배열로 저장
                        File.WriteAllBytes(saveFileDialog.FileName, _fileContent);
                    }
                    else if (!string.IsNullOrEmpty(_filePath) && File.Exists(_filePath))
                    {
                        // 파일 경로로 저장
                        File.Copy(_filePath, saveFileDialog.FileName, true);
                    }
                    else
                    {
                        MessageBox.Show("파일을 찾을 수 없습니다.", "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("파일이 저장되었습니다.", "저장 완료",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"파일 저장 실패: {ex.Message}", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
