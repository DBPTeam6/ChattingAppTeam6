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
    partial class MultiProfiles
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
            this.profilePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ManageFriendsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profilePanel
            // 
            this.profilePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.profilePanel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.profilePanel.Location = new System.Drawing.Point(12, 85);
            this.profilePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(454, 602);
            this.profilePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "멀티프로필";
            // 
            // ManageFriendsButton
            // 
            this.ManageFriendsButton.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ManageFriendsButton.Location = new System.Drawing.Point(140, 716);
            this.ManageFriendsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManageFriendsButton.Name = "ManageFriendsButton";
            this.ManageFriendsButton.Size = new System.Drawing.Size(184, 55);
            this.ManageFriendsButton.TabIndex = 0;
            this.ManageFriendsButton.Text = "친구 관리";
            this.ManageFriendsButton.UseVisualStyleBackColor = true;
            this.ManageFriendsButton.Click += new System.EventHandler(this.ManageFriendsButton_Click);
            // 
            // MultiProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 802);
            this.Controls.Add(this.ManageFriendsButton);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MultiProfiles";
            this.Text = "MultiProfiles";
            this.Load += new System.EventHandler(this.MultiProfiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel profilePanel;
        private Label label1;
        private Button ManageFriendsButton;
    }
}