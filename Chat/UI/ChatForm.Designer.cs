namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatForm
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
            this._header = new System.Windows.Forms.Panel();
            this._senderInfo = new System.Windows.Forms.Label();
            this._sender = new System.Windows.Forms.Label();
            this._avatar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._chatSend = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this._tools = new System.Windows.Forms.Panel();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._chatListContainer = new System.Windows.Forms.Panel();
            this._chatList = new System.Windows.Forms.FlowLayoutPanel();
            this.chatMessage1 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this._header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).BeginInit();
            this.panel2.SuspendLayout();
            this._chatSend.SuspendLayout();
            this.panel3.SuspendLayout();
            this._chatListContainer.SuspendLayout();
            this._chatList.SuspendLayout();
            this.SuspendLayout();
            // 
            // _header
            // 
            this._header.Controls.Add(this._senderInfo);
            this._header.Controls.Add(this._sender);
            this._header.Controls.Add(this._avatar);
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.Location = new System.Drawing.Point(0, 0);
            this._header.Margin = new System.Windows.Forms.Padding(0);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(384, 80);
            this._header.TabIndex = 0;
            // 
            // _senderInfo
            // 
            this._senderInfo.AutoSize = true;
            this._senderInfo.Location = new System.Drawing.Point(77, 48);
            this._senderInfo.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._senderInfo.Name = "_senderInfo";
            this._senderInfo.Size = new System.Drawing.Size(38, 12);
            this._senderInfo.TabIndex = 2;
            this._senderInfo.Text = "label2";
            // 
            // _sender
            // 
            this._sender.AutoSize = true;
            this._sender.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._sender.Location = new System.Drawing.Point(76, 24);
            this._sender.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._sender.Name = "_sender";
            this._sender.Size = new System.Drawing.Size(54, 16);
            this._sender.TabIndex = 1;
            this._sender.Text = "label1";
            // 
            // _avatar
            // 
            this._avatar.Location = new System.Drawing.Point(16, 16);
            this._avatar.Margin = new System.Windows.Forms.Padding(16, 16, 0, 16);
            this._avatar.Name = "_avatar";
            this._avatar.Size = new System.Drawing.Size(48, 48);
            this._avatar.TabIndex = 0;
            this._avatar.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._chatSend);
            this.panel2.Controls.Add(this._tools);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 100);
            this.panel2.TabIndex = 1;
            // 
            // _chatSend
            // 
            this._chatSend.Controls.Add(this.txtMessage);
            this._chatSend.Controls.Add(this.btnSend);
            this._chatSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chatSend.Location = new System.Drawing.Point(0, 0);
            this._chatSend.Margin = new System.Windows.Forms.Padding(0);
            this._chatSend.Name = "_chatSend";
            this._chatSend.Size = new System.Drawing.Size(384, 60);
            this._chatSend.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(324, 60);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSend.Location = new System.Drawing.Point(324, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 60);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.OnClickSendButton);
            // 
            // _tools
            // 
            this._tools.Controls.Add(this.btnImage);
            this._tools.Controls.Add(this.btnFile);
            this._tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tools.Location = new System.Drawing.Point(0, 60);
            this._tools.Margin = new System.Windows.Forms.Padding(0);
            this._tools.Name = "_tools";
            this._tools.Size = new System.Drawing.Size(384, 40);
            this._tools.TabIndex = 0;
            // 
            // btnImage
            // 
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImage.FlatAppearance.BorderSize = 0;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnImage.Location = new System.Drawing.Point(0, 0);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(80, 40);
            this.btnImage.TabIndex = 0;
            this.btnImage.Text = "📷 이미지";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.OnClickSendImageButton);
            // 
            // btnFile
            // 
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFile.FlatAppearance.BorderSize = 0;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFile.Location = new System.Drawing.Point(80, 0);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(80, 40);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "📎 파일";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.OnClickSendFileButton);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._chatListContainer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 281);
            this.panel3.TabIndex = 2;
            // 
            // _chatListContainer
            // 
            this._chatListContainer.Controls.Add(this._chatList);
            this._chatListContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chatListContainer.Location = new System.Drawing.Point(0, 0);
            this._chatListContainer.Margin = new System.Windows.Forms.Padding(0);
            this._chatListContainer.Name = "_chatListContainer";
            this._chatListContainer.Size = new System.Drawing.Size(384, 281);
            this._chatListContainer.TabIndex = 1;
            // 
            // _chatList
            // 
            this._chatList.AutoScroll = true;
            this._chatList.AutoSize = true;
            this._chatList.Controls.Add(this.chatMessage1);
            this._chatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chatList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._chatList.Location = new System.Drawing.Point(0, 0);
            this._chatList.Margin = new System.Windows.Forms.Padding(0);
            this._chatList.Name = "_chatList";
            this._chatList.Size = new System.Drawing.Size(384, 281);
            this._chatList.TabIndex = 0;
            this._chatList.WrapContents = false;
            // 
            // chatMessage1
            // 
            this.chatMessage1.AutoSize = true;
            this.chatMessage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage1.Location = new System.Drawing.Point(0, 0);
            this.chatMessage1.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage1.Name = "chatMessage1";
            this.chatMessage1.Size = new System.Drawing.Size(367, 56);
            this.chatMessage1.TabIndex = 0;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this._header);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this._header.ResumeLayout(false);
            this._header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).EndInit();
            this.panel2.ResumeLayout(false);
            this._chatSend.ResumeLayout(false);
            this._chatSend.PerformLayout();
            this.panel3.ResumeLayout(false);
            this._chatListContainer.ResumeLayout(false);
            this._chatListContainer.PerformLayout();
            this._chatList.ResumeLayout(false);
            this._chatList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _header;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox _avatar;
        private System.Windows.Forms.Label _senderInfo;
        private System.Windows.Forms.Label _sender;
        private System.Windows.Forms.Panel _chatListContainer;
        private System.Windows.Forms.FlowLayoutPanel _chatList;
        private ChatMessage chatMessage1;
        private System.Windows.Forms.Panel _chatSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel _tools;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnFile;
    }
}