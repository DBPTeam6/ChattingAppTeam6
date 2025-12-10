using ChatMessage;
using ChattingAppTeam6.Chat.Lib;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChattingAppTeam6.Notification
{
    internal static class PacketReceiver
    {
        private static readonly string[] ImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        // Entry point to be called by actual network receive loop
        public static void OnPacketReceived(Packet packet, int userId)
        {
            try
            {
                string command = Convert.ToString(packet.Command);
                command = command.Split('-')[1];
                if (packet.UserId == userId)
                {
                    return;
                }
                DataTable dt = DBconnector.DBConnector.GetInstance().Query($"SELECT id FROM chat WHERE user_id_1 = {userId} || user_id_2 = {userId};");
                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row[0].ToString()) == packet.ChatId)
                    {
                        int chatId = Convert.ToInt32(packet.ChatId);
                        int profileId = Convert.ToInt32(packet.ProfileId);
                        DateTime timestamp = DateTime.Now;
                        Debug.WriteLine(timestamp);

                        string nickname = ProfileService.GetNickname(profileId);
                        if (string.IsNullOrEmpty(nickname)) nickname = "알 수 없음";

                        switch (command)
                        {
                            case "SEND_MESSAGE":
                                string content = Convert.ToString(packet.SendMessage.Content) ?? string.Empty;
                                string preview = BuildMessagePreview(content);
                                ToastManager.ShowToast(nickname, timestamp, preview, chatId);
                                break;
                            case "SEND_FILE":
                                string fileName = Convert.ToString(packet.SendFile.FileName) ?? string.Empty;
                                string previewFile = BuildFilePreview(fileName);
                                ToastManager.ShowToast(nickname, timestamp, previewFile, chatId);
                                break;
                        }
                    }
                }
            }
            catch
            {
                // swallow to keep notification safe
            }
        }

        private static string BuildMessagePreview(string content)
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            var trimmed = content.Replace("\r", " ").Replace("\n", " ");
            if (trimmed.Length > 10)
            {
                return trimmed.Substring(0, 10) + "...";
            }
            return trimmed;
        }

        private static string BuildFilePreview(string fileName)
        {
            try
            {
                var ext = Path.GetExtension(fileName)?.ToLowerInvariant() ?? string.Empty;
                if (ext == "가나디.png")
                    return "이모티콘을 보냈어요.";

                if (ImageExtensions.Contains(ext))
                {
                    return "사진을 보냈어요.";
                }
                return "파일을 보냈어요.";
            }
            catch { return "파일을 보냈어요."; }
        }
    }
}
