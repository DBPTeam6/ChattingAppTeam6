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
    partial class Login
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
            this.WelcomLabel = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.PwLabel = new System.Windows.Forms.Label();
            this.PwBox = new System.Windows.Forms.TextBox();
            this.RememberInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomLabel
            // 
            this.WelcomLabel.AutoSize = true;
            this.WelcomLabel.Font = new System.Drawing.Font("맑은 고딕", 35F);
            this.WelcomLabel.Location = new System.Drawing.Point(499, 102);
            this.WelcomLabel.Name = "WelcomLabel";
            this.WelcomLabel.Size = new System.Drawing.Size(390, 93);
            this.WelcomLabel.TabIndex = 0;
            this.WelcomLabel.Text = "환영합니다";
            // 
            // IdBox
            // 
            this.IdBox.BackColor = System.Drawing.SystemColors.Control;
            this.IdBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdBox.Location = new System.Drawing.Point(451, 318);
            this.IdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IdBox.Multiline = true;
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(463, 62);
            this.IdBox.TabIndex = 1;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdLabel.Location = new System.Drawing.Point(451, 290);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(66, 25);
            this.IdLabel.TabIndex = 2;
            this.IdLabel.Text = "아이디";
            // 
            // PwLabel
            // 
            this.PwLabel.AutoSize = true;
            this.PwLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwLabel.Location = new System.Drawing.Point(451, 394);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(84, 25);
            this.PwLabel.TabIndex = 3;
            this.PwLabel.Text = "비밀번호";
            // 
            // PwBox
            // 
            this.PwBox.BackColor = System.Drawing.SystemColors.Control;
            this.PwBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwBox.Location = new System.Drawing.Point(451, 425);
            this.PwBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PwBox.Multiline = true;
            this.PwBox.Name = "PwBox";
            this.PwBox.PasswordChar = '*';
            this.PwBox.Size = new System.Drawing.Size(463, 62);
            this.PwBox.TabIndex = 4;
            // 
            // RememberInfoCheckBox
            // 
            this.RememberInfoCheckBox.AutoSize = true;
            this.RememberInfoCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RememberInfoCheckBox.Location = new System.Drawing.Point(571, 511);
            this.RememberInfoCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RememberInfoCheckBox.Name = "RememberInfoCheckBox";
            this.RememberInfoCheckBox.Size = new System.Drawing.Size(212, 29);
            this.RememberInfoCheckBox.TabIndex = 5;
            this.RememberInfoCheckBox.Text = "로그인 정보 기억하기";
            this.RememberInfoCheckBox.UseVisualStyleBackColor = true;
            this.RememberInfoCheckBox.CheckedChanged += new System.EventHandler(this.RememberInfoCheckBox_CheckedChanged);
            // 
            // AutoLoginCheckBox
            // 
            this.AutoLoginCheckBox.AutoSize = true;
            this.AutoLoginCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AutoLoginCheckBox.Location = new System.Drawing.Point(800, 511);
            this.AutoLoginCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoLoginCheckBox.Name = "AutoLoginCheckBox";
            this.AutoLoginCheckBox.Size = new System.Drawing.Size(128, 29);
            this.AutoLoginCheckBox.TabIndex = 6;
            this.AutoLoginCheckBox.Text = "자동로그인";
            this.AutoLoginCheckBox.UseVisualStyleBackColor = true;
            this.AutoLoginCheckBox.CheckedChanged += new System.EventHandler(this.AutoLoginCheckBox_CheckedChanged);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginButton.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginButton.Location = new System.Drawing.Point(451, 603);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(463, 64);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SignUpButton
            // 
            this.SignUpButton.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SignUpButton.ForeColor = System.Drawing.Color.Gray;
            this.SignUpButton.Location = new System.Drawing.Point(451, 695);
            this.SignUpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(463, 64);
            this.SignUpButton.TabIndex = 8;
            this.SignUpButton.Text = "회원가입";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1385, 878);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.AutoLoginCheckBox);
            this.Controls.Add(this.RememberInfoCheckBox);
            this.Controls.Add(this.PwBox);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.IdBox);
            this.Controls.Add(this.WelcomLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomLabel;
        private TextBox IdBox;
        private Label IdLabel;
        private Label PwLabel;
        private TextBox PwBox;
        private CheckBox RememberInfoCheckBox;
        private CheckBox AutoLoginCheckBox;
        private Button LoginButton;
        private Button SignUpButton;
    }
}
