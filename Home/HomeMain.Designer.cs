using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ChattingAppTeam6.Home
{
    partial class HomeMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MemberSearch = new System.Windows.Forms.TextBox();
            this.UserPIC = new System.Windows.Forms.PictureBox();
            this.UserNicknameLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.settingLabel = new System.Windows.Forms.Label();
            this.LogoutLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TeamMemberTreeView = new System.Windows.Forms.TreeView();
            this.FAVMemberList = new System.Windows.Forms.ListView();
            this.flpChats = new System.Windows.Forms.FlowLayoutPanel();
            this.favoriteInsertButton = new System.Windows.Forms.Button();
            this.favoriteDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserPIC)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberSearch
            // 
            this.MemberSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.MemberSearch.Location = new System.Drawing.Point(26, 87);
            this.MemberSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MemberSearch.Name = "MemberSearch";
            this.MemberSearch.Size = new System.Drawing.Size(134, 21);
            this.MemberSearch.TabIndex = 0;
            // 
            // UserPIC
            // 
            this.UserPIC.Location = new System.Drawing.Point(18, 15);
            this.UserPIC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserPIC.Name = "UserPIC";
            this.UserPIC.Size = new System.Drawing.Size(48, 44);
            this.UserPIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPIC.TabIndex = 1;
            this.UserPIC.TabStop = false;
            this.UserPIC.Click += new System.EventHandler(this.UserPIC_Click);
            // 
            // UserNicknameLabel
            // 
            this.UserNicknameLabel.AutoSize = true;
            this.UserNicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UserNicknameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.UserNicknameLabel.Location = new System.Drawing.Point(74, 18);
            this.UserNicknameLabel.Name = "UserNicknameLabel";
            this.UserNicknameLabel.Size = new System.Drawing.Size(98, 19);
            this.UserNicknameLabel.TabIndex = 2;
            this.UserNicknameLabel.Text = "여기가 닉네임";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UserNameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.UserNameLabel.Location = new System.Drawing.Point(74, 40);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(71, 15);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "여기가 본명";
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.settingLabel.Location = new System.Drawing.Point(221, 30);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(31, 15);
            this.settingLabel.TabIndex = 4;
            this.settingLabel.Text = "설정";
            this.settingLabel.Click += new System.EventHandler(this.settingLabel_Click);
            // 
            // LogoutLabel
            // 
            this.LogoutLabel.AutoSize = true;
            this.LogoutLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LogoutLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LogoutLabel.Location = new System.Drawing.Point(258, 30);
            this.LogoutLabel.Name = "LogoutLabel";
            this.LogoutLabel.Size = new System.Drawing.Size(55, 15);
            this.LogoutLabel.TabIndex = 5;
            this.LogoutLabel.Text = "로그아웃";
            this.LogoutLabel.Click += new System.EventHandler(this.LogoutLabel_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(23, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "직원 검색";
            // 
            // TeamMemberTreeView
            // 
            this.TeamMemberTreeView.BackColor = System.Drawing.Color.Gainsboro;
            this.TeamMemberTreeView.LineColor = System.Drawing.Color.Gainsboro;
            this.TeamMemberTreeView.Location = new System.Drawing.Point(26, 118);
            this.TeamMemberTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TeamMemberTreeView.Name = "TeamMemberTreeView";
            this.TeamMemberTreeView.Size = new System.Drawing.Size(134, 225);
            this.TeamMemberTreeView.TabIndex = 7;
            this.TeamMemberTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TeamMemberTreeView_AfterSelect_1);
            // 
            // FAVMemberList
            // 
            this.FAVMemberList.BackColor = System.Drawing.Color.Gainsboro;
            this.FAVMemberList.HideSelection = false;
            this.FAVMemberList.Location = new System.Drawing.Point(26, 402);
            this.FAVMemberList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FAVMemberList.Name = "FAVMemberList";
            this.FAVMemberList.Size = new System.Drawing.Size(293, 90);
            this.FAVMemberList.TabIndex = 8;
            this.FAVMemberList.UseCompatibleStateImageBehavior = false;
            this.FAVMemberList.SelectedIndexChanged += new System.EventHandler(this.FAVMemberList_SelectedIndexChanged);
            // 
            // flpChats
            // 
            this.flpChats.BackColor = System.Drawing.Color.White;
            this.flpChats.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpChats.Location = new System.Drawing.Point(352, 0);
            this.flpChats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpChats.Name = "flpChats";
            this.flpChats.Size = new System.Drawing.Size(550, 540);
            this.flpChats.TabIndex = 9;
            // 
            // favoriteInsertButton
            // 
            this.favoriteInsertButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.favoriteInsertButton.Location = new System.Drawing.Point(26, 345);
            this.favoriteInsertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.favoriteInsertButton.Name = "favoriteInsertButton";
            this.favoriteInsertButton.Size = new System.Drawing.Size(103, 26);
            this.favoriteInsertButton.TabIndex = 14;
            this.favoriteInsertButton.Text = "즐겨찾기 추가";
            this.favoriteInsertButton.UseVisualStyleBackColor = true;
            this.favoriteInsertButton.Click += new System.EventHandler(this.favoriteInsertButton_Click_1);
            // 
            // favoriteDeleteButton
            // 
            this.favoriteDeleteButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.favoriteDeleteButton.Location = new System.Drawing.Point(26, 374);
            this.favoriteDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.favoriteDeleteButton.Name = "favoriteDeleteButton";
            this.favoriteDeleteButton.Size = new System.Drawing.Size(103, 26);
            this.favoriteDeleteButton.TabIndex = 15;
            this.favoriteDeleteButton.Text = "즐겨찾기 삭제";
            this.favoriteDeleteButton.UseVisualStyleBackColor = true;
            this.favoriteDeleteButton.Click += new System.EventHandler(this.favoriteDeleteButton_Click_1);
            // 
            // HomeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(902, 540);
            this.Controls.Add(this.favoriteDeleteButton);
            this.Controls.Add(this.favoriteInsertButton);
            this.Controls.Add(this.flpChats);
            this.Controls.Add(this.FAVMemberList);
            this.Controls.Add(this.TeamMemberTreeView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LogoutLabel);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserNicknameLabel);
            this.Controls.Add(this.UserPIC);
            this.Controls.Add(this.MemberSearch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomeMain_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.UserPIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox MemberSearch;
        private PictureBox UserPIC;
        private Label UserNicknameLabel;
        private Label UserNameLabel;
        private Label settingLabel;
        private Label LogoutLabel;
        private Label label5;
        private TreeView TeamMemberTreeView;
        private ListView FAVMemberList;
        private FlowLayoutPanel flpChats;
        private PictureBox pictureBox2;
        private Label label7;
        private Label label8;
        private Panel panel2;
        private Label label9;
        private Button favoriteInsertButton;
        private Button favoriteDeleteButton;
    }
}