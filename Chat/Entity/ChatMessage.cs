using ChattingAppTeam6.Chat.Lib;
using System;
using System.Data;

namespace ChattingAppTeam6.Chat.Entity
{
    public class ChatMessage
    {
        public readonly int id;
        public readonly int room;
        public readonly int sender;
        public readonly string message;
        public readonly DateTime timestamp;
        public readonly bool isRead;
        public readonly bool isDeleted;
    
        public ChatMessage(int id,int room, int sender, string message, DateTime timestamp, bool isRead, bool isDeleted)
        {
            this.id = id;
            this.room = room;
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
            row["Room"] = room;
            row["Sender"] = sender;
            row["Message"] = message;
            row["Timestamp"] = timestamp;
            row["IsRead"] = isRead;
            row["IsDeleted"] = isDeleted;
            return row;
        }

        public static ChatMessage FromPacket(Packet packet)
        {
            return new ChatMessage(
                id: packet.SendMessage.MessageId, // Assuming ID is assigned by the database
                room: packet.ChatId,
                sender: packet.UserId,
                message: packet.SendMessage.Content,
                timestamp: packet.Timestamp.ToDateTime(), // Assuming current time for simplicity
                isRead: false,
                isDeleted: false
            );
        }
    }
}
