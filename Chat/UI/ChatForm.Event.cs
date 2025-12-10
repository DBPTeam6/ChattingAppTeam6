using ChattingAppTeam6.Chat.Lib;
using System;
using System.Diagnostics;
using System.Drawing;
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

        private void OnClickSendFileButton(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Stream fileStream = openFileDialog.OpenFile();
                Debug.WriteLine("Selected file: " + fileName);
                Debug.WriteLine("File stream length: " + fileStream.Length);
                SendFileMessage(fileName, fileStream);
            }
        }

        private void OnClickSendEmoticonButton(object sender, EventArgs e)
        {
            new ChatEmoticonForm((image) =>
            {
                SendEmoticonMessage(Chat.Lib.ImageConverter.ImageToStream(image));
            }).ShowDialog();
        }

        /// <summary>
        /// 검색 버튼 클릭 이벤트
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ChatSearchForm searchForm = new ChatSearchForm(viewModel);
            searchForm.ShowDialog(this);
        }
    }
}
