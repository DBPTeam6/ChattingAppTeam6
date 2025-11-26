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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._chatListContainer = new System.Windows.Forms.Panel();
            this._chatList = new System.Windows.Forms.FlowLayoutPanel();
            this.chatMessage1 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage2 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage3 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage4 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage5 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage6 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this.chatMessage7 = new ChattingAppTeam6.Chat.UI.ChatMessage();
            this._header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._avatar)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(384, 40);
            this.panel4.TabIndex = 0;
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
            this._chatList.Controls.Add(this.chatMessage2);
            this._chatList.Controls.Add(this.chatMessage3);
            this._chatList.Controls.Add(this.chatMessage4);
            this._chatList.Controls.Add(this.chatMessage5);
            this._chatList.Controls.Add(this.chatMessage6);
            this._chatList.Controls.Add(this.chatMessage7);
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
            // chatMessage2
            // 
            this.chatMessage2.AutoSize = true;
            this.chatMessage2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage2.Location = new System.Drawing.Point(0, 56);
            this.chatMessage2.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage2.Name = "chatMessage2";
            this.chatMessage2.Size = new System.Drawing.Size(367, 56);
            this.chatMessage2.TabIndex = 1;
            // 
            // chatMessage3
            // 
            this.chatMessage3.AutoSize = true;
            this.chatMessage3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage3.Location = new System.Drawing.Point(0, 112);
            this.chatMessage3.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage3.Name = "chatMessage3";
            this.chatMessage3.Size = new System.Drawing.Size(367, 56);
            this.chatMessage3.TabIndex = 2;
            // 
            // chatMessage4
            // 
            this.chatMessage4.AutoSize = true;
            this.chatMessage4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage4.Location = new System.Drawing.Point(0, 168);
            this.chatMessage4.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage4.Name = "chatMessage4";
            this.chatMessage4.Size = new System.Drawing.Size(367, 56);
            this.chatMessage4.TabIndex = 3;
            // 
            // chatMessage5
            // 
            this.chatMessage5.AutoSize = true;
            this.chatMessage5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage5.Location = new System.Drawing.Point(0, 224);
            this.chatMessage5.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage5.Name = "chatMessage5";
            this.chatMessage5.Size = new System.Drawing.Size(367, 56);
            this.chatMessage5.TabIndex = 4;
            // 
            // chatMessage6
            // 
            this.chatMessage6.AutoSize = true;
            this.chatMessage6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage6.Location = new System.Drawing.Point(0, 280);
            this.chatMessage6.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage6.Name = "chatMessage6";
            this.chatMessage6.Size = new System.Drawing.Size(367, 56);
            this.chatMessage6.TabIndex = 5;
            // 
            // chatMessage7
            // 
            this.chatMessage7.AutoSize = true;
            this.chatMessage7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatMessage7.Location = new System.Drawing.Point(0, 336);
            this.chatMessage7.Margin = new System.Windows.Forms.Padding(0);
            this.chatMessage7.Name = "chatMessage7";
            this.chatMessage7.Size = new System.Drawing.Size(367, 56);
            this.chatMessage7.TabIndex = 6;
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox _avatar;
        private System.Windows.Forms.Label _senderInfo;
        private System.Windows.Forms.Label _sender;
        private System.Windows.Forms.Panel _chatListContainer;
        private System.Windows.Forms.FlowLayoutPanel _chatList;
        private ChatMessage chatMessage1;
        private ChatMessage chatMessage2;
        private ChatMessage chatMessage3;
        private ChatMessage chatMessage4;
        private ChatMessage chatMessage5;
        private ChatMessage chatMessage6;
        private ChatMessage chatMessage7;
    }
}