using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ChattingAppTeam6.Chat.UI
{
    partial class ChatForm
    {
        private void OnLoadChatForm(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ChatForm loaded.");
            // 폼 로드 시 초기화 작업 수행
        }

        private void OnCloseChatForm(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ChatForm closing.");
            
            viewModel.StopListen();
        }

        private void OnClickSendButton(object sender, EventArgs e)
        {
            SendTextMessage();
        }

        private void OnClickSendImageButton(object sender, EventArgs e)
        {
            
        }

        private void OnClickSendFileButton(object sender, EventArgs e)
        {
            if (openFileDialogForFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialogForFile.FileName;
                Stream fileStream = openFileDialogForFile.OpenFile();
                Debug.WriteLine("Selected file: " + fileName);
                Debug.WriteLine("File stream length: " + fileStream.Length);
                SendFileMessage(fileName, fileStream);
            }
        }

        private void OnClickSendEmoticonButton(object sender, EventArgs e)
        {
            // 이모티콘 전송 버튼 클릭 처리
        }
    }
}
