using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChattingAppTeam6.Notification
{
    internal static class PacketReceiver
    {
        private static readonly string[] ImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        // Entry point to be called by actual network receive loop
        public static void OnPacketReceived(dynamic packet)
        {
            try
            {
                string command = Convert.ToString(packet.Base.Command);
                int chatId = Convert.ToInt32(packet.Base.ChatId);
                int profileId = Convert.ToInt32(packet.Base.ProfileId);
                DateTime timestamp = Convert.ToDateTime(packet.Base.Timestamp);

                string nickname = ProfileService.GetNickname(profileId);
                if (string.IsNullOrEmpty(nickname)) nickname = "알 수 없음";

                switch (command)
                {
                    case "SEND_MESSAGE":
                        string content = Convert.ToString(packet.Content) ?? string.Empty;
                        string preview = BuildMessagePreview(content);
                        ToastManager.ShowToast(nickname, timestamp, preview, chatId);
                        break;
                    case "SEND_FILE":
                        string fileName = Convert.ToString(packet.FileName) ?? string.Empty;
                        string previewFile = BuildFilePreview(fileName);
                        ToastManager.ShowToast(nickname, timestamp, previewFile, chatId);
                        break;
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
