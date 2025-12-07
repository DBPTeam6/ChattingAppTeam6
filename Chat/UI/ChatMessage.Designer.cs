namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatMessage
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
            this._message = new System.Windows.Forms.Label();
            this._sender = new System.Windows.Forms.Label();
            this._sendTime = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._avatar);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(367, 56);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnChatMessageRClick);
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
            this.panel1.Controls.Add(this._sendTime);
            this.panel1.Controls.Add(this._message);
            this.panel1.Controls.Add(this._sender);
            this.panel1.Location = new System.Drawing.Point(48, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(309, 40);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnChatMessageRClick);
            // 
            // _message
            // 
            this._message.Location = new System.Drawing.Point(3, 25);
            this._message.Margin = new System.Windows.Forms.Padding(0);
            this._message.Name = "_message";
            this._message.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._message.Size = new System.Drawing.Size(306, 12);
            this._message.TabIndex = 1;
            this._message.Text = "label2";
            // 
            // _sender
            // 
            this._sender.AutoSize = true;
            this._sender.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._sender.Location = new System.Drawing.Point(3, 3);
            this._sender.Margin = new System.Windows.Forms.Padding(0);
            this._sender.Name = "_sender";
            this._sender.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._sender.Size = new System.Drawing.Size(52, 12);
            this._sender.TabIndex = 0;
            this._sender.Text = "label1";
            // 
            // _sendTime
            // 
            this._sendTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._sendTime.AutoSize = true;
            this._sendTime.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._sendTime.Location = new System.Drawing.Point(273, 3);
            this._sendTime.Margin = new System.Windows.Forms.Padding(0);
            this._sendTime.Name = "_sendTime";
            this._sendTime.Size = new System.Drawing.Size(28, 11);
            this._sendTime.TabIndex = 2;
            this._sendTime.Text = "time";
            this._sendTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ChatMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ChatMessage";
            this.Size = new System.Drawing.Size(367, 56);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox _avatar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sender;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label _message;
        private System.Windows.Forms.Label _sender;
        private System.Windows.Forms.Label _sendTime;
    }
}
