using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Chat.Entity
{
    public class ChatMessage
    {
        public readonly int id;
        public readonly ChatUser sender;
        public readonly string message;
        public readonly DateTime timestamp;
        public readonly bool isRead;
        public readonly bool isDeleted;
    
        public ChatMessage(int id, ChatUser sender, string message, DateTime timestamp, bool isRead, bool isDeleted)
        {
            this.id = id;
            this.sender = sender;
            this.message = message;
            this.timestamp = timestamp;
            this.isRead = isRead;
            this.isDeleted = isDeleted;
        }

        public DataRow ToDataRow(DataTable table)
        {
            DataRow row = table.NewRow();
            row["Id"] = id;
            row["SenderId"] = sender.id;
            row["Message"] = message;
            row["Timestamp"] = timestamp;
            row["IsRead"] = isRead;
            row["IsDeleted"] = isDeleted;
            return row;
        }
    }
}
