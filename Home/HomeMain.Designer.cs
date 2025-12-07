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
            this.IDText = new System.Windows.Forms.TextBox();
            this.PWText = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.favoriteInsertButton = new System.Windows.Forms.Button();
            this.favoriteDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserPIC)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberSearch
            // 
            this.MemberSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.MemberSearch.Location = new System.Drawing.Point(30, 109);
            this.MemberSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MemberSearch.Name = "MemberSearch";
            this.MemberSearch.Size = new System.Drawing.Size(152, 25);
            this.MemberSearch.TabIndex = 0;
            // 
            // UserPIC
            // 
            this.UserPIC.Location = new System.Drawing.Point(20, 19);
            this.UserPIC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserPIC.Name = "UserPIC";
            this.UserPIC.Size = new System.Drawing.Size(55, 55);
            this.UserPIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPIC.TabIndex = 1;
            this.UserPIC.TabStop = false;
            // 
            // UserNicknameLabel
            // 
            this.UserNicknameLabel.AutoSize = true;
            this.UserNicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UserNicknameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.UserNicknameLabel.Location = new System.Drawing.Point(84, 23);
            this.UserNicknameLabel.Name = "UserNicknameLabel";
            this.UserNicknameLabel.Size = new System.Drawing.Size(118, 23);
            this.UserNicknameLabel.TabIndex = 2;
            this.UserNicknameLabel.Text = "여기가 닉네임";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UserNameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.UserNameLabel.Location = new System.Drawing.Point(84, 50);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(89, 20);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "여기가 본명";
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.settingLabel.Location = new System.Drawing.Point(253, 37);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(39, 20);
            this.settingLabel.TabIndex = 4;
            this.settingLabel.Text = "설정";
            this.settingLabel.Click += new System.EventHandler(this.settingLabel_Click);
            // 
            // LogoutLabel
            // 
            this.LogoutLabel.AutoSize = true;
            this.LogoutLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LogoutLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LogoutLabel.Location = new System.Drawing.Point(295, 37);
            this.LogoutLabel.Name = "LogoutLabel";
            this.LogoutLabel.Size = new System.Drawing.Size(69, 20);
            this.LogoutLabel.TabIndex = 5;
            this.LogoutLabel.Text = "로그아웃";
            this.LogoutLabel.Click += new System.EventHandler(this.LogoutLabel_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(26, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "직원 검색";
            // 
            // TeamMemberTreeView
            // 
            this.TeamMemberTreeView.BackColor = System.Drawing.Color.Gainsboro;
            this.TeamMemberTreeView.LineColor = System.Drawing.Color.Gainsboro;
            this.TeamMemberTreeView.Location = new System.Drawing.Point(30, 147);
            this.TeamMemberTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TeamMemberTreeView.Name = "TeamMemberTreeView";
            this.TeamMemberTreeView.Size = new System.Drawing.Size(152, 280);
            this.TeamMemberTreeView.TabIndex = 7;
            this.TeamMemberTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TeamMemberTreeView_AfterSelect_1);
            // 
            // FAVMemberList
            // 
            this.FAVMemberList.BackColor = System.Drawing.Color.Gainsboro;
            this.FAVMemberList.HideSelection = false;
            this.FAVMemberList.Location = new System.Drawing.Point(30, 503);
            this.FAVMemberList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FAVMemberList.Name = "FAVMemberList";
            this.FAVMemberList.Size = new System.Drawing.Size(334, 111);
            this.FAVMemberList.TabIndex = 8;
            this.FAVMemberList.UseCompatibleStateImageBehavior = false;
            this.FAVMemberList.SelectedIndexChanged += new System.EventHandler(this.FAVMemberList_SelectedIndexChanged);
            // 
            // flpChats
            // 
            this.flpChats.BackColor = System.Drawing.Color.White;
            this.flpChats.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpChats.Location = new System.Drawing.Point(403, 0);
            this.flpChats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpChats.Name = "flpChats";
            this.flpChats.Size = new System.Drawing.Size(628, 675);
            this.flpChats.TabIndex = 9;
            // 
            // IDText
            // 
            this.IDText.Location = new System.Drawing.Point(208, 86);
            this.IDText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDText.Name = "IDText";
            this.IDText.Size = new System.Drawing.Size(112, 25);
            this.IDText.TabIndex = 11;
            // 
            // PWText
            // 
            this.PWText.Location = new System.Drawing.Point(208, 115);
            this.PWText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PWText.Name = "PWText";
            this.PWText.PasswordChar = '*';
            this.PWText.Size = new System.Drawing.Size(112, 25);
            this.PWText.TabIndex = 12;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(208, 144);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(84, 22);
            this.LoginButton.TabIndex = 13;
            this.LoginButton.Text = "button1";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click_1);
            // 
            // favoriteInsertButton
            // 
            this.favoriteInsertButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.favoriteInsertButton.Location = new System.Drawing.Point(30, 431);
            this.favoriteInsertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.favoriteInsertButton.Name = "favoriteInsertButton";
            this.favoriteInsertButton.Size = new System.Drawing.Size(118, 32);
            this.favoriteInsertButton.TabIndex = 14;
            this.favoriteInsertButton.Text = "즐겨찾기 추가";
            this.favoriteInsertButton.UseVisualStyleBackColor = true;
            this.favoriteInsertButton.Click += new System.EventHandler(this.favoriteInsertButton_Click_1);
            // 
            // favoriteDeleteButton
            // 
            this.favoriteDeleteButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.favoriteDeleteButton.Location = new System.Drawing.Point(30, 467);
            this.favoriteDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.favoriteDeleteButton.Name = "favoriteDeleteButton";
            this.favoriteDeleteButton.Size = new System.Drawing.Size(118, 32);
            this.favoriteDeleteButton.TabIndex = 15;
            this.favoriteDeleteButton.Text = "즐겨찾기 삭제";
            this.favoriteDeleteButton.UseVisualStyleBackColor = true;
            this.favoriteDeleteButton.Click += new System.EventHandler(this.favoriteDeleteButton_Click_1);
            // 
            // HomeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1031, 675);
            this.Controls.Add(this.favoriteDeleteButton);
            this.Controls.Add(this.favoriteInsertButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PWText);
            this.Controls.Add(this.IDText);
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
        private TextBox IDText;
        private TextBox PWText;
        private Button LoginButton;
        private Button favoriteInsertButton;
        private Button favoriteDeleteButton;
    }
}
