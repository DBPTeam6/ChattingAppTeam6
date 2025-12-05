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
using System.Text.Json;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ChattingAppTeam6.Auth
{
    public partial class SignUp : Form
    {
        private bool idcheck = false;
        private bool pwcheck = false;
        private string selectedImagePath = null;

        public SignUp()
        {
            InitializeComponent();
            this.Load += SignUp_Load;
        }

        // 폼 로드 시
        private void SignUp_Load(object sender, EventArgs e)
        {
            ProfileBox.Image = Properties.Resources.BasicImage; // 기본이미지 불러오기
            GetDepartmentName();
        }

        // ComboBox에 부서, 팀 이름 로드
        private void GetDepartmentName()
        {
            string query = $@"
                SELECT T.id AS team_id, CONCAT(D.name, ' ', T.name) AS DisplayText
                FROM s5819937.department D
                JOIN s5819937.team T ON D.id = T.department_id;
            ";
            DataTable getDepartment = DBConnector.GetInstance().Table(query);

            TeamBox.DisplayMember = "DisplayText";
            TeamBox.ValueMember = "team_id";
            TeamBox.DataSource = getDepartment;

            TeamBox.SelectedIndex = -1;
        }

        // 아이디 중복 확인
        private void IdCheckButton_Click(object sender, EventArgs e)
        {
            string id = IdBox.Text;
            string query = $"SELECT login_id FROM s5819937.user WHERE login_id='{id}';";
            DataTable checkID = DBConnector.GetInstance().CheckUser(query);

            if (checkID.Rows.Count != 1)
            {
                MessageBox.Show("아이디 사용 가능");
                idcheck = true;
            }
            else
            {
                MessageBox.Show("새로운 아이디를 입력해주세요.");
                idcheck = false;
            }
        }

        // 아이디 변경할 경우 idcheck = false 설정
        private void IdBox_TextChanged(object sender, EventArgs e)
        {
            idcheck = false;
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

        // Salt 생성
        private string GenerateSalt(int size = 16)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[size];
            random.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        // SHA-256 해시
        private string ComputeSHA256(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(rawData);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }


        // 회원가입 버튼
        private void SignupButton_Click(object sender, EventArgs e)
        {
            // 아이디 중복확인x
            if (!idcheck)
            {
                MessageBox.Show("아이디 중복 확인을 해주세요.");
                return;
            }
            // 비밀번호 확인x
            if (!pwcheck)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            // 닉네임 미입력 시 이름과 동일하게 적용
            if (string.IsNullOrEmpty(NicknameBox.Text))
                NicknameBox.Text = NameBox.Text;

            if (
                string.IsNullOrWhiteSpace(IdBox.Text) ||
                string.IsNullOrWhiteSpace(PwBox.Text) ||
                string.IsNullOrWhiteSpace(PwCheckBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(NicknameBox.Text) ||
                TeamBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(AddressBox.Text) ||
                string.IsNullOrWhiteSpace(ZipcodeBox.Text))
            {
                MessageBox.Show("모든 정보를 입력해야 합니다.");
                return;
            }

            string salt = GenerateSalt(); // 랜덤 Salt 생성
            string hashedPw = ComputeSHA256(PwBox.Text + salt); // Pw+Salt 해싱

            // === user 삽입 ====
            int teamId = Convert.ToInt32(TeamBox.SelectedValue);

            string insertUserQuery = $@"
                INSERT INTO s5819937.user(team_id, login_id, login_pw, name, address, zipcode, salt)
                VALUES ('{teamId}', '{IdBox.Text}', '{hashedPw}', '{NameBox.Text}',
                        '{AddressBox.Text}', '{ZipcodeBox.Text}', '{salt}');
            ";
            int User_result = DBConnector.GetInstance().Insert(insertUserQuery);

            DataTable dt = DBConnector.GetInstance().Table($"SELECT id FROM s5819937.user WHERE login_id='{IdBox.Text}';");
            int userId = Convert.ToInt32(dt.Rows[0][0]);

            // === profile 삽입 ===
            string profileQuery = @"
                INSERT INTO s5819937.profile (user_id, nickname, image, is_default)
                VALUES (@user_id, @nickname, @img, 1);
            ";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@user_id", MySqlDbType.Int32) { Value = userId },
                new MySqlParameter("@nickname", MySqlDbType.VarChar) { Value = NicknameBox.Text },
                new MySqlParameter("@img", MySqlDbType.Blob)
                {
                    Value = selectedImagePath != null ? File.ReadAllBytes(selectedImagePath) : null
                }
            };
            int Profile_result = DBConnector.GetInstance().Execute(profileQuery, parameters);

            if (User_result == 0 || Profile_result == 0)
            {
                MessageBox.Show("회원가입에 실패하였습니다.");
                return;
            }

            MessageBox.Show("회원가입에 성공하였습니다.");
            this.Close();
        }
    }
}
