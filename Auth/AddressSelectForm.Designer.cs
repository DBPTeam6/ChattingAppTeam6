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
    partial class AddressSelectForm
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
            this.AddressGrid = new System.Windows.Forms.DataGridView();
            this.AddressBox = new System.Windows.Forms.GroupBox();
            this.DetailAddressBox = new System.Windows.Forms.GroupBox();
            this.ConfirmBtutton = new System.Windows.Forms.Button();
            this.DetailAddrBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.PrevButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AddressGrid)).BeginInit();
            this.AddressBox.SuspendLayout();
            this.DetailAddressBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddressGrid
            // 
            this.AddressGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddressGrid.Location = new System.Drawing.Point(22, 40);
            this.AddressGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressGrid.Name = "AddressGrid";
            this.AddressGrid.RowHeadersWidth = 62;
            this.AddressGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AddressGrid.Size = new System.Drawing.Size(860, 478);
            this.AddressGrid.TabIndex = 0;
            this.AddressGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddressGrid_CellDoubleClick);
            // 
            // AddressBox
            // 
            this.AddressBox.Controls.Add(this.AddressGrid);
            this.AddressBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddressBox.Location = new System.Drawing.Point(26, 84);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressBox.Size = new System.Drawing.Size(899, 511);
            this.AddressBox.TabIndex = 1;
            this.AddressBox.TabStop = false;
            this.AddressBox.Text = "도로명주소 검색 결과";
            // 
            // DetailAddressBox
            // 
            this.DetailAddressBox.Controls.Add(this.ConfirmBtutton);
            this.DetailAddressBox.Controls.Add(this.DetailAddrBox);
            this.DetailAddressBox.Controls.Add(this.AddressLabel);
            this.DetailAddressBox.Controls.Add(this.label2);
            this.DetailAddressBox.Controls.Add(this.label1);
            this.DetailAddressBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DetailAddressBox.Location = new System.Drawing.Point(26, 84);
            this.DetailAddressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DetailAddressBox.Name = "DetailAddressBox";
            this.DetailAddressBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DetailAddressBox.Size = new System.Drawing.Size(899, 505);
            this.DetailAddressBox.TabIndex = 1;
            this.DetailAddressBox.TabStop = false;
            this.DetailAddressBox.Text = "상세주소 입력";
            // 
            // ConfirmBtutton
            // 
            this.ConfirmBtutton.Location = new System.Drawing.Point(414, 250);
            this.ConfirmBtutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmBtutton.Name = "ConfirmBtutton";
            this.ConfirmBtutton.Size = new System.Drawing.Size(133, 47);
            this.ConfirmBtutton.TabIndex = 4;
            this.ConfirmBtutton.Text = "주소입력";
            this.ConfirmBtutton.UseVisualStyleBackColor = true;
            this.ConfirmBtutton.Click += new System.EventHandler(this.ConfirmBtutton_Click);
            // 
            // DetailAddrBox
            // 
            this.DetailAddrBox.Location = new System.Drawing.Point(267, 139);
            this.DetailAddrBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DetailAddrBox.Multiline = true;
            this.DetailAddrBox.Name = "DetailAddrBox";
            this.DetailAddrBox.Size = new System.Drawing.Size(572, 46);
            this.DetailAddrBox.TabIndex = 3;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(271, 77);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(0, 25);
            this.AddressLabel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "상세주소입력";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "도로명주소";
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BackButton.Location = new System.Drawing.Point(813, 44);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(112, 34);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(58, 32);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(0, 18);
            this.PageLabel.TabIndex = 3;
            // 
            // PrevButton
            // 
            this.PrevButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PrevButton.Location = new System.Drawing.Point(422, 613);
            this.PrevButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(79, 34);
            this.PrevButton.TabIndex = 4;
            this.PrevButton.Text = "이전";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.NextButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NextButton.Location = new System.Drawing.Point(521, 613);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(79, 34);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "다음";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // AddressSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 663);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DetailAddressBox);
            this.Controls.Add(this.AddressBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddressSelectForm";
            this.Text = "AddressSelectForm";
            this.Load += new System.EventHandler(this.AddressSelectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AddressGrid)).EndInit();
            this.AddressBox.ResumeLayout(false);
            this.DetailAddressBox.ResumeLayout(false);
            this.DetailAddressBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView AddressGrid;
        private GroupBox AddressBox;
        private GroupBox DetailAddressBox;
        private TextBox DetailAddrBox;
        private Label AddressLabel;
        private Label label2;
        private Label label1;
        private Button ConfirmBtutton;
        private Button BackButton;
        private Label PageLabel;
        private Button PrevButton;
        private Button NextButton;
    }
}