using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace ChattingAppTeam6.Auth
{
    public partial class MultiProfiles : Form
    {
        private int user_id;

        public MultiProfiles(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        private void MultiProfiles_Load(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        // 프로필 목록 로드
        private void LoadProfiles()
        {
            profilePanel.Controls.Clear(); // 기존 컨트롤 초기화

            // DB에서 프로필 목록 조회
            string query = $@"
                SELECT id, nickname, image 
                FROM s5819937.profile 
                WHERE user_id={user_id}
                ORDER BY is_default DESC;
            ";
            DataTable dt = DBConnector.GetInstance().Table(query);

            profilePanel.AutoScroll = true;
            profilePanel.FlowDirection = FlowDirection.TopDown;
            profilePanel.WrapContents = false;     // 자동 줄바꿈 방지

            foreach (DataRow row in dt.Rows)
            {
                byte[] imgBytes = row["image"] == DBNull.Value ? null : (byte[])row["image"];

                profilePanel.Controls.Add(CreateProfileCard(
                    Convert.ToInt32(row["id"]),
                    row["nickname"].ToString(),
                    imgBytes
                ));
            }

            // "멀티프로필 만들기" 버튼 패널
            profilePanel.Controls.Add(CreateAddProfileCard());
        }

        // 멀티프로필 패널 생성
        private Panel CreateProfileCard(int profile_id, string nickname, byte[] imgBytes)
        {
            Panel panel = new Panel
            {
                Width = 310,
                Height = 50,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None
            };

            PictureBox pic = new PictureBox
            {
                Width = 36,
                Height = 36,
                Left = 10,
                Top = 6,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = imgBytes != null ?
                        Image.FromStream(new MemoryStream(imgBytes)) :
                        Properties.Resources.BasicImage,
            };

            Label nameLabel = new Label
            {
                Text = nickname,
                Location = new Point(50, 15),
                AutoSize = true,
                Font = new Font("맑은 고딕", 11)
            };

            Button friendButton = new Button
            {
                Text = "친구관리",
                Width = 80,
                Height = 30,
                Location = new Point(220, 10),
                BackColor = Color.WhiteSmoke,
                Font = new Font("맑은 고딕", 10)
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(friendButton);

            // 닉네임 또는 패널 클릭 시 멀티프로필 닉네임 편집 창 로드
            nameLabel.Click += (s, e) =>
            {
                OpenEditMultiProfile(profile_id);
            };
            panel.Click += (s, e) =>
            {
                OpenEditMultiProfile(profile_id);
            };
            // 친구관리 버튼 클릭 시 친구 관리 창 로드
            friendButton.Click += (s, e) =>
            {
                OpenManageFriends(profile_id);
            };

            return panel;
        }

        // "멀티프로필 만들기" 패널
        private Panel CreateAddProfileCard()
        {
            Panel panel = new Panel
            {
                Width = 310,
                Height = 50,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None
            };

            PictureBox pic = new PictureBox
            {
                Width = 36,
                Height = 36,
                Left = 10,
                Top = 6,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.PlusIcon
            };

            Label label = new Label
            {
                Text = "멀티프로필 만들기",
                AutoSize = true,
                Font = new Font("맑은 고딕", 11),
                Left = 50,
                Top = 15
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(label);

            // 텍스트 또는 패널 클릭 시 멀티프로필 닉네임 편집 창 로드
            label.Click += (s, e) =>
            {
                OpenCreateMultiPofile();
            };
            panel.Click += (s, e) =>
            {
                OpenCreateMultiPofile();
            };

            return panel;
        }

        // 친구 관리 버튼
        private void ManageFriendsButton_Click(object sender, EventArgs e)
        {
            OpenManageFriends(-1);
        }


        // 멀티프로필 생성 폼 열기
        private void OpenCreateMultiPofile()
        {
            this.Hide();
            var frm = new CreateMultiProfile(user_id);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadProfiles();
            this.Show();
        }

        // 멀티프로필 편집 폼 열기
        private void OpenEditMultiProfile(int profile_id)
        {
            this.Hide();
            var frm = new CreateMultiProfile(user_id, profile_id);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadProfiles();
            this.Show();
        }

        // 친구 관리 폼 열기
        private void OpenManageFriends(int profile_id)
        {
            this.Hide();
            var frm = new ManageFriendsForm(user_id, profile_id);
            frm.ShowDialog();
            this.Show();
        }
    }
}
