using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static ChattingAppTeam6.Admin.DBconnector;

namespace ChattingAppTeam6.Admin
{
    public partial class AdminShellForm : Form
    {
        private DBConnector db = DBConnector.GetInstance();

        // 현재 선택된 기준 직원(user.id)
        private int? _baseUserId = null;

        public AdminShellForm()
        {
            InitializeComponent();

            // DB 연결 문자열 설정 (로그인 폼에서 이미 했다면 이 줄은 지워도 됨)
            db.SetConnectString(
                "223.130.151.111",
                "3306",
                "s5819937",
                "s5819937",
                "s5819937"
            );

            this.Load += AdminShellForm_Load;

            // 팀 클릭 시 해당 팀 직원만 필터링 표시
            dgvTeams.CellContentClick += dgvTeams_CellContentClick;
        }

        // ---------------- 공통 유틸 ----------------

        private void AdminShellForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadDepartmentComboBoxes();
            LoadEmployees();
            InitLogDatePickers();
        }

        private string Escape(string s)
        {
            return s?.Replace("'", "''") ?? "";
        }

        private void InitLogDatePickers()
        {
            dtLogTo.Value = DateTime.Today;
            dtLogFrom.Value = DateTime.Today.AddDays(-7);
        }

        // =============== [B, F] 부서/팀 관리 ===============

        private void LoadDepartments(string keyword = "")
        {
            string sql = "SELECT id, name FROM department";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += $" WHERE name LIKE '%{Escape(keyword)}%'";
            }

            sql += " ORDER BY id";

            DataTable dt = db.Query(sql);
            dgvDepartments.DataSource = dt;

            if (dgvDepartments.Columns.Count > 0)
            {
                dgvDepartments.Columns["id"].HeaderText = "부서ID";
                dgvDepartments.Columns["name"].HeaderText = "부서명";
            }
        }

        private int? GetSelectedDepartmentId()
        {
            if (dgvDepartments.CurrentRow == null) return null;
            object val = dgvDepartments.CurrentRow.Cells["id"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void LoadTeamsForDepartment(int? deptId, string keyword = "")
        {
            if (deptId == null)
            {
                dgvTeams.DataSource = null;
                dgvDeptEmployees.DataSource = null;
                return;
            }

            string sql = $"SELECT id, name FROM team WHERE department_id = {deptId.Value}";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += $" AND name LIKE '%{Escape(keyword)}%'";
            }

            sql += " ORDER BY id";

            DataTable dt = db.Query(sql);
            dgvTeams.DataSource = dt;

            if (dgvTeams.Columns.Count > 0)
            {
                dgvTeams.Columns["id"].HeaderText = "팀ID";
                dgvTeams.Columns["name"].HeaderText = "팀명";
            }

            LoadDeptEmployees(deptId.Value);
        }

        private void LoadDeptEmployees(int deptId, int? teamId = null)
        {
            string sql = @"
                SELECT u.id AS user_id, u.name AS user_name,
                       t.name AS team_name
                FROM user u
                LEFT JOIN team t ON u.team_id = t.id
                LEFT JOIN department d ON t.department_id = d.id
                WHERE d.id = " + deptId;

            if (teamId != null)
            {
                sql += " AND u.team_id = " + teamId.Value;
            }

            sql += @" ORDER BY u.id";

            DataTable dt = db.Query(sql);
            dgvDeptEmployees.DataSource = dt;

            if (dgvDeptEmployees.Columns.Count > 0)
            {
                dgvDeptEmployees.Columns["user_id"].HeaderText = "직원ID";
                dgvDeptEmployees.Columns["user_name"].HeaderText = "이름";
                dgvDeptEmployees.Columns["team_name"].HeaderText = "팀";
            }
        }

        // 새 부서 추가
        private void AddDept_Click(object sender, EventArgs e)
        {
            string name = NewDeptName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("부서 이름을 입력하세요.");
                return;
            }

            string sql = $"INSERT INTO department(name) VALUES('{Escape(name)}')";
            int rows = db.ExecuteNonQuery(sql);

            if (rows > 0)
            {
                MessageBox.Show("부서가 추가되었습니다.");
                NewDeptName.Clear();
                LoadDepartments();
                LoadDepartmentComboBoxes();
            }
        }

        // 새 팀 추가 (현재 선택된 부서 기준)
        private void AddTeam_Click(object sender, EventArgs e)
        {
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("팀을 추가할 부서를 먼저 선택하세요.");
                return;
            }

            string name = NewTeamName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("팀 이름을 입력하세요.");
                return;
            }

            string sql = $"INSERT INTO team(department_id, name) VALUES({deptId.Value}, '{Escape(name)}')";
            int rows = db.ExecuteNonQuery(sql);

            if (rows > 0)
            {
                MessageBox.Show("팀이 추가되었습니다.");
                NewTeamName.Clear();
                LoadTeamsForDepartment(deptId);
                LoadDepartmentComboBoxes();
            }
        }

        // 부서 이름 변경
        private void btnDeptRename_Click(object sender, EventArgs e)
        {
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("이름을 변경할 부서를 선택하세요.");
                return;
            }

            string newName = txtDeptRename.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("새 부서 이름을 입력하세요.");
                return;
            }

            string sql = $"UPDATE department SET name = '{Escape(newName)}' WHERE id = {deptId.Value}";
            int rows = db.ExecuteNonQuery(sql);

            if (rows > 0)
            {
                MessageBox.Show("부서명이 변경되었습니다.");
                LoadDepartments();
                LoadDepartmentComboBoxes();
            }
        }

        // 부서 삭제 버튼 (너가 만든 이름: Delete_Click)
        private void Delete_Click(object sender, EventArgs e)
        {
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            if (MessageBox.Show("해당 부서를 삭제하시겠습니까?", "확인",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            string sql = $"DELETE FROM department WHERE id = {deptId.Value}";
            int rows = db.ExecuteNonQuery(sql);

            if (rows > 0)
            {
                MessageBox.Show("부서가 삭제되었습니다.");
                LoadDepartments();
                dgvTeams.DataSource = null;
                dgvDeptEmployees.DataSource = null;
                LoadDepartmentComboBoxes();
            }
        }

        // 부서 그리드 클릭 → 해당 부서 팀/직원 로드
        private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? deptId = GetSelectedDepartmentId();
            if (deptId != null)
            {
                LoadTeamsForDepartment(deptId);
            }
        }

        // 팀 그리드 클릭 → 해당 팀 직원만 로드
        private void dgvTeams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? deptId = GetSelectedDepartmentId();
            int? teamId = GetSelectedTeamId();
            if (deptId == null || teamId == null) return;

            LoadDeptEmployees(deptId.Value, teamId.Value);
        }

        // =============== [C, D, E] 직원/로그 관리 ===============

        private void LoadDepartmentComboBoxes()
        {
            DataTable dept = db.Query("SELECT id, name FROM department ORDER BY id");

            // 이벤트 일시 해제
            cmbNewDept.SelectedIndexChanged -= cmbNewDept_SelectedIndexChanged;
            cmbFilterDept.SelectedIndexChanged -= cmbFilterDept_SelectedIndexChanged;

            try
            {
                // 소속 변경용
                DataTable deptForChange = dept.Copy();
                cmbNewDept.DisplayMember = "name";
                cmbNewDept.ValueMember = "id";
                cmbNewDept.DataSource = deptForChange;

                // 직원 필터용 (전체 + 부서)
                DataTable deptFilter = dept.Copy();
                DataRow row = deptFilter.NewRow();
                row["id"] = 0;
                row["name"] = "전체";
                deptFilter.Rows.InsertAt(row, 0);

                cmbFilterDept.DisplayMember = "name";
                cmbFilterDept.ValueMember = "id";
                cmbFilterDept.DataSource = deptFilter;

                // 비공개 부서 설정용
                DataTable deptForHidden = dept.Copy();
                cmbHiddenDept.DisplayMember = "name";
                cmbHiddenDept.ValueMember = "id";
                cmbHiddenDept.DataSource = deptForHidden;
            }
            finally
            {
                // 이벤트 복원
                cmbNewDept.SelectedIndexChanged += cmbNewDept_SelectedIndexChanged;
                cmbFilterDept.SelectedIndexChanged += cmbFilterDept_SelectedIndexChanged;
            }
        }

        private void LoadTeamsForDeptCombo(int deptId)
        {
            string sql = $"SELECT id, name FROM team WHERE department_id = {deptId} ORDER BY id";
            DataTable dt = db.Query(sql);

            cmbNewTeam.DataSource = dt;
            cmbNewTeam.DisplayMember = "name";
            cmbNewTeam.ValueMember = "id";
        }

        private void LoadEmployees()
        {
            int? deptFilter = null;
            var sel = cmbFilterDept.SelectedValue;

            if (sel != null)
            {
                int v = 0;
                if (sel is DataRowView drv)
                {
                    var idObj = drv["id"];
                    int.TryParse(idObj?.ToString(), out v);
                }
                else
                {
                    int.TryParse(sel.ToString(), out v);
                }
                if (v != 0) deptFilter = v;
            }

            string keyword = txtSearchEmployee.Text.Trim();

            string sql = @"
                SELECT u.id AS user_id, u.name AS user_name,
                       d.name AS dept_name, t.name AS team_name
                FROM user u
                LEFT JOIN team t ON u.team_id = t.id
                LEFT JOIN department d ON t.department_id = d.id
                WHERE 1 = 1 ";

            if (deptFilter != null)
            {
                sql += $" AND d.id = {deptFilter.Value}";
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += $" AND u.name LIKE '%{Escape(keyword)}%'";
            }

            sql += " ORDER BY u.id";

            DataTable dt = db.Query(sql);
            dgvEmployees.DataSource = dt;

            if (dgvEmployees.Columns.Count > 0)
            {
                dgvEmployees.Columns["user_id"].HeaderText = "직원ID";
                dgvEmployees.Columns["user_name"].HeaderText = "이름";
                dgvEmployees.Columns["dept_name"].HeaderText = "부서";
                dgvEmployees.Columns["team_name"].HeaderText = "팀";
            }
        }

        private int? GetSelectedEmployeeId()
        {
            if (dgvEmployees.CurrentRow == null) return null;
            object val = dgvEmployees.CurrentRow.Cells["user_id"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void cmbFilterDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _baseUserId = GetSelectedEmployeeId();
            if (_baseUserId == null) return;

            string name = dgvEmployees.CurrentRow.Cells["user_name"].Value.ToString();
            lblBaseEmployee.Text = $"현재 선택된 직원 : {name} (ID: {_baseUserId})";

            LoadViewPermissions();
            LoadChatBlocks();
        }

        private void cmbNewDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = cmbNewDept.SelectedValue;
            if (val == null) return;

            if (val is DataRowView drv)
            {
                var idObj = drv["id"];
                if (idObj != null && idObj != DBNull.Value && int.TryParse(idObj.ToString(), out int idFromRow))
                {
                    LoadTeamsForDeptCombo(idFromRow);
                }
                return;
            }

            if (int.TryParse(val.ToString(), out int deptId))
            {
                LoadTeamsForDeptCombo(deptId);
            }
        }

        private void cmbNewTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 필요하면 사용, 지금은 비워두어도 됨
        }

        // 소속 팀 변경
        private void btnChangeTeam_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("소속을 변경할 직원을 먼저 선택하세요.");
                return;
            }

            if (cmbNewTeam.SelectedValue == null)
            {
                MessageBox.Show("변경할 팀을 선택하세요.");
                return;
            }

            int newTeamId = Convert.ToInt32(cmbNewTeam.SelectedValue);
            string sql = $"UPDATE user SET team_id = {newTeamId} WHERE id = {_baseUserId.Value}";

            int rows = db.ExecuteNonQuery(sql);
            if (rows > 0)
            {
                MessageBox.Show("소속 팀이 변경되었습니다.");
                LoadEmployees();
            }
        }

        // -------- [D] 대화 내용 검색 --------

        private void btnSearchMessages_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("대화 내용을 조회할 직원을 선택하세요.");
                return;
            }

            string keyword = txtMessageKeyword.Text.Trim();
            string from = dtLogFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string to = dtLogTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sql = $@"
                SELECT l.timestamp, l.command, l.content, c.name AS chat_name
                FROM server_log l
                LEFT JOIN chat c ON l.chat_id = c.id
                WHERE l.profile_id IN (
                    SELECT id FROM profile WHERE user_id = {_baseUserId.Value}
                )
                AND l.command = 'MESSAGE'
                AND l.timestamp BETWEEN '{from}' AND '{to}'";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += $" AND l.content LIKE '%{Escape(keyword)}%'";
            }

            sql += " ORDER BY l.timestamp";

            DataTable dt = db.Query(sql);
            dgvLogs.DataSource = dt;
        }

        // -------- [E] 로그인/로그아웃 기록 검색 --------

        private void btnSearchLoginLog_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("로그인 기록을 조회할 직원을 선택하세요.");
                return;
            }

            string from = dtLogFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string to = dtLogTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sql = $@"
                SELECT l.timestamp, l.command, l.content
                FROM server_log l
                WHERE l.profile_id IN (
                    SELECT id FROM profile WHERE user_id = {_baseUserId.Value}
                )
                AND l.command IN ('LOGIN','LOGOUT')
                AND l.timestamp BETWEEN '{from}' AND '{to}'
                ORDER BY l.timestamp";

            DataTable dt = db.Query(sql);
            dgvLogs.DataSource = dt;
        }

        // =============== [G] 직원 보기 권한(user_relation) ===============

        private void LoadViewPermissions()
        {
            if (_baseUserId == null) return;

            // 부서 단위 비공개 (relation_type = 'HIDE_DEPT', target_user_id에 department.id 저장)
            string sqlDept = $@"
                SELECT ur.id, d.name AS dept_name
                FROM user_relation ur
                JOIN department d ON ur.target_user_id = d.id
                WHERE ur.user_id = {_baseUserId.Value}
                  AND ur.relation_type = 'HIDE_DEPT'";

            DataTable dtDept = db.Query(sqlDept);
            dgvHiddenDepts.DataSource = dtDept;
            if (dgvHiddenDepts.Columns.Count > 0)
            {
                dgvHiddenDepts.Columns["id"].HeaderText = "ID";
                dgvHiddenDepts.Columns["dept_name"].HeaderText = "비공개 부서";
            }

            // 직원 단위 비공개 (relation_type = 'HIDE_USER')
            string sqlUser = $@"
                SELECT ur.id, u.name AS user_name
                FROM user_relation ur
                JOIN user u ON ur.target_user_id = u.id
                WHERE ur.user_id = {_baseUserId.Value}
                  AND ur.relation_type = 'HIDE_USER'";

            DataTable dtUser = db.Query(sqlUser);
            dgvHiddenEmployees.DataSource = dtUser;
            if (dgvHiddenEmployees.Columns.Count > 0)
            {
                dgvHiddenEmployees.Columns["id"].HeaderText = "ID";
                dgvHiddenEmployees.Columns["user_name"].HeaderText = "비공개 직원";
            }

            // 비공개 대상 직원 콤보
            DataTable allUsers = db.Query("SELECT id, name FROM user ORDER BY id");
            cmbHiddenEmployee.DataSource = allUsers;
            cmbHiddenEmployee.DisplayMember = "name";
            cmbHiddenEmployee.ValueMember = "id";
        }

        private int? GetSelectedRowId(DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return null;
            object val = dgv.CurrentRow.Cells["id"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void btnAddHiddenDept_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("기준 직원을 먼저 선택하세요.");
                return;
            }

            if (cmbHiddenDept.SelectedValue == null)
            {
                MessageBox.Show("비공개 할 부서를 선택하세요.");
                return;
            }

            int deptId = Convert.ToInt32(cmbHiddenDept.SelectedValue);

            string sql = $@"
                INSERT INTO user_relation(user_id, target_user_id, relation_type)
                VALUES ({_baseUserId.Value}, {deptId}, 'HIDE_DEPT')";

            db.ExecuteNonQuery(sql);
            LoadViewPermissions();
        }

        private void btnRemoveHiddenDept_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedRowId(dgvHiddenDepts);
            if (id == null) return;

            string sql = $"DELETE FROM user_relation WHERE id = {id.Value}";
            db.ExecuteNonQuery(sql);
            LoadViewPermissions();
        }

        private void btnAddHiddenEmployee_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("기준 직원을 먼저 선택하세요.");
                return;
            }

            if (cmbHiddenEmployee.SelectedValue == null)
            {
                MessageBox.Show("비공개 할 직원을 선택하세요.");
                return;
            }

            int targetUserId = Convert.ToInt32(cmbHiddenEmployee.SelectedValue);

            string sql = $@"
                INSERT INTO user_relation(user_id, target_user_id, relation_type)
                VALUES ({_baseUserId.Value}, {targetUserId}, 'HIDE_USER')";

            db.ExecuteNonQuery(sql);
            LoadViewPermissions();
        }

        private void btnRemoveHiddenEmployee_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedRowId(dgvHiddenEmployees);
            if (id == null) return;

            string sql = $"DELETE FROM user_relation WHERE id = {id.Value}";
            db.ExecuteNonQuery(sql);
            LoadViewPermissions();
        }

        // 그리드 클릭 이벤트는 안 써도 되니 비워둠
        private void dgvHiddenDepts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvHiddenEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // =============== [H] 대화 차단 권한(user_relation) ===============

        private void LoadChatBlocks()
        {
            if (_baseUserId == null) return;

            string sql = $@"
                SELECT ur.id, u.name AS user_name
                FROM user_relation ur
                JOIN user u ON ur.target_user_id = u.id
                WHERE ur.user_id = {_baseUserId.Value}
                  AND ur.relation_type = 'BLOCK_CHAT'";

            DataTable dt = db.Query(sql);
            // 디자이너에서 dataGridView1이 "대화 불가능한 직원" 그리드라고 가정
            dgvBlockedEmployees.DataSource = dt;

            if (dgvBlockedEmployees.Columns.Count > 0)
            {
                dgvBlockedEmployees.Columns["id"].HeaderText = "ID";
                dgvBlockedEmployees.Columns["user_name"].HeaderText = "차단된 직원";
            }

            DataTable allUsers = db.Query("SELECT id, name FROM user ORDER BY id");
            cmbBlockedEmployee.DataSource = allUsers;
            cmbBlockedEmployee.DisplayMember = "name";
            cmbBlockedEmployee.ValueMember = "id";
        }

        private void btnAddChatBlock_Click(object sender, EventArgs e)
        {
            if (_baseUserId == null)
            {
                MessageBox.Show("차단 기준 직원을 먼저 선택하세요.");
                return;
            }

            if (cmbBlockedEmployee.SelectedValue == null)
            {
                MessageBox.Show("차단할 직원을 선택하세요.");
                return;
            }

            int targetUserId = Convert.ToInt32(cmbBlockedEmployee.SelectedValue);

            string sql = $@"
                INSERT INTO user_relation(user_id, target_user_id, relation_type)
                VALUES ({_baseUserId.Value}, {targetUserId}, 'BLOCK_CHAT')";

            db.ExecuteNonQuery(sql);
            LoadChatBlocks();
        }

        private void btnRemoveChatBlock_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedRowId(dgvBlockedEmployees);
            if (id == null) return;

            string sql = $"DELETE FROM user_relation WHERE id = {id.Value}";
            db.ExecuteNonQuery(sql);
            LoadChatBlocks();
        }

        // dataGridView1_CellContentClick → dgvBlockedEmployees라고 가정
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 필요 없으면 비워둬도 됨
        }

        private void tabEmployee_Click(object sender, EventArgs e)
        {
            // 탭 클릭 시 특별히 할 일 없으면 비워둬도 됨
        }

        // 로그아웃 링크
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 필요하다면 로그인 폼 다시 띄우기
            // var loginForm = new LoginForm();
            // loginForm.Show();

            this.Close();
        }

        private void search_dept_Click(object sender, EventArgs e)
        {
            // 부서 키워드로 부서 목록 필터링
            string deptKeyword = SearchDept.Text.Trim();
            LoadDepartments(deptKeyword);

            // 현재 선택된 부서 기준으로 팀 목록도 팀 검색 키워드 반영하여 갱신
            int? deptId = GetSelectedDepartmentId();
            LoadTeamsForDepartment(deptId, SearchTeam.Text.Trim());
        }

        private void search_team_Click(object sender, EventArgs e)
        {
            // 현재 선택된 부서 기준으로 팀 목록만 필터링
            int? deptId = GetSelectedDepartmentId();
            LoadTeamsForDepartment(deptId, SearchTeam.Text.Trim());
        }

        private void TeamsDelete_Click(object sender, EventArgs e)
        {
            // 선택된 팀 삭제 처리
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("삭제할 팀이 속한 부서를 먼저 선택하세요.");
                return;
            }

            int? teamId = GetSelectedTeamId();
            if (teamId == null)
            {
                MessageBox.Show("삭제할 팀을 선택하세요.");
                return;
            }

            // 팀에 소속된 직원 수 확인
            DataTable cntDt = db.Query($"SELECT COUNT(*) AS cnt FROM user WHERE team_id = {teamId.Value}");
            int memberCount = 0;
            if (cntDt.Rows.Count > 0 && cntDt.Columns.Contains("cnt"))
            {
                int.TryParse(cntDt.Rows[0]["cnt"].ToString(), out memberCount);
            }

            if (memberCount > 0)
            {
                var confirm = MessageBox.Show(
                    $"이 팀에는 {memberCount}명의 직원이 소속되어 있습니다. 직원들의 소속을 해제(팀 NULL)하고 팀을 삭제하시겠습니까?",
                    "확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                // 직원 소속 해제
                db.ExecuteNonQuery($"UPDATE user SET team_id = NULL WHERE team_id = {teamId.Value}");
            }
            else
            {
                var confirm = MessageBox.Show("해당 팀을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            // 팀 삭제
            db.ExecuteNonQuery($"DELETE FROM team WHERE id = {teamId.Value}");

            // 목록 갱신 (검색 키워드 유지)
            LoadTeamsForDepartment(deptId, SearchTeam.Text.Trim());
            LoadDeptEmployees(deptId.Value);
        }

        private void EmployeesDelete_Click(object sender, EventArgs e)
        {
            // 부서 내 직원 목록에서 선택된 직원을 팀에서 제거(팀 NULL)
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("직원을 제거할 부서를 먼저 선택하세요.");
                return;
            }

            int? userId = GetSelectedDeptEmployeeUserId();
            if (userId == null)
            {
                MessageBox.Show("제거할 직원을 선택하세요.");
                return;
            }

            var confirm = MessageBox.Show(
                "선택한 직원을 현재 팀에서 제거하시겠습니까? (직원 데이터는 삭제되지 않음)",
                "확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            // 팀 소속 해제
            db.ExecuteNonQuery($"UPDATE user SET team_id = NULL WHERE id = {userId.Value}");

            // 목록 갱신
            LoadTeamsForDepartment(deptId, SearchTeam.Text.Trim());
            LoadDeptEmployees(deptId.Value);
        }

        // ================== 헬퍼: 선택 ID ==================
        private int? GetSelectedTeamId()
        {
            if (dgvTeams.CurrentRow == null) return null;
            object val = dgvTeams.CurrentRow.Cells["id"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private int? GetSelectedDeptEmployeeUserId()
        {
            if (dgvDeptEmployees.CurrentRow == null) return null;
            object val = dgvDeptEmployees.CurrentRow.Cells["user_id"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void btnTeamRename_Click(object sender, EventArgs e)
        {
            // 팀 이름 변경
            int? deptId = GetSelectedDepartmentId();
            if (deptId == null)
            {
                MessageBox.Show("팀 이름을 변경할 부서를 먼저 선택하세요.");
                return;
            }

            int? teamId = GetSelectedTeamId();
            if (teamId == null)
            {
                MessageBox.Show("이름을 변경할 팀을 선택하세요.");
                return;
            }

            string newName = txtTeamRename.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("새 팀 이름을 입력하세요.");
                return;
            }

            string sql = $"UPDATE team SET name = '{Escape(newName)}' WHERE id = {teamId.Value}";
            int rows = db.ExecuteNonQuery(sql);
            if (rows > 0)
            {
                MessageBox.Show("팀명이 변경되었습니다.");
                // 팀 목록 갱신(검색 키워드 유지)
                LoadTeamsForDepartment(deptId, SearchTeam.Text.Trim());
                // 직원 목록 갱신: 현재 선택 팀 기준으로 다시 로드
                LoadDeptEmployees(deptId.Value, teamId.Value);              
            }
        }
    }
}
