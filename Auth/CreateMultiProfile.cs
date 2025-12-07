using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChattingAppTeam6.Auth
{
    public partial class CreateMultiProfile : Form
    {
        private string selectedImagePath = null;

        private bool isEditMode = false;
        private int profile_id;
        private int user_id;

        // 멀티프로필 신규 생성
        public CreateMultiProfile(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            SetupCreateMode();
        }

        // 멀티프로필 편집 모드
        public CreateMultiProfile(int user_id, int profile_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.profile_id = profile_id;
            isEditMode = true;
            SetupEditMode();
        }

        private void SetupCreateMode()
        {
            titleLabel.Text = "멀티프로필 만들기";

            // 기본 이미지 설정
            ImageBox.Image = Properties.Resources.BasicImage;
        }

        private void SetupEditMode()
        {
            titleLabel.Text = "멀티프로필 편집";

            // DB에서 프로필사진 로드
            LoadProfileData();
        }

        // 프로필 사진 로드
        private void LoadProfileData()
        {
            string query = $"SELECT nickname, image FROM s5819937.profile WHERE id={profile_id};";
            DataTable dt = DBConnector.GetInstance().Table(query);

            if (dt.Rows.Count > 0)
            {
                NicknameBox.Text = dt.Rows[0]["nickname"].ToString();

                // 이미지 있을 경우 변환
                if (dt.Rows[0]["image"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])dt.Rows[0]["image"];
                    ImageBox.Image = Image.FromStream(new MemoryStream(imgBytes));
                }
                else
                    ImageBox.Image = Properties.Resources.BasicImage;
            }
        }

        // 프로필 사진 변경
        private void ImageBox_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ImageBox.Image = Image.FromFile(ofd.FileName);
                        selectedImagePath = ofd.FileName; // 선택 이미지 경로 저장
                    }
                }   
            }
        }

        // 확인 버튼
        private void confirmButton_Click(object sender, EventArgs e)
        {
            // 닉네임 미입력
            if (String.IsNullOrEmpty(NicknameBox.Text))
            {
                MessageBox.Show("닉네임을 입력해주세요.");
                return;
            }

            string query;
            List<MySqlParameter> parameters = new List<MySqlParameter>();


            // === 편집 모드 (profile 변경) ====
            if (isEditMode)
            {
                query = @"
                    UPDATE s5819937.profile
                    SET nickname = @nickname,
                        image = @img
                    WHERE id = @profile_id;
                ";
                parameters.AddRange(new MySqlParameter[]
                {
                    new MySqlParameter("@nickname", MySqlDbType.VarChar) { Value = NicknameBox.Text },
                    new MySqlParameter("@profile_id", MySqlDbType.Int32) { Value = profile_id },
                    new MySqlParameter("@img", MySqlDbType.Blob)
                    {
                        Value = selectedImagePath != null ? File.ReadAllBytes(selectedImagePath) : null
                    }
                });

                int result = DBConnector.GetInstance().Execute(query, parameters);

                if (result == 0)
                {
                    MessageBox.Show("멀티프로필 변경에 실패하였습니다.");
                    return;
                }
                MessageBox.Show("멀티프로필 변경에 성공하였습니다!");
            }

            // === 멀티프로필 생성 모드 (profile 삽입) ===
            else
            {
                query = @"
                    INSERT INTO s5819937.profile (user_id, nickname, image) 
                    VALUES (@user_id, @nickname, @img);
                ";

                parameters.AddRange(new MySqlParameter[]
                {
                    new MySqlParameter("@user_id", MySqlDbType.Int32) { Value = user_id },
                    new MySqlParameter("@nickname", MySqlDbType.VarChar) { Value = NicknameBox.Text},
                    new MySqlParameter("@img", MySqlDbType.Blob)
                    {
                        Value = selectedImagePath != null ? File.ReadAllBytes(selectedImagePath) : null
                    }
                });

                int result = DBConnector.GetInstance().Execute(query, parameters);

                if (result == 0)
                {
                    MessageBox.Show("멀티프로필 등록에 실패하였습니다.");
                    return;
                }

                MessageBox.Show("멀티프로필 등록에 성공하였습니다.");
            }
            this.DialogResult = DialogResult.OK;
        }

        // 취소 버튼
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
