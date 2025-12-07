using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingAppTeam6.Auth
{
    partial class UpdateUserInfo
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
            this.FindAddrButton = new System.Windows.Forms.Button();
            this.ProfileBox = new System.Windows.Forms.PictureBox();
            this.UpdateImage = new System.Windows.Forms.Label();
            this.ZipcodeBox = new System.Windows.Forms.TextBox();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.NicknameBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.UpdateInfoButton = new System.Windows.Forms.Button();
            this.TeamLabel = new System.Windows.Forms.Label();
            this.PwCheckBox = new System.Windows.Forms.TextBox();
            this.PwCheckLabel = new System.Windows.Forms.Label();
            this.PwBox = new System.Windows.Forms.TextBox();
            this.PwLabel = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TeamBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FindAddrButton
            // 
            this.FindAddrButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FindAddrButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FindAddrButton.Location = new System.Drawing.Point(815, 612);
            this.FindAddrButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FindAddrButton.Name = "FindAddrButton";
            this.FindAddrButton.Size = new System.Drawing.Size(125, 46);
            this.FindAddrButton.TabIndex = 42;
            this.FindAddrButton.Text = "주소찾기";
            this.FindAddrButton.UseVisualStyleBackColor = true;
            this.FindAddrButton.Click += new System.EventHandler(this.FindAddrButton_Click);
            // 
            // ProfileBox
            // 
            this.ProfileBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProfileBox.Image = global::ChattingAppTeam6.Properties.Resources.BasicImage;
            this.ProfileBox.Location = new System.Drawing.Point(845, 178);
            this.ProfileBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileBox.Name = "ProfileBox";
            this.ProfileBox.Size = new System.Drawing.Size(200, 200);
            this.ProfileBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfileBox.TabIndex = 41;
            this.ProfileBox.TabStop = false;
            this.ProfileBox.Click += new System.EventHandler(this.UpdateImage_Click);
            // 
            // UpdateImage
            // 
            this.UpdateImage.AutoSize = true;
            this.UpdateImage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpdateImage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.UpdateImage.Location = new System.Drawing.Point(1087, 353);
            this.UpdateImage.Name = "UpdateImage";
            this.UpdateImage.Size = new System.Drawing.Size(90, 25);
            this.UpdateImage.TabIndex = 40;
            this.UpdateImage.Text = "사진 변경";
            this.UpdateImage.Click += new System.EventHandler(this.UpdateImage_Click);
            // 
            // ZipcodeBox
            // 
            this.ZipcodeBox.BackColor = System.Drawing.SystemColors.Control;
            this.ZipcodeBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZipcodeBox.Location = new System.Drawing.Point(964, 612);
            this.ZipcodeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZipcodeBox.Multiline = true;
            this.ZipcodeBox.Name = "ZipcodeBox";
            this.ZipcodeBox.Size = new System.Drawing.Size(249, 46);
            this.ZipcodeBox.TabIndex = 39;
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.zipCodeLabel.Location = new System.Drawing.Point(961, 583);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(98, 25);
            this.zipCodeLabel.TabIndex = 38;
            this.zipCodeLabel.Text = "* 우편번호";
            // 
            // NicknameBox
            // 
            this.NicknameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NicknameBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NicknameBox.Location = new System.Drawing.Point(748, 514);
            this.NicknameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NicknameBox.Multiline = true;
            this.NicknameBox.Name = "NicknameBox";
            this.NicknameBox.Size = new System.Drawing.Size(465, 46);
            this.NicknameBox.TabIndex = 37;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NameBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NameBox.Location = new System.Drawing.Point(748, 412);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(465, 46);
            this.NameBox.TabIndex = 36;
            // 
            // AddressBox
            // 
            this.AddressBox.BackColor = System.Drawing.SystemColors.Control;
            this.AddressBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddressBox.Location = new System.Drawing.Point(149, 612);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressBox.Multiline = true;
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(650, 46);
            this.AddressBox.TabIndex = 35;
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddrLabel.Location = new System.Drawing.Point(156, 583);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(62, 25);
            this.AddrLabel.TabIndex = 34;
            this.AddrLabel.Text = "* 주소";
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NicknameLabel.Location = new System.Drawing.Point(754, 485);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(48, 25);
            this.NicknameLabel.TabIndex = 33;
            this.NicknameLabel.Text = "별명";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameLabel.Location = new System.Drawing.Point(754, 384);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(62, 25);
            this.nameLabel.TabIndex = 32;
            this.nameLabel.Text = "* 이름";
            // 
            // UpdateInfoButton
            // 
            this.UpdateInfoButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.UpdateInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateInfoButton.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpdateInfoButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpdateInfoButton.Location = new System.Drawing.Point(149, 744);
            this.UpdateInfoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateInfoButton.Name = "UpdateInfoButton";
            this.UpdateInfoButton.Size = new System.Drawing.Size(1064, 61);
            this.UpdateInfoButton.TabIndex = 31;
            this.UpdateInfoButton.Text = "회원정보 변경";
            this.UpdateInfoButton.UseVisualStyleBackColor = false;
            this.UpdateInfoButton.Click += new System.EventHandler(this.UpdateInfoButton_Click);
            // 
            // TeamLabel
            // 
            this.TeamLabel.AutoSize = true;
            this.TeamLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TeamLabel.Location = new System.Drawing.Point(156, 484);
            this.TeamLabel.Name = "TeamLabel";
            this.TeamLabel.Size = new System.Drawing.Size(98, 25);
            this.TeamLabel.TabIndex = 29;
            this.TeamLabel.Text = "* 소속부서";
            // 
            // PwCheckBox
            // 
            this.PwCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.PwCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwCheckBox.Location = new System.Drawing.Point(149, 412);
            this.PwCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PwCheckBox.Multiline = true;
            this.PwCheckBox.Name = "PwCheckBox";
            this.PwCheckBox.PasswordChar = '*';
            this.PwCheckBox.Size = new System.Drawing.Size(457, 46);
            this.PwCheckBox.TabIndex = 28;
            this.PwCheckBox.TextChanged += new System.EventHandler(this.PwCheckBox_TextChanged);
            // 
            // PwCheckLabel
            // 
            this.PwCheckLabel.AutoSize = true;
            this.PwCheckLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwCheckLabel.Location = new System.Drawing.Point(149, 384);
            this.PwCheckLabel.Name = "PwCheckLabel";
            this.PwCheckLabel.Size = new System.Drawing.Size(140, 25);
            this.PwCheckLabel.TabIndex = 27;
            this.PwCheckLabel.Text = "* 비밀번호 확인";
            // 
            // PwBox
            // 
            this.PwBox.BackColor = System.Drawing.SystemColors.Control;
            this.PwBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwBox.Location = new System.Drawing.Point(149, 311);
            this.PwBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PwBox.Multiline = true;
            this.PwBox.Name = "PwBox";
            this.PwBox.PasswordChar = '*';
            this.PwBox.Size = new System.Drawing.Size(457, 46);
            this.PwBox.TabIndex = 25;
            // 
            // PwLabel
            // 
            this.PwLabel.AutoSize = true;
            this.PwLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwLabel.Location = new System.Drawing.Point(156, 282);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(98, 25);
            this.PwLabel.TabIndex = 24;
            this.PwLabel.Text = "* 비밀번호";
            // 
            // IdBox
            // 
            this.IdBox.BackColor = System.Drawing.SystemColors.Control;
            this.IdBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdBox.Location = new System.Drawing.Point(149, 214);
            this.IdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IdBox.Multiline = true;
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(457, 46);
            this.IdBox.TabIndex = 23;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdLabel.Location = new System.Drawing.Point(156, 185);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(80, 25);
            this.IdLabel.TabIndex = 22;
            this.IdLabel.Text = "* 아이디";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.label1.Location = new System.Drawing.Point(529, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "회원정보를 변경하세요";
            // 
            // TeamBox
            // 
            this.TeamBox.BackColor = System.Drawing.SystemColors.Control;
            this.TeamBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TeamBox.Location = new System.Drawing.Point(149, 514);
            this.TeamBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TeamBox.Multiline = true;
            this.TeamBox.Name = "TeamBox";
            this.TeamBox.Size = new System.Drawing.Size(457, 46);
            this.TeamBox.TabIndex = 43;
            // 
            // UpdateUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1385, 878);
            this.Controls.Add(this.TeamBox);
            this.Controls.Add(this.FindAddrButton);
            this.Controls.Add(this.ProfileBox);
            this.Controls.Add(this.UpdateImage);
            this.Controls.Add(this.ZipcodeBox);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.NicknameBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.AddrLabel);
            this.Controls.Add(this.NicknameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.UpdateInfoButton);
            this.Controls.Add(this.TeamLabel);
            this.Controls.Add(this.PwCheckBox);
            this.Controls.Add(this.PwCheckLabel);
            this.Controls.Add(this.PwBox);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.IdBox);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UpdateUserInfo";
            this.Text = "UpdateUserInfo";
            this.Load += new System.EventHandler(this.EditProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button FindAddrButton;
        private PictureBox ProfileBox;
        private Label UpdateImage;
        private TextBox ZipcodeBox;
        private Label zipCodeLabel;
        private TextBox NicknameBox;
        private TextBox NameBox;
        private TextBox AddressBox;
        private Label AddrLabel;
        private Label NicknameLabel;
        private Label nameLabel;
        private Button UpdateInfoButton;
        private Label TeamLabel;
        private TextBox PwCheckBox;
        private Label PwCheckLabel;
        private TextBox PwBox;
        private Label PwLabel;
        private TextBox IdBox;
        private Label IdLabel;
        private Label label1;
        private TextBox TeamBox;
    }
}