using ChatMessage;
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

        public static ChatMessage FromTableRow(DataRow row, ChatUser me, ChatUser target)
        {
            return new ChatMessage(
                id: Convert.ToInt32(row["id"]),
                room: Convert.ToInt32(row["chat_id"]),
                sender: Convert.ToInt32(row["user_id"]),
                message: Convert.ToString(row["content"]),
                timestamp: Convert.ToDateTime(row["timestamp"]),
                isRead: false,
                isDeleted: false
            );
        }

        public ChatFileMessage AttachFile(string fileName, byte[] fileContent)
        {
            return new ChatFileMessage(
                id: this.id,
                room: this.room,
                sender: this.sender,
                message: this.message,
                timestamp: this.timestamp,
                isRead: this.isRead,
                isDeleted: this.isDeleted,
                fileName: fileName,
                fileContent: fileContent
            );
        }
    }

    public class ChatFileMessage : ChatMessage
    {
        public readonly string fileName;
        public readonly byte[] fileContent;

        public ChatFileMessage(int id, int room, int sender, string message, DateTime timestamp, bool isRead, bool isDeleted, string fileName, byte[] fileContent)
            : base(id, room, sender, message, timestamp, isRead, isDeleted)
        {
            this.fileName = fileName;
            this.fileContent = fileContent;
        }

        public static ChatFileMessage FromPacket(Packet packet)
        {
            return new ChatFileMessage(
                id: packet.SendFile.MessageId, // Assuming ID is assigned by the database
                room: packet.ChatId,
                sender: packet.UserId,
                message: packet.SendFile.FileName,
                timestamp: packet.Timestamp.ToDateTime(), // Assuming current time for simplicity
                isRead: false,
                isDeleted: false,
                fileName: packet.SendFile.FileName,
                fileContent: packet.SendFile.FileContent.ToByteArray()
            );
        }
    }
}
