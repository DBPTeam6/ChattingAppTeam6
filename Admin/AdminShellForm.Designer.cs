namespace ChattingAppTeam6.Admin
{
    partial class AdminShellForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDepartment = new System.Windows.Forms.TabPage();
            this.EmployeesDelete = new System.Windows.Forms.Button();
            this.TeamsDelete = new System.Windows.Forms.Button();
            this.search_team = new System.Windows.Forms.Button();
            this.search_dept = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.dgvDeptEmployees = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeptRename = new System.Windows.Forms.Button();
            this.txtDeptRename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddTeam = new System.Windows.Forms.Button();
            this.NewTeamName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.SearchTeam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchDept = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddDept = new System.Windows.Forms.Button();
            this.NewDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabEmployee = new System.Windows.Forms.TabPage();
            this.btnRemoveChatBlock = new System.Windows.Forms.Button();
            this.dgvBlockedEmployees = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.btnAddChatBlock = new System.Windows.Forms.Button();
            this.cmbBlockedEmployee = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAddHiddenEmployee = new System.Windows.Forms.Button();
            this.cmbHiddenEmployee = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnRemoveHiddenEmployee = new System.Windows.Forms.Button();
            this.dgvHiddenEmployees = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.btnRemoveHiddenDept = new System.Windows.Forms.Button();
            this.dgvHiddenDepts = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddHiddenDept = new System.Windows.Forms.Button();
            this.cmbHiddenDept = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblBaseEmployee = new System.Windows.Forms.Label();
            this.btnSearchLoginLog = new System.Windows.Forms.Button();
            this.btnSearchMessages = new System.Windows.Forms.Button();
            this.txtMessageKeyword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtLogTo = new System.Windows.Forms.DateTimePicker();
            this.dtLogFrom = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.btnChangeTeam = new System.Windows.Forms.Button();
            this.cmbNewTeam = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbNewDept = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFilterDept = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTeamRename = new System.Windows.Forms.Button();
            this.txtTeamRename = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.tabEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockedEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenDepts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "관리자　계정";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(191, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "로그아웃";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDepartment);
            this.tabControl1.Controls.Add(this.tabEmployee);
            this.tabControl1.Location = new System.Drawing.Point(29, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1214, 472);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDepartment
            // 
            this.tabDepartment.Controls.Add(this.btnTeamRename);
            this.tabDepartment.Controls.Add(this.txtTeamRename);
            this.tabDepartment.Controls.Add(this.label23);
            this.tabDepartment.Controls.Add(this.EmployeesDelete);
            this.tabDepartment.Controls.Add(this.TeamsDelete);
            this.tabDepartment.Controls.Add(this.search_team);
            this.tabDepartment.Controls.Add(this.search_dept);
            this.tabDepartment.Controls.Add(this.Delete);
            this.tabDepartment.Controls.Add(this.dgvDeptEmployees);
            this.tabDepartment.Controls.Add(this.label9);
            this.tabDepartment.Controls.Add(this.btnDeptRename);
            this.tabDepartment.Controls.Add(this.txtDeptRename);
            this.tabDepartment.Controls.Add(this.label8);
            this.tabDepartment.Controls.Add(this.AddTeam);
            this.tabDepartment.Controls.Add(this.NewTeamName);
            this.tabDepartment.Controls.Add(this.label7);
            this.tabDepartment.Controls.Add(this.label6);
            this.tabDepartment.Controls.Add(this.dgvTeams);
            this.tabDepartment.Controls.Add(this.label5);
            this.tabDepartment.Controls.Add(this.dgvDepartments);
            this.tabDepartment.Controls.Add(this.SearchTeam);
            this.tabDepartment.Controls.Add(this.label4);
            this.tabDepartment.Controls.Add(this.SearchDept);
            this.tabDepartment.Controls.Add(this.label3);
            this.tabDepartment.Controls.Add(this.AddDept);
            this.tabDepartment.Controls.Add(this.NewDeptName);
            this.tabDepartment.Controls.Add(this.label2);
            this.tabDepartment.Location = new System.Drawing.Point(4, 22);
            this.tabDepartment.Name = "tabDepartment";
            this.tabDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartment.Size = new System.Drawing.Size(1206, 446);
            this.tabDepartment.TabIndex = 0;
            this.tabDepartment.Text = "부서 관리";
            this.tabDepartment.UseVisualStyleBackColor = true;
            // 
            // EmployeesDelete
            // 
            this.EmployeesDelete.BackColor = System.Drawing.Color.IndianRed;
            this.EmployeesDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EmployeesDelete.Location = new System.Drawing.Point(948, 143);
            this.EmployeesDelete.Name = "EmployeesDelete";
            this.EmployeesDelete.Size = new System.Drawing.Size(79, 23);
            this.EmployeesDelete.TabIndex = 27;
            this.EmployeesDelete.Text = "삭제하기";
            this.EmployeesDelete.UseVisualStyleBackColor = false;
            this.EmployeesDelete.Click += new System.EventHandler(this.EmployeesDelete_Click);
            // 
            // TeamsDelete
            // 
            this.TeamsDelete.BackColor = System.Drawing.Color.IndianRed;
            this.TeamsDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TeamsDelete.Location = new System.Drawing.Point(538, 143);
            this.TeamsDelete.Name = "TeamsDelete";
            this.TeamsDelete.Size = new System.Drawing.Size(79, 23);
            this.TeamsDelete.TabIndex = 26;
            this.TeamsDelete.Text = "삭제하기";
            this.TeamsDelete.UseVisualStyleBackColor = false;
            this.TeamsDelete.Click += new System.EventHandler(this.TeamsDelete_Click);
            // 
            // search_team
            // 
            this.search_team.BackColor = System.Drawing.Color.DimGray;
            this.search_team.ForeColor = System.Drawing.SystemColors.Control;
            this.search_team.Location = new System.Drawing.Point(559, 109);
            this.search_team.Name = "search_team";
            this.search_team.Size = new System.Drawing.Size(79, 23);
            this.search_team.TabIndex = 25;
            this.search_team.Text = "검색";
            this.search_team.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.search_team.UseVisualStyleBackColor = false;
            this.search_team.Click += new System.EventHandler(this.search_team_Click);
            // 
            // search_dept
            // 
            this.search_dept.BackColor = System.Drawing.Color.DimGray;
            this.search_dept.ForeColor = System.Drawing.SystemColors.Control;
            this.search_dept.Location = new System.Drawing.Point(331, 107);
            this.search_dept.Name = "search_dept";
            this.search_dept.Size = new System.Drawing.Size(79, 23);
            this.search_dept.TabIndex = 24;
            this.search_dept.Text = "검색";
            this.search_dept.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.search_dept.UseVisualStyleBackColor = false;
            this.search_dept.Click += new System.EventHandler(this.search_dept_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.IndianRed;
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Delete.Location = new System.Drawing.Point(308, 143);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(79, 23);
            this.Delete.TabIndex = 23;
            this.Delete.Text = "삭제하기";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // dgvDeptEmployees
            // 
            this.dgvDeptEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptEmployees.Location = new System.Drawing.Point(652, 170);
            this.dgvDeptEmployees.Name = "dgvDeptEmployees";
            this.dgvDeptEmployees.RowTemplate.Height = 23;
            this.dgvDeptEmployees.Size = new System.Drawing.Size(375, 249);
            this.dgvDeptEmployees.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(650, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "부서 내 직원 목록";
            // 
            // btnDeptRename
            // 
            this.btnDeptRename.BackColor = System.Drawing.Color.DimGray;
            this.btnDeptRename.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeptRename.Location = new System.Drawing.Point(948, 58);
            this.btnDeptRename.Name = "btnDeptRename";
            this.btnDeptRename.Size = new System.Drawing.Size(79, 23);
            this.btnDeptRename.TabIndex = 20;
            this.btnDeptRename.Text = "변경";
            this.btnDeptRename.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeptRename.UseVisualStyleBackColor = false;
            this.btnDeptRename.Click += new System.EventHandler(this.btnDeptRename_Click);
            // 
            // txtDeptRename
            // 
            this.txtDeptRename.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtDeptRename.Location = new System.Drawing.Point(772, 58);
            this.txtDeptRename.Name = "txtDeptRename";
            this.txtDeptRename.Size = new System.Drawing.Size(155, 21);
            this.txtDeptRename.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(648, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "부서 이름 변경하기";
            // 
            // AddTeam
            // 
            this.AddTeam.BackColor = System.Drawing.Color.DimGray;
            this.AddTeam.ForeColor = System.Drawing.SystemColors.Control;
            this.AddTeam.Location = new System.Drawing.Point(559, 54);
            this.AddTeam.Name = "AddTeam";
            this.AddTeam.Size = new System.Drawing.Size(79, 23);
            this.AddTeam.TabIndex = 17;
            this.AddTeam.Text = "추가";
            this.AddTeam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddTeam.UseVisualStyleBackColor = false;
            this.AddTeam.Click += new System.EventHandler(this.AddTeam_Click);
            // 
            // NewTeamName
            // 
            this.NewTeamName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.NewTeamName.Location = new System.Drawing.Point(418, 56);
            this.NewTeamName.Name = "NewTeamName";
            this.NewTeamName.Size = new System.Drawing.Size(134, 21);
            this.NewTeamName.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "새 팀 추가하기";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "부서 내 팀 목록";
            // 
            // dgvTeams
            // 
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Location = new System.Drawing.Point(418, 170);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.RowTemplate.Height = 23;
            this.dgvTeams.Size = new System.Drawing.Size(199, 249);
            this.dgvTeams.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "부서 목록";
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Location = new System.Drawing.Point(192, 170);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowTemplate.Height = 23;
            this.dgvDepartments.Size = new System.Drawing.Size(195, 249);
            this.dgvDepartments.TabIndex = 11;
            this.dgvDepartments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellContentClick);
            // 
            // SearchTeam
            // 
            this.SearchTeam.BackColor = System.Drawing.SystemColors.MenuBar;
            this.SearchTeam.Location = new System.Drawing.Point(418, 109);
            this.SearchTeam.Name = "SearchTeam";
            this.SearchTeam.Size = new System.Drawing.Size(134, 21);
            this.SearchTeam.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "팀 검색";
            // 
            // SearchDept
            // 
            this.SearchDept.BackColor = System.Drawing.SystemColors.MenuBar;
            this.SearchDept.Location = new System.Drawing.Point(190, 107);
            this.SearchDept.Name = "SearchDept";
            this.SearchDept.Size = new System.Drawing.Size(135, 21);
            this.SearchDept.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "부서 검색";
            // 
            // AddDept
            // 
            this.AddDept.BackColor = System.Drawing.Color.DimGray;
            this.AddDept.ForeColor = System.Drawing.SystemColors.Control;
            this.AddDept.Location = new System.Drawing.Point(332, 54);
            this.AddDept.Name = "AddDept";
            this.AddDept.Size = new System.Drawing.Size(79, 23);
            this.AddDept.TabIndex = 6;
            this.AddDept.Text = "추가";
            this.AddDept.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddDept.UseVisualStyleBackColor = false;
            this.AddDept.Click += new System.EventHandler(this.AddDept_Click);
            // 
            // NewDeptName
            // 
            this.NewDeptName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.NewDeptName.Location = new System.Drawing.Point(191, 56);
            this.NewDeptName.Name = "NewDeptName";
            this.NewDeptName.Size = new System.Drawing.Size(134, 21);
            this.NewDeptName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "새 부서 추가하기";
            // 
            // tabEmployee
            // 
            this.tabEmployee.Controls.Add(this.btnRemoveChatBlock);
            this.tabEmployee.Controls.Add(this.dgvBlockedEmployees);
            this.tabEmployee.Controls.Add(this.label22);
            this.tabEmployee.Controls.Add(this.btnAddChatBlock);
            this.tabEmployee.Controls.Add(this.cmbBlockedEmployee);
            this.tabEmployee.Controls.Add(this.label21);
            this.tabEmployee.Controls.Add(this.btnAddHiddenEmployee);
            this.tabEmployee.Controls.Add(this.cmbHiddenEmployee);
            this.tabEmployee.Controls.Add(this.label20);
            this.tabEmployee.Controls.Add(this.btnRemoveHiddenEmployee);
            this.tabEmployee.Controls.Add(this.dgvHiddenEmployees);
            this.tabEmployee.Controls.Add(this.label19);
            this.tabEmployee.Controls.Add(this.btnRemoveHiddenDept);
            this.tabEmployee.Controls.Add(this.dgvHiddenDepts);
            this.tabEmployee.Controls.Add(this.label18);
            this.tabEmployee.Controls.Add(this.btnAddHiddenDept);
            this.tabEmployee.Controls.Add(this.cmbHiddenDept);
            this.tabEmployee.Controls.Add(this.label17);
            this.tabEmployee.Controls.Add(this.lblBaseEmployee);
            this.tabEmployee.Controls.Add(this.btnSearchLoginLog);
            this.tabEmployee.Controls.Add(this.btnSearchMessages);
            this.tabEmployee.Controls.Add(this.txtMessageKeyword);
            this.tabEmployee.Controls.Add(this.label16);
            this.tabEmployee.Controls.Add(this.dtLogTo);
            this.tabEmployee.Controls.Add(this.dtLogFrom);
            this.tabEmployee.Controls.Add(this.label15);
            this.tabEmployee.Controls.Add(this.dgvLogs);
            this.tabEmployee.Controls.Add(this.btnChangeTeam);
            this.tabEmployee.Controls.Add(this.cmbNewTeam);
            this.tabEmployee.Controls.Add(this.label14);
            this.tabEmployee.Controls.Add(this.cmbNewDept);
            this.tabEmployee.Controls.Add(this.label13);
            this.tabEmployee.Controls.Add(this.dgvEmployees);
            this.tabEmployee.Controls.Add(this.label12);
            this.tabEmployee.Controls.Add(this.btnSearchEmployee);
            this.tabEmployee.Controls.Add(this.txtSearchEmployee);
            this.tabEmployee.Controls.Add(this.label11);
            this.tabEmployee.Controls.Add(this.cmbFilterDept);
            this.tabEmployee.Controls.Add(this.label10);
            this.tabEmployee.Location = new System.Drawing.Point(4, 22);
            this.tabEmployee.Name = "tabEmployee";
            this.tabEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployee.Size = new System.Drawing.Size(1206, 446);
            this.tabEmployee.TabIndex = 1;
            this.tabEmployee.Text = "직원 관리";
            this.tabEmployee.UseVisualStyleBackColor = true;
            this.tabEmployee.Click += new System.EventHandler(this.tabEmployee_Click);
            // 
            // btnRemoveChatBlock
            // 
            this.btnRemoveChatBlock.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveChatBlock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveChatBlock.Location = new System.Drawing.Point(1107, 377);
            this.btnRemoveChatBlock.Name = "btnRemoveChatBlock";
            this.btnRemoveChatBlock.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveChatBlock.TabIndex = 42;
            this.btnRemoveChatBlock.Text = "해제";
            this.btnRemoveChatBlock.UseVisualStyleBackColor = false;
            this.btnRemoveChatBlock.Click += new System.EventHandler(this.btnRemoveChatBlock_Click);
            // 
            // dgvBlockedEmployees
            // 
            this.dgvBlockedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlockedEmployees.Location = new System.Drawing.Point(871, 206);
            this.dgvBlockedEmployees.Name = "dgvBlockedEmployees";
            this.dgvBlockedEmployees.RowTemplate.Height = 23;
            this.dgvBlockedEmployees.Size = new System.Drawing.Size(210, 194);
            this.dgvBlockedEmployees.TabIndex = 41;
            this.dgvBlockedEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(869, 188);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 12);
            this.label22.TabIndex = 40;
            this.label22.Text = "대화 불가능한 직원";
            // 
            // btnAddChatBlock
            // 
            this.btnAddChatBlock.BackColor = System.Drawing.Color.DimGray;
            this.btnAddChatBlock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddChatBlock.Location = new System.Drawing.Point(1107, 108);
            this.btnAddChatBlock.Name = "btnAddChatBlock";
            this.btnAddChatBlock.Size = new System.Drawing.Size(75, 23);
            this.btnAddChatBlock.TabIndex = 39;
            this.btnAddChatBlock.Text = "추가";
            this.btnAddChatBlock.UseVisualStyleBackColor = false;
            this.btnAddChatBlock.Click += new System.EventHandler(this.btnAddChatBlock_Click);
            // 
            // cmbBlockedEmployee
            // 
            this.cmbBlockedEmployee.FormattingEnabled = true;
            this.cmbBlockedEmployee.Location = new System.Drawing.Point(972, 110);
            this.cmbBlockedEmployee.Name = "cmbBlockedEmployee";
            this.cmbBlockedEmployee.Size = new System.Drawing.Size(121, 20);
            this.cmbBlockedEmployee.TabIndex = 38;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(869, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 12);
            this.label21.TabIndex = 37;
            this.label21.Text = "대화 차단할 직원";
            // 
            // btnAddHiddenEmployee
            // 
            this.btnAddHiddenEmployee.BackColor = System.Drawing.Color.DimGray;
            this.btnAddHiddenEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddHiddenEmployee.Location = new System.Drawing.Point(765, 236);
            this.btnAddHiddenEmployee.Name = "btnAddHiddenEmployee";
            this.btnAddHiddenEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnAddHiddenEmployee.TabIndex = 36;
            this.btnAddHiddenEmployee.Text = "추가";
            this.btnAddHiddenEmployee.UseVisualStyleBackColor = false;
            this.btnAddHiddenEmployee.Click += new System.EventHandler(this.btnAddHiddenEmployee_Click);
            // 
            // cmbHiddenEmployee
            // 
            this.cmbHiddenEmployee.FormattingEnabled = true;
            this.cmbHiddenEmployee.Location = new System.Drawing.Point(629, 236);
            this.cmbHiddenEmployee.Name = "cmbHiddenEmployee";
            this.cmbHiddenEmployee.Size = new System.Drawing.Size(121, 20);
            this.cmbHiddenEmployee.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(538, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 12);
            this.label20.TabIndex = 34;
            this.label20.Text = "비공개 할 직원";
            // 
            // btnRemoveHiddenEmployee
            // 
            this.btnRemoveHiddenEmployee.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveHiddenEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveHiddenEmployee.Location = new System.Drawing.Point(765, 377);
            this.btnRemoveHiddenEmployee.Name = "btnRemoveHiddenEmployee";
            this.btnRemoveHiddenEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveHiddenEmployee.TabIndex = 33;
            this.btnRemoveHiddenEmployee.Text = "삭제";
            this.btnRemoveHiddenEmployee.UseVisualStyleBackColor = false;
            this.btnRemoveHiddenEmployee.Click += new System.EventHandler(this.btnRemoveHiddenEmployee_Click);
            // 
            // dgvHiddenEmployees
            // 
            this.dgvHiddenEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHiddenEmployees.Location = new System.Drawing.Point(541, 279);
            this.dgvHiddenEmployees.Name = "dgvHiddenEmployees";
            this.dgvHiddenEmployees.RowTemplate.Height = 23;
            this.dgvHiddenEmployees.Size = new System.Drawing.Size(210, 121);
            this.dgvHiddenEmployees.TabIndex = 32;
            this.dgvHiddenEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHiddenEmployees_CellContentClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(539, 264);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 12);
            this.label19.TabIndex = 31;
            this.label19.Text = "비공개 된 직원";
            // 
            // btnRemoveHiddenDept
            // 
            this.btnRemoveHiddenDept.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveHiddenDept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveHiddenDept.Location = new System.Drawing.Point(765, 203);
            this.btnRemoveHiddenDept.Name = "btnRemoveHiddenDept";
            this.btnRemoveHiddenDept.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveHiddenDept.TabIndex = 30;
            this.btnRemoveHiddenDept.Text = "삭제";
            this.btnRemoveHiddenDept.UseVisualStyleBackColor = false;
            this.btnRemoveHiddenDept.Click += new System.EventHandler(this.btnRemoveHiddenDept_Click);
            // 
            // dgvHiddenDepts
            // 
            this.dgvHiddenDepts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHiddenDepts.Location = new System.Drawing.Point(541, 120);
            this.dgvHiddenDepts.Name = "dgvHiddenDepts";
            this.dgvHiddenDepts.RowTemplate.Height = 23;
            this.dgvHiddenDepts.Size = new System.Drawing.Size(210, 106);
            this.dgvHiddenDepts.TabIndex = 29;
            this.dgvHiddenDepts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHiddenDepts_CellContentClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(538, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 12);
            this.label18.TabIndex = 28;
            this.label18.Text = "비공개 된 부서";
            // 
            // btnAddHiddenDept
            // 
            this.btnAddHiddenDept.BackColor = System.Drawing.Color.DimGray;
            this.btnAddHiddenDept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddHiddenDept.Location = new System.Drawing.Point(765, 73);
            this.btnAddHiddenDept.Name = "btnAddHiddenDept";
            this.btnAddHiddenDept.Size = new System.Drawing.Size(75, 23);
            this.btnAddHiddenDept.TabIndex = 27;
            this.btnAddHiddenDept.Text = "추가";
            this.btnAddHiddenDept.UseVisualStyleBackColor = false;
            this.btnAddHiddenDept.Click += new System.EventHandler(this.btnAddHiddenDept_Click);
            // 
            // cmbHiddenDept
            // 
            this.cmbHiddenDept.FormattingEnabled = true;
            this.cmbHiddenDept.Location = new System.Drawing.Point(629, 75);
            this.cmbHiddenDept.Name = "cmbHiddenDept";
            this.cmbHiddenDept.Size = new System.Drawing.Size(121, 20);
            this.cmbHiddenDept.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(538, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "비공개 할 부서";
            // 
            // lblBaseEmployee
            // 
            this.lblBaseEmployee.AutoSize = true;
            this.lblBaseEmployee.Location = new System.Drawing.Point(869, 33);
            this.lblBaseEmployee.Name = "lblBaseEmployee";
            this.lblBaseEmployee.Size = new System.Drawing.Size(113, 12);
            this.lblBaseEmployee.TabIndex = 24;
            this.lblBaseEmployee.Text = "현재 선택된 직원： ";
            // 
            // btnSearchLoginLog
            // 
            this.btnSearchLoginLog.Location = new System.Drawing.Point(397, 177);
            this.btnSearchLoginLog.Name = "btnSearchLoginLog";
            this.btnSearchLoginLog.Size = new System.Drawing.Size(114, 23);
            this.btnSearchLoginLog.TabIndex = 23;
            this.btnSearchLoginLog.Text = "로그인 기록 검색";
            this.btnSearchLoginLog.UseVisualStyleBackColor = true;
            this.btnSearchLoginLog.Click += new System.EventHandler(this.btnSearchLoginLog_Click);
            // 
            // btnSearchMessages
            // 
            this.btnSearchMessages.Location = new System.Drawing.Point(282, 177);
            this.btnSearchMessages.Name = "btnSearchMessages";
            this.btnSearchMessages.Size = new System.Drawing.Size(109, 23);
            this.btnSearchMessages.TabIndex = 22;
            this.btnSearchMessages.Text = "대화 내용 검색";
            this.btnSearchMessages.UseVisualStyleBackColor = true;
            this.btnSearchMessages.Click += new System.EventHandler(this.btnSearchMessages_Click);
            // 
            // txtMessageKeyword
            // 
            this.txtMessageKeyword.Location = new System.Drawing.Point(346, 146);
            this.txtMessageKeyword.Name = "txtMessageKeyword";
            this.txtMessageKeyword.Size = new System.Drawing.Size(146, 21);
            this.txtMessageKeyword.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(290, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "키워드";
            // 
            // dtLogTo
            // 
            this.dtLogTo.Location = new System.Drawing.Point(284, 109);
            this.dtLogTo.Name = "dtLogTo";
            this.dtLogTo.Size = new System.Drawing.Size(200, 21);
            this.dtLogTo.TabIndex = 19;
            // 
            // dtLogFrom
            // 
            this.dtLogFrom.Location = new System.Drawing.Point(284, 75);
            this.dtLogFrom.Name = "dtLogFrom";
            this.dtLogFrom.Size = new System.Drawing.Size(200, 21);
            this.dtLogFrom.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(282, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "기간";
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(282, 206);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowTemplate.Height = 23;
            this.dgvLogs.Size = new System.Drawing.Size(229, 194);
            this.dgvLogs.TabIndex = 16;
            // 
            // btnChangeTeam
            // 
            this.btnChangeTeam.BackColor = System.Drawing.Color.DimGray;
            this.btnChangeTeam.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChangeTeam.Location = new System.Drawing.Point(776, 28);
            this.btnChangeTeam.Name = "btnChangeTeam";
            this.btnChangeTeam.Size = new System.Drawing.Size(75, 23);
            this.btnChangeTeam.TabIndex = 15;
            this.btnChangeTeam.Text = "변경";
            this.btnChangeTeam.UseVisualStyleBackColor = false;
            this.btnChangeTeam.Click += new System.EventHandler(this.btnChangeTeam_Click);
            // 
            // cmbNewTeam
            // 
            this.cmbNewTeam.FormattingEnabled = true;
            this.cmbNewTeam.Location = new System.Drawing.Point(640, 30);
            this.cmbNewTeam.Name = "cmbNewTeam";
            this.cmbNewTeam.Size = new System.Drawing.Size(121, 20);
            this.cmbNewTeam.TabIndex = 14;
            this.cmbNewTeam.SelectedIndexChanged += new System.EventHandler(this.cmbNewTeam_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(537, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "소속 팀 변경하기";
            // 
            // cmbNewDept
            // 
            this.cmbNewDept.FormattingEnabled = true;
            this.cmbNewDept.Location = new System.Drawing.Point(395, 30);
            this.cmbNewDept.Name = "cmbNewDept";
            this.cmbNewDept.Size = new System.Drawing.Size(121, 20);
            this.cmbNewDept.TabIndex = 12;
            this.cmbNewDept.SelectedIndexChanged += new System.EventHandler(this.cmbNewDept_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(280, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "소속 부서 변경하기";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(33, 150);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowTemplate.Height = 23;
            this.dgvEmployees.Size = new System.Drawing.Size(219, 250);
            this.dgvEmployees.TabIndex = 10;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "직원 목록";
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.BackColor = System.Drawing.Color.DimGray;
            this.btnSearchEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearchEmployee.Location = new System.Drawing.Point(177, 82);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEmployee.TabIndex = 8;
            this.btnSearchEmployee.Text = "검색";
            this.btnSearchEmployee.UseVisualStyleBackColor = false;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(33, 82);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(121, 21);
            this.txtSearchEmployee.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "직원 이름 검색";
            // 
            // cmbFilterDept
            // 
            this.cmbFilterDept.FormattingEnabled = true;
            this.cmbFilterDept.Location = new System.Drawing.Point(33, 30);
            this.cmbFilterDept.Name = "cmbFilterDept";
            this.cmbFilterDept.Size = new System.Drawing.Size(121, 20);
            this.cmbFilterDept.TabIndex = 5;
            this.cmbFilterDept.SelectedIndexChanged += new System.EventHandler(this.cmbFilterDept_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "부서별 검색";
            // 
            // btnTeamRename
            // 
            this.btnTeamRename.BackColor = System.Drawing.Color.DimGray;
            this.btnTeamRename.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTeamRename.Location = new System.Drawing.Point(948, 109);
            this.btnTeamRename.Name = "btnTeamRename";
            this.btnTeamRename.Size = new System.Drawing.Size(79, 23);
            this.btnTeamRename.TabIndex = 30;
            this.btnTeamRename.Text = "변경";
            this.btnTeamRename.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTeamRename.UseVisualStyleBackColor = false;
            this.btnTeamRename.Click += new System.EventHandler(this.btnTeamRename_Click);
            // 
            // txtTeamRename
            // 
            this.txtTeamRename.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTeamRename.Location = new System.Drawing.Point(772, 109);
            this.txtTeamRename.Name = "txtTeamRename";
            this.txtTeamRename.Size = new System.Drawing.Size(155, 21);
            this.txtTeamRename.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(648, 112);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "팀 이름 변경하기";
            // 
            // AdminShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Name = "AdminShellForm";
            this.Text = "AdminShellForm";
            this.tabControl1.ResumeLayout(false);
            this.tabDepartment.ResumeLayout(false);
            this.tabDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.tabEmployee.ResumeLayout(false);
            this.tabEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockedEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiddenDepts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDepartment;
        private System.Windows.Forms.TabPage tabEmployee;
        private System.Windows.Forms.TextBox NewDeptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SearchDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddDept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Button AddTeam;
        private System.Windows.Forms.TextBox NewTeamName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeptRename;
        private System.Windows.Forms.TextBox txtDeptRename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDeptEmployees;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbFilterDept;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.ComboBox cmbNewDept;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbNewTeam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnChangeTeam;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.DateTimePicker dtLogTo;
        private System.Windows.Forms.DateTimePicker dtLogFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSearchLoginLog;
        private System.Windows.Forms.Button btnSearchMessages;
        private System.Windows.Forms.TextBox txtMessageKeyword;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblBaseEmployee;
        private System.Windows.Forms.Button btnRemoveHiddenDept;
        private System.Windows.Forms.DataGridView dgvHiddenDepts;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAddHiddenDept;
        private System.Windows.Forms.ComboBox cmbHiddenDept;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnRemoveHiddenEmployee;
        private System.Windows.Forms.DataGridView dgvHiddenEmployees;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnAddHiddenEmployee;
        private System.Windows.Forms.ComboBox cmbHiddenEmployee;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbBlockedEmployee;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnRemoveChatBlock;
        private System.Windows.Forms.DataGridView dgvBlockedEmployees;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnAddChatBlock;
        private System.Windows.Forms.Button search_team;
        private System.Windows.Forms.Button search_dept;
        private System.Windows.Forms.Button EmployeesDelete;
        private System.Windows.Forms.Button TeamsDelete;
        private System.Windows.Forms.Button btnTeamRename;
        private System.Windows.Forms.TextBox txtTeamRename;
        private System.Windows.Forms.Label label23;
    }
}