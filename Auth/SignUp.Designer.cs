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
    partial class SignUp
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
            this.IdLabel = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.PwLabel = new System.Windows.Forms.Label();
            this.PwBox = new System.Windows.Forms.TextBox();
            this.PwCheckLabel = new System.Windows.Forms.Label();
            this.PwCheckBox = new System.Windows.Forms.TextBox();
            this.TeamLabel = new System.Windows.Forms.Label();
            this.TeamBox = new System.Windows.Forms.ComboBox();
            this.SignupButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NicknameBox = new System.Windows.Forms.TextBox();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.ZipcodeBox = new System.Windows.Forms.TextBox();
            this.UpdateImage = new System.Windows.Forms.Label();
            this.ProfileBox = new System.Windows.Forms.PictureBox();
            this.FindAddrButton = new System.Windows.Forms.Button();
            this.IdCheckButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(370, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원정보를 입력하세요";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdLabel.Location = new System.Drawing.Point(109, 123);
            this.IdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(52, 15);
            this.IdLabel.TabIndex = 1;
            this.IdLabel.Text = "* 아이디";
            // 
            // IdBox
            // 
            this.IdBox.BackColor = System.Drawing.SystemColors.Control;
            this.IdBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdBox.Location = new System.Drawing.Point(104, 143);
            this.IdBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.IdBox.Multiline = true;
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(200, 32);
            this.IdBox.TabIndex = 2;
            this.IdBox.TextChanged += new System.EventHandler(this.IdBox_TextChanged);
            // 
            // PwLabel
            // 
            this.PwLabel.AutoSize = true;
            this.PwLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwLabel.Location = new System.Drawing.Point(109, 188);
            this.PwLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(64, 15);
            this.PwLabel.TabIndex = 3;
            this.PwLabel.Text = "* 비밀번호";
            // 
            // PwBox
            // 
            this.PwBox.BackColor = System.Drawing.SystemColors.Control;
            this.PwBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwBox.Location = new System.Drawing.Point(104, 207);
            this.PwBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PwBox.Multiline = true;
            this.PwBox.Name = "PwBox";
            this.PwBox.PasswordChar = '*';
            this.PwBox.Size = new System.Drawing.Size(321, 32);
            this.PwBox.TabIndex = 4;
            // 
            // PwCheckLabel
            // 
            this.PwCheckLabel.AutoSize = true;
            this.PwCheckLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwCheckLabel.Location = new System.Drawing.Point(104, 256);
            this.PwCheckLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PwCheckLabel.Name = "PwCheckLabel";
            this.PwCheckLabel.Size = new System.Drawing.Size(92, 15);
            this.PwCheckLabel.TabIndex = 6;
            this.PwCheckLabel.Text = "* 비밀번호 확인";
            // 
            // PwCheckBox
            // 
            this.PwCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.PwCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwCheckBox.Location = new System.Drawing.Point(104, 275);
            this.PwCheckBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PwCheckBox.Multiline = true;
            this.PwCheckBox.Name = "PwCheckBox";
            this.PwCheckBox.PasswordChar = '*';
            this.PwCheckBox.Size = new System.Drawing.Size(321, 32);
            this.PwCheckBox.TabIndex = 7;
            this.PwCheckBox.TextChanged += new System.EventHandler(this.PwCheckBox_TextChanged);
            // 
            // TeamLabel
            // 
            this.TeamLabel.AutoSize = true;
            this.TeamLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TeamLabel.Location = new System.Drawing.Point(109, 323);
            this.TeamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TeamLabel.Name = "TeamLabel";
            this.TeamLabel.Size = new System.Drawing.Size(64, 15);
            this.TeamLabel.TabIndex = 8;
            this.TeamLabel.Text = "* 소속부서";
            // 
            // TeamBox
            // 
            this.TeamBox.BackColor = System.Drawing.SystemColors.Control;
            this.TeamBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TeamBox.FormattingEnabled = true;
            this.TeamBox.Location = new System.Drawing.Point(104, 343);
            this.TeamBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TeamBox.Name = "TeamBox";
            this.TeamBox.Size = new System.Drawing.Size(321, 23);
            this.TeamBox.TabIndex = 9;
            // 
            // SignupButton
            // 
            this.SignupButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.SignupButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SignupButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SignupButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SignupButton.Location = new System.Drawing.Point(104, 496);
            this.SignupButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(745, 41);
            this.SignupButton.TabIndex = 10;
            this.SignupButton.Text = "회원가입";
            this.SignupButton.UseVisualStyleBackColor = false;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameLabel.Location = new System.Drawing.Point(528, 256);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 15);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "* 이름";
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NicknameLabel.Location = new System.Drawing.Point(528, 323);
            this.NicknameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(31, 15);
            this.NicknameLabel.TabIndex = 12;
            this.NicknameLabel.Text = "별명";
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddrLabel.Location = new System.Drawing.Point(109, 389);
            this.AddrLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(40, 15);
            this.AddrLabel.TabIndex = 13;
            this.AddrLabel.Text = "* 주소";
            // 
            // AddressBox
            // 
            this.AddressBox.BackColor = System.Drawing.SystemColors.Control;
            this.AddressBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddressBox.Location = new System.Drawing.Point(104, 408);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AddressBox.Multiline = true;
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(456, 32);
            this.AddressBox.TabIndex = 14;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NameBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NameBox.Location = new System.Drawing.Point(524, 275);
            this.NameBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(327, 32);
            this.NameBox.TabIndex = 15;
            // 
            // NicknameBox
            // 
            this.NicknameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NicknameBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NicknameBox.Location = new System.Drawing.Point(524, 343);
            this.NicknameBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.NicknameBox.Multiline = true;
            this.NicknameBox.Name = "NicknameBox";
            this.NicknameBox.Size = new System.Drawing.Size(327, 32);
            this.NicknameBox.TabIndex = 16;
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.zipCodeLabel.Location = new System.Drawing.Point(673, 389);
            this.zipCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(64, 15);
            this.zipCodeLabel.TabIndex = 17;
            this.zipCodeLabel.Text = "* 우편번호";
            // 
            // ZipcodeBox
            // 
            this.ZipcodeBox.BackColor = System.Drawing.SystemColors.Control;
            this.ZipcodeBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ZipcodeBox.Location = new System.Drawing.Point(675, 408);
            this.ZipcodeBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ZipcodeBox.Multiline = true;
            this.ZipcodeBox.Name = "ZipcodeBox";
            this.ZipcodeBox.Size = new System.Drawing.Size(176, 32);
            this.ZipcodeBox.TabIndex = 18;
            // 
            // UpdateImage
            // 
            this.UpdateImage.AutoSize = true;
            this.UpdateImage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpdateImage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.UpdateImage.Location = new System.Drawing.Point(761, 235);
            this.UpdateImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpdateImage.Name = "UpdateImage";
            this.UpdateImage.Size = new System.Drawing.Size(59, 15);
            this.UpdateImage.TabIndex = 19;
            this.UpdateImage.Text = "사진 변경";
            this.UpdateImage.Click += new System.EventHandler(this.UpdateImage_Click);
            // 
            // ProfileBox
            // 
            this.ProfileBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProfileBox.Image = global::ChattingAppTeam6.Properties.Resources.BasicImage;
            this.ProfileBox.Location = new System.Drawing.Point(592, 119);
            this.ProfileBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ProfileBox.Name = "ProfileBox";
            this.ProfileBox.Size = new System.Drawing.Size(140, 133);
            this.ProfileBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfileBox.TabIndex = 20;
            this.ProfileBox.TabStop = false;
            this.ProfileBox.Click += new System.EventHandler(this.UpdateImage_Click);
            // 
            // FindAddrButton
            // 
            this.FindAddrButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FindAddrButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FindAddrButton.Location = new System.Drawing.Point(570, 408);
            this.FindAddrButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.FindAddrButton.Name = "FindAddrButton";
            this.FindAddrButton.Size = new System.Drawing.Size(88, 31);
            this.FindAddrButton.TabIndex = 21;
            this.FindAddrButton.Text = "주소찾기";
            this.FindAddrButton.UseVisualStyleBackColor = true;
            this.FindAddrButton.Click += new System.EventHandler(this.FindAddrButton_Click);
            // 
            // IdCheckButton
            // 
            this.IdCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IdCheckButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdCheckButton.Location = new System.Drawing.Point(315, 143);
            this.IdCheckButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.IdCheckButton.Name = "IdCheckButton";
            this.IdCheckButton.Size = new System.Drawing.Size(109, 31);
            this.IdCheckButton.TabIndex = 5;
            this.IdCheckButton.Text = "중복확인";
            this.IdCheckButton.UseVisualStyleBackColor = true;
            this.IdCheckButton.Click += new System.EventHandler(this.IdCheckButton_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(970, 585);
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
            this.Controls.Add(this.SignupButton);
            this.Controls.Add(this.TeamBox);
            this.Controls.Add(this.TeamLabel);
            this.Controls.Add(this.PwCheckBox);
            this.Controls.Add(this.PwCheckLabel);
            this.Controls.Add(this.IdCheckButton);
            this.Controls.Add(this.PwBox);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.IdBox);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "SignUp";
            this.Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label IdLabel;
        private TextBox IdBox;
        private Label PwLabel;
        private TextBox PwBox;
        private Label PwCheckLabel;
        private TextBox PwCheckBox;
        private Label TeamLabel;
        private ComboBox TeamBox;
        private Button SignupButton;
        private Label nameLabel;
        private Label NicknameLabel;
        private Label AddrLabel;
        private TextBox AddressBox;
        private TextBox NameBox;
        private TextBox NicknameBox;
        private Label zipCodeLabel;
        private TextBox ZipcodeBox;
        private Label UpdateImage;
        private PictureBox ProfileBox;
        private Button FindAddrButton;
        private Button IdCheckButton;
    }
}