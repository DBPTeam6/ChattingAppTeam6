using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    public partial class ChatImage : UserControl
    {
        private Image _imageContent;

        public ChatImage()
        {
            InitializeComponent();
            InitializeAvatar();
        }

        /// <summary>
        /// 프로필 아바타를 원형으로 초기화
        /// </summary>
        private void InitializeAvatar()
        {
            Bitmap bitmap = new Bitmap(_avatar.Width, _avatar.Height);
            Graphics g = Graphics.FromImage(bitmap);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, _avatar.Width, _avatar.Height);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);
            Bitmap bmp = Properties.Resources.chat_profile_test;
            g.DrawImage(bmp, new Rectangle(0, 0, _avatar.Width, _avatar.Height),
                           new Rectangle(0, 0, bmp.Width, bmp.Height),
                           GraphicsUnit.Pixel);

            _avatar.Image = bitmap;
        }

        /// <summary>
        /// 발신자 이름 설정
        /// </summary>
        public void SetSender(string sender)
        {
            this._sender.Text = sender;
        }

        /// <summary>
        /// 이미지를 Image 객체로 설정
        /// </summary>
        public void SetImage(Image image)
        {
            if (image == null) return;

            _imageContent = image;
            _imageBox.Image = image;
            _imageBox.SizeMode = PictureBoxSizeMode.Zoom;

            // 이미지 크기에 따라 PictureBox 크기 조정 (최대 크기 제한)
            AdjustImageSize(image.Width, image.Height);
        }

        /// <summary>
        /// 파일 경로에서 이미지 로드
        /// </summary>
        public void SetImageFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Image image = Image.FromFile(filePath);
                    SetImage(image);
                }
            }
            catch (Exception ex)
            {
                _sender.Text += $" (이미지 로드 실패: {ex.Message})";
            }
        }

        /// <summary>
        /// URL에서 이미지 로드
        /// </summary>
        public void SetImageFromUrl(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        SetImage(image);
                    }
                }
            }
            catch (Exception ex)
            {
                _sender.Text += $" (이미지 로드 실패: {ex.Message})";
            }
        }

        /// <summary>
        /// Base64 문자열에서 이미지 로드
        /// </summary>
        public void SetImageFromBase64(string base64String)
        {
            try
            {
                byte[] imageData = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    SetImage(image);
                }
            }
            catch (Exception ex)
            {
                _sender.Text += $" (이미지 로드 실패: {ex.Message})";
            }
        }

        /// <summary>
        /// 이미지 크기 조정 (width 고정, height 유동적)
        /// </summary>
        private void AdjustImageSize(int originalWidth, int originalHeight)
        {
            // 이미지 표시 영역의 고정 너비 (367 - 8(padding) - 40(avatar) - 8(margin) - 8(padding) = 303)
            const int fixedWidth = 303;

            // 비율 유지하면서 width에 맞춰 height 계산
            float ratio = (float)fixedWidth / originalWidth;
            int newHeight = (int)(originalHeight * ratio);

            _imageBox.Width = fixedWidth;
            _imageBox.Height = newHeight;
        }

        /// <summary>
        /// 현재 이미지 반환
        /// </summary>
        public Image GetImage()
        {
            return _imageContent;
        }
    }
}
