using System;

namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatForm
    {
        private void OnLoadChatForm(object sender, EventArgs e)
        {
            // 폼 로드 시 초기화 작업 수행
        }

        private void OnCloseChatForm(object sender, EventArgs e)
        {
            // 폼 닫힐 때 정리 작업 수행
        }

        private void OnClickSendButton(object sender, EventArgs e)
        {
            SendTextMessage();
        }
    }
}
