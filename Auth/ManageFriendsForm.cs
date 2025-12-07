using System;
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
    public partial class ManageFriendsForm : Form
    {
        private int user_id;
        private int selected_profile_id = -1;

        public ManageFriendsForm(int user_id, int profile_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.selected_profile_id = profile_id;
        }

        private void ManageFriendsForm_Load(object sender, EventArgs e)
        {
            LoadMyProfiles(); // 내 프로필
            LoadEmployees(); // 직원 리스트
        }

        // 내 프로필 목록 로드
        private void LoadMyProfiles()
        {
            string query = $@"
                SELECT id, nickname, image
                FROM s5819937.profile
                WHERE user_id = {user_id};
            ";

            DataTable dt = DBConnector.GetInstance().Table(query);

            profileFlowPanel.Controls.Clear();
            profileFlowPanel.AutoScroll = true;
            profileFlowPanel.FlowDirection = FlowDirection.TopDown;

            foreach (DataRow row in dt.Rows)
            {
                byte[] imgBytes = row["image"] == DBNull.Value ? null : (byte[])row["image"];

                profileFlowPanel.Controls.Add(CreateProfileButton(
                    Convert.ToInt32(row["id"]),
                    row["nickname"].ToString(),
                    imgBytes
                ));
            }
        }

        // 직원 리스트 로드
        private void LoadEmployees()
        {
            string query = $@"
            SELECT 
                u.id, 
                u.name,
                CASE 
                    WHEN pa.profile_id = {selected_profile_id} THEN 1 
                    ELSE 0
                END AS is_checked
            FROM s5819937.user u
            LEFT JOIN s5819937.team t ON u.team_id = t.id
            LEFT JOIN s5819937.department d ON t.department_id = d.id
            LEFT JOIN s5819937.profile_access pa 
                ON u.id = pa.target_user_id
                AND pa.user_id = {user_id}
            WHERE u.id <> {user_id} AND u.login_id <> 'Admin'
            AND NOT EXISTS (
                SELECT 1
                FROM s5819937.user_relation ur
                WHERE ur.user_id = {user_id}
                    AND (
                         (ur.relation_type = 'HIDE_USER' AND ur.target_user_id = u.id)
                         OR
                         (ur.relation_type = 'HIDE_DEPT' AND ur.target_user_id = d.id)
                    )
                );
            ";

            DataTable dt = DBConnector.GetInstance().Table(query);

            userFlowPanel.Controls.Clear();
            userFlowPanel.AutoScroll = true;
            userFlowPanel.FlowDirection = FlowDirection.TopDown;

            foreach (DataRow row in dt.Rows)
            {
                bool isChecked = (Convert.ToInt32(row["is_checked"]) == 1);

                userFlowPanel.Controls.Add(CreateEmployeeCheckCard(
                    Convert.ToInt32(row["id"]),
                    row["name"].ToString(),
                    isChecked
                ));
            }
        }

        // 내 프로필 목록 패널 생성
        private Panel CreateProfileButton(int profile_id, string nickname, byte[] imgBytes)
        {
            Panel p = new Panel
            {
                Width = 200,
                Height = 50,
                Margin = new Padding(5),
                Cursor = Cursors.Hand,
                Padding = new Padding(3)
            };

            // 선택한 프로필 테두리 설정
            p.Paint += (s, e) =>
            {
                if (profile_id == selected_profile_id)
                {
                    using (Pen pen = new Pen(Color.CornflowerBlue, 3))
                    {
                        Rectangle rect = p.ClientRectangle;
                        rect.Inflate(-2, -2);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                }
            };

            PictureBox pic = new PictureBox
            {
                Width = 36,
                Height = 36,
                Left = 10,
                Top = 5,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = imgBytes != null ?
                    Image.FromStream(new MemoryStream(imgBytes))
                    : Properties.Resources.BasicImage,
            };

            Label lbl = new Label
            {
                Text = nickname,
                Left = 60,
                Top = 15,
                AutoSize = true,
                Font = new Font("맑은 고딕", 10)
            };

            p.Controls.Add(pic);
            p.Controls.Add(lbl);


            EventHandler clickEvent = (s, e) =>
            {
                selected_profile_id = profile_id;

                foreach (Control ctrl in profileFlowPanel.Controls)
                {
                    ctrl.Invalidate();
                }
                LoadEmployees();
            };

            p.Click += clickEvent;
            lbl.Click += clickEvent;

            return p;
        }

        // 직원 패널 생성
        private Panel CreateEmployeeCheckCard(int employee_id, string name, bool isChecked)
        {
            Panel p = new Panel
            {
                Width = 310,
                Height = 50,
                Margin = new Padding(5)
            };

            Label lbl = new Label
            {
                Text = $"{name}",
                Left = 10,
                Top = 13,
                AutoSize = true,
                Font = new Font("맑은 고딕", 10)
            };

            CheckBox cb = new CheckBox
            {
                Width = 20,
                Left = 280,
                Top = 15,
                Checked = isChecked // DB에서 가져온 상태 반영
            };

            p.Controls.Add(lbl);
            p.Controls.Add(cb);
            p.Tag = employee_id;

            return p;
        }

        // 설정 버튼 클릭 시 DB 저장
        private void SetButton_Click(object sender, EventArgs e)
        {
            if (selected_profile_id == -1)
            {
                MessageBox.Show("적용할 프로필을 먼저 선택해주세요.");
                return;
            }

            foreach (Panel panel in userFlowPanel.Controls)
            {
                CheckBox cb = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                if (cb == null) continue;

                int target_user_id = (int)panel.Tag;

                if (cb.Checked)
                {
                    string insert = $@"
                        INSERT INTO s5819937.profile_access(user_id, target_user_id, profile_id)
                        VALUES({user_id}, {target_user_id}, {selected_profile_id})
                        ON DUPLICATE KEY UPDATE profile_id = {selected_profile_id};
                    ";

                    DBConnector.GetInstance().Insert(insert);
                }
                else
                {
                    string query = $@"
                        DELETE FROM s5819937.profile_access 
                        WHERE user_id = {user_id} 
                          AND target_user_id = {target_user_id}
                          AND profile_id = {selected_profile_id}; 
                    ";
                    DBConnector.GetInstance().Insert(query);
                }
            }

            MessageBox.Show("설정 완료되었습니다.");
            this.DialogResult = DialogResult.OK;
        }
    }
}
