using ChattingAppTeam6.Admin;
using ChattingAppTeam6.Home;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingAppTeam6.Auth
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // 폼 로드 시 설정 로드 및 초기 동작 수행
        private void Login_Load(object sender, EventArgs e)
        {
            // 설정값 UI 반영
            AutoLoginCheckBox.Checked = ConfigManager.GetInstance().AutoLoginChecked();
            RememberInfoCheckBox.Checked = ConfigManager.GetInstance().RememeberInfoChecked();

            string id = ConfigManager.GetInstance().Id();
            string pw = ConfigManager.GetInstance().Password();

            // 자동 로그인 설정 확인
            if (ConfigManager.GetInstance().AutoLoginChecked())
            {
                login(id, pw);
            }
            // 로그인 정보 기억하기 설정 확인
            if (ConfigManager.GetInstance().RememeberInfoChecked())
            {
                IdBox.Text = id;
                PwBox.Text = pw;
            }
        }

        // 자동로그인　체크　저장
        private void AutoLoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.GetInstance().SaveFlags(
                AutoLoginCheckBox.Checked,
                RememberInfoCheckBox.Checked
            );
        }

        // 아이디, 비밀번호 기억　체크　저장
        private void RememberInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.GetInstance().SaveFlags(
                AutoLoginCheckBox.Checked,
                RememberInfoCheckBox.Checked
            );
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

        // 비밀번호 확인
        private bool checkPw(string inputPw, DataTable userRow)
        {
            string storedHash = userRow.Rows[0]["login_pw"].ToString();
            string salt = userRow.Rows[0]["salt"] == DBNull.Value ? null : userRow.Rows[0]["salt"].ToString();

            if (string.IsNullOrEmpty(salt)) // 기존 user
            {
                return inputPw == storedHash;
            }
            else // 신규 user
            {
                string inputHash = ComputeSHA256(inputPw + salt);
                return inputHash == storedHash;
            }
        }

        // 로그인 버튼
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string id = IdBox.Text;
            string password = PwBox.Text;

            login(id, password);
        }

        // 로그인 로직
        private void login(string id, string password)
        {
            string query = $"SELECT id, login_pw, salt FROM s5819937.user WHERE login_id='{id}';";
            DataTable checkUser = DBConnector.GetInstance().CheckUser(query);

            if (checkUser.Rows.Count != 1)
            {
                MessageBox.Show("회원정보가 없습니다.");
            }
            else
            {
                int userId = Convert.ToInt32(checkUser.Rows[0]["id"]); // user_id

                if (checkPw(password, checkUser) == false)
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다.");
                    return;
                }

                // 로그인 성공 처리
                if (AutoLoginCheckBox.Checked || RememberInfoCheckBox.Checked)
                    // 계정 정보 저장
                    ConfigManager.GetInstance().SaveUser(id, password);
                else
                    // 모든 체크박스 해제 → 저장된 계정 삭제
                    ConfigManager.GetInstance().ClearUser();

                MessageBox.Show("로그인에 성공하였습니다.");

                if (id.Equals("admin"))
                {
                    // 관리자 화면
                    this.Hide();
                    new AdminShellForm().ShowDialog();

                    this.Show();
                }   
                else
                {
                    // 사용자 화면
                    this.Hide();
                    new HomeMain(userId).ShowDialog();

                    this.Show();
                }
            }
        }

        // 회원가입 창 열기
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            var signUp = new SignUp();
            signUp.ShowDialog(); // SignUp.Form으로 이동

            this.Show();
        }
    }
}
