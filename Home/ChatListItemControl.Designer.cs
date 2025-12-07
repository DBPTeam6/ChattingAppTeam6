using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChattingAppTeam6.Home
{
    partial class ChatListItemControl
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
            this.chatPIC = new System.Windows.Forms.PictureBox();
            this.lastChatTime = new System.Windows.Forms.Label();
            this.lastChat = new System.Windows.Forms.Label();
            this.chatName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chatPIC)).BeginInit();
            this.SuspendLayout();
            // 
            // chatPIC
            // 
            this.chatPIC.Location = new System.Drawing.Point(25, 14);
            this.chatPIC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatPIC.Name = "chatPIC";
            this.chatPIC.Size = new System.Drawing.Size(59, 59);
            this.chatPIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chatPIC.TabIndex = 11;
            this.chatPIC.TabStop = false;
            // 
            // lastChatTime
            // 
            this.lastChatTime.AutoSize = true;
            this.lastChatTime.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lastChatTime.ForeColor = System.Drawing.Color.DimGray;
            this.lastChatTime.Location = new System.Drawing.Point(395, 35);
            this.lastChatTime.Name = "lastChatTime";
            this.lastChatTime.Size = new System.Drawing.Size(124, 20);
            this.lastChatTime.TabIndex = 16;
            this.lastChatTime.Text = "마지막 채팅 시간";
            this.lastChatTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastChat
            // 
            this.lastChat.AutoSize = true;
            this.lastChat.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lastChat.ForeColor = System.Drawing.Color.Gray;
            this.lastChat.Location = new System.Drawing.Point(110, 52);
            this.lastChat.Name = "lastChat";
            this.lastChat.Size = new System.Drawing.Size(124, 20);
            this.lastChat.TabIndex = 15;
            this.lastChat.Text = "마지막 채팅 내용";
            // 
            // chatName
            // 
            this.chatName.AutoSize = true;
            this.chatName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chatName.ForeColor = System.Drawing.Color.Black;
            this.chatName.Location = new System.Drawing.Point(110, 14);
            this.chatName.Name = "chatName";
            this.chatName.Size = new System.Drawing.Size(74, 20);
            this.chatName.TabIndex = 14;
            this.chatName.Text = "상대 이름";
            // 
            // ChatListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lastChatTime);
            this.Controls.Add(this.lastChat);
            this.Controls.Add(this.chatName);
            this.Controls.Add(this.chatPIC);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatListItemControl";
            this.Size = new System.Drawing.Size(544, 88);
            ((System.ComponentModel.ISupportInitialize)(this.chatPIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox chatPIC;
        private Label lastChatTime;
        private Label lastChat;
        private Label chatName;
    }
}
