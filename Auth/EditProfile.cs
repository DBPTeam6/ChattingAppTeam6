using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace ChattingAppTeam6.Auth
{
    public partial class UpdateUserInfo : Form
    {
        private static readonly HttpClient http = new HttpClient();

        private int user_id;
        private bool pwcheck = false;
        private string selectedImagePath = null;

        public UpdateUserInfo(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        // 폼 로드 시
        private void EditProfile_Load(object sender, EventArgs e)
        {
            LoadUserInfo();

            // 수정 불가 항목 비활성화
            IdBox.Enabled = false;
            TeamBox.Enabled = false;
        }

        private void LoadUserInfo()
        {
            string query = $@"
                SELECT 
                    u.login_id, 
                    u.name, 
                    p.nickname, 
                    u.address, 
                    u.zipcode, 
                    CONCAT(d.name, ' ', t.name) AS team, 
                    p.image
                FROM s5819937.user u
                LEFT JOIN s5819937.team t ON u.team_id = t.id
                LEFT JOIN s5819937.department d ON t.department_id = d.id
                LEFT JOIN s5819937.profile p ON p.user_id = u.id
                WHERE u.id = {user_id};
            ";
            DataTable user = DBConnector.GetInstance().Table(query);

            if (user.Rows.Count == 1)
            {
                DataRow row = user.Rows[0];
                IdBox.Text = row["login_id"].ToString();
                NameBox.Text = row["name"].ToString();
                NicknameBox.Text = row["nickname"].ToString();
                TeamBox.Text = row["team"].ToString();
                AddressBox.Text = row["address"].ToString();
                ZipcodeBox.Text = row["zipcode"].ToString();

                // 이미지 있을 경우 BLOB → Image 변환
                if (row["image"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["image"];
                    ProfileBox.Image = Image.FromStream(new MemoryStream(imgBytes));
                }
                else
                    ProfileBox.Image = Properties.Resources.BasicImage;
            }
        }

        // 비밀번호 확인
        private void PwCheckBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PwBox.Text) && PwBox.Text == PwCheckBox.Text)
                pwcheck = true;
            else
                pwcheck = false;
        }

        // 프로필 설정
        private void UpdateImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ProfileBox.Image = Image.FromFile(ofd.FileName);
                    selectedImagePath = ofd.FileName; // 선택 이미지 경로 저장
                }
            }
        }

        // 주소 찾기
        private async void FindAddrButton_Click(object sender, EventArgs e)
        {
            string keyword = AddressBox.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("검색어를 입력하세요.");
                return;
            }

            var popup = new AddressSelectForm(keyword);

            if (popup.ShowDialog() == DialogResult.OK)
            {
                AddressBox.Text = popup.Address;
                ZipcodeBox.Text = popup.ZipCode;
            }
        }

        // 회원정보 변경
        private void UpdateInfoButton_Click(object sender, EventArgs e)
        {
            // 비밀번호 확인x
            if (!pwcheck)
            {
                MessageBox.Show("비밀번호 확인이 일치하지 않습니다.");
                return;
            }

            // === user 변경 ====
            string updateQuery = $@"
                UPDATE s5819937.user
                SET login_pw = '{PwBox.Text}',
                    name = '{NameBox.Text}',
                    address = '{AddressBox.Text}',
                    zipcode = '{ZipcodeBox.Text}'
                WHERE id = {user_id};
            ";
            int User_result = DBConnector.GetInstance().Insert(updateQuery);

            // === profile 변경 ===
            string profileQuery;
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            if (selectedImagePath != null) // 프로필 사진 변경 시
            {
                // 이미지 byte[]로 변환
                byte[] imgBytes = File.ReadAllBytes(selectedImagePath);
                profileQuery = @"
                    UPDATE s5819937.profile
                    SET nickname = @nickname,
                        image = @img
                    WHERE id = @user_id;
                ";
                parameters.AddRange(new MySqlParameter[]
                {
                    new MySqlParameter("@nickname", MySqlDbType.VarChar) { Value = NicknameBox.Text },
                    new MySqlParameter("@img", MySqlDbType.Blob) { Value = imgBytes },
                    new MySqlParameter("@profile_id", MySqlDbType.Int32) { Value = user_id }
                });
            }
            else // 프로필 사진 변경 없을 경우
            {
                profileQuery = @"
                    UPDATE s5819937.profile
                    SET nickname = @nickname,
                    WHERE id = @user_id;
                ";
                parameters.AddRange(new MySqlParameter[]
                {
                    new MySqlParameter("@nickname", MySqlDbType.VarChar) { Value = NicknameBox.Text }
                });
            }

            int Profile_result = DBConnector.GetInstance().Execute(profileQuery, parameters);

            if (User_result == 0 || Profile_result == 0)
            {
                MessageBox.Show("회원정보 변경에 실패하였습니다.");
                return;
            }

            MessageBox.Show("회원정보가 변경되었습니다.");
            this.DialogResult = DialogResult.OK;
        }
    }
}
