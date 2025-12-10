using System;
using System.Data;

namespace ChattingAppTeam6.Chat.Entity
{
    public class ChatRoom
    {
        public readonly int id;
        public readonly string name;
        public readonly ChatUser me;
        public readonly ChatUser target;
        public DateTime last_chat_time;
        public string last_chat_content;
        public string banner;

        public ChatRoom(int id, string name, ChatUser me, ChatUser target, DateTime last_chat_time, string last_chat_content, string banner)
        {
            this.id = id;
            this.name = name;
            this.me = me;
            this.target = target;
            this.last_chat_time = last_chat_time;
            this.last_chat_content = last_chat_content;
            this.banner = banner;
        }

        public static ChatRoom FromTable(DataTable table, ChatUser me, ChatUser target)
        {
            return new ChatRoom(
                id: Convert.ToInt32(table.Rows[0]["id"]),
                name: Convert.ToString(table.Rows[0]["name"]),
                me: me,
                target: target,
                last_chat_time: table.Rows[0]["last_chat_time"] == DBNull.Value ? 
                    DateTime.MinValue : Convert.ToDateTime(table.Rows[0]["last_chat_time"]),
                last_chat_content: table.Rows[0]["last_chat_content"] == DBNull.Value ? 
                    string.Empty : Convert.ToString(table.Rows[0]["last_chat_content"]),
                banner: table.Rows[0]["banner"] == DBNull.Value ?
                    string.Empty : Convert.ToString(table.Rows[0]["banner"])
            );
        }
    }
}
