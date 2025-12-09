using ChattingAppTeam6.Chat.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace ChattingAppTeam6.Chat.Lib
{
    public class MessageStorage
    {
        private static HashSet<int> LoadedUserIds = new HashSet<int>();
        private static DataTable Storage = new DataTable();

        public static void Initialize()
        {
            Storage.Columns.Add("Id", typeof(int));
            Storage.Columns.Add("Room", typeof(int));
            Storage.Columns.Add("Sender", typeof(int));
            Storage.Columns.Add("Message", typeof(string));
            Storage.Columns.Add("Timestamp", typeof(DateTime));
            Storage.Columns.Add("IsRead", typeof(bool));
            Storage.Columns.Add("IsDeleted", typeof(bool));
        }

        public static void Load(int targetUserId, Action OnChatReady)
        {
            // db에서 메시지 전부 가져오기
            if (!LoadedUserIds.Contains(targetUserId))
            {
                // db에서 메시지 전부 가져오기
                LoadedUserIds.Add(targetUserId);
            }
            OnChatReady();
        }

        public static void SaveMessage(Entity.ChatMessage message)
        {
            Storage.Rows.Add(message.ToDataRow(Storage));
        }
    }
}
