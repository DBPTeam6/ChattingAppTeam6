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
    partial class ManageFriendsForm
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
            this.userFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.profileFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // userFlowPanel
            // 
            this.userFlowPanel.Location = new System.Drawing.Point(22, 0);
            this.userFlowPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userFlowPanel.Name = "userFlowPanel";
            this.userFlowPanel.Size = new System.Drawing.Size(464, 759);
            this.userFlowPanel.TabIndex = 1;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConfirmButton.Location = new System.Drawing.Point(621, 669);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(131, 53);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "설정";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // profileFlowPanel
            // 
            this.profileFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.profileFlowPanel.Location = new System.Drawing.Point(534, 9);
            this.profileFlowPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profileFlowPanel.Name = "profileFlowPanel";
            this.profileFlowPanel.Size = new System.Drawing.Size(300, 629);
            this.profileFlowPanel.TabIndex = 3;
            // 
            // ManageFriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 760);
            this.Controls.Add(this.profileFlowPanel);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.userFlowPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageFriendsForm";
            this.Text = "ManageFriendsForm";
            this.Load += new System.EventHandler(this.ManageFriendsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel userFlowPanel;
        private Button ConfirmButton;
        private FlowLayoutPanel profileFlowPanel;
    }
}