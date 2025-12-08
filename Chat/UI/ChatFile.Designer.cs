namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatFile
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._avatar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._sendTime = new System.Windows.Forms.Label();
            this._sender = new System.Windows.Forms.Label();
            this._filePanel = new System.Windows.Forms.Panel();
            this._fileName = new System.Windows.Forms.Label();
            this._btnDownload = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).BeginInit();
            this.panel1.SuspendLayout();
            this._filePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this._avatar);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(367, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(367, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(367, 106);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _avatar
            // 
            this._avatar.Image = global::ChattingAppTeam6.Properties.Resources.chat_profile_test;
            this._avatar.Location = new System.Drawing.Point(8, 8);
            this._avatar.Margin = new System.Windows.Forms.Padding(0);
            this._avatar.Name = "_avatar";
            this._avatar.Size = new System.Drawing.Size(40, 40);
            this._avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._avatar.TabIndex = 0;
            this._avatar.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this._sendTime);
            this.panel1.Controls.Add(this._sender);
            this.panel1.Controls.Add(this._filePanel);
            this.panel1.Location = new System.Drawing.Point(48, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(304, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(303, 50);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(304, 90);
            this.panel1.TabIndex = 1;
            // 
            // _sendTime
            // 
            this._sendTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._sendTime.AutoSize = true;
            this._sendTime.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._sendTime.Location = new System.Drawing.Point(272, 3);
            this._sendTime.Margin = new System.Windows.Forms.Padding(0);
            this._sendTime.Name = "_sendTime";
            this._sendTime.Size = new System.Drawing.Size(28, 11);
            this._sendTime.TabIndex = 3;
            this._sendTime.Text = "time";
            this._sendTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _sender
            // 
            this._sender.AutoSize = true;
            this._sender.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._sender.Location = new System.Drawing.Point(7, 3);
            this._sender.Margin = new System.Windows.Forms.Padding(0);
            this._sender.Name = "_sender";
            this._sender.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._sender.Size = new System.Drawing.Size(58, 12);
            this._sender.TabIndex = 0;
            this._sender.Text = "sender";
            // 
            // _filePanel
            // 
            this._filePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this._filePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._filePanel.Controls.Add(this._fileName);
            this._filePanel.Controls.Add(this._btnDownload);
            this._filePanel.Location = new System.Drawing.Point(5, 20);
            this._filePanel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this._filePanel.Name = "_filePanel";
            this._filePanel.Size = new System.Drawing.Size(295, 70);
            this._filePanel.TabIndex = 1;
            // 
            // _fileName
            // 
            this._fileName.AutoEllipsis = true;
            this._fileName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._fileName.Location = new System.Drawing.Point(10, 10);
            this._fileName.Name = "_fileName";
            this._fileName.Size = new System.Drawing.Size(273, 20);
            this._fileName.TabIndex = 0;
            this._fileName.Text = "파일이름.txt";
            // 
            // _btnDownload
            // 
            this._btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDownload.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._btnDownload.Location = new System.Drawing.Point(10, 35);
            this._btnDownload.Name = "_btnDownload";
            this._btnDownload.Size = new System.Drawing.Size(100, 25);
            this._btnDownload.TabIndex = 1;
            this._btnDownload.Text = "💾 저장";
            this._btnDownload.UseVisualStyleBackColor = true;
            this._btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // ChatFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(367, 0);
            this.MinimumSize = new System.Drawing.Size(367, 0);
            this.Name = "ChatFile";
            this.Size = new System.Drawing.Size(367, 106);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._filePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox _avatar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _sender;
        private System.Windows.Forms.Label _sendTime;
        private System.Windows.Forms.Panel _filePanel;
        private System.Windows.Forms.Label _fileName;
        private System.Windows.Forms.Button _btnDownload;
    }
}
