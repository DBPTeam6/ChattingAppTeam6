using System;
using System.Data;
using System.IO;
using ChattingAppTeam6.Chat.Entity;
using ChattingAppTeam6.Chat.Lib;
using Google.Protobuf;

namespace ChattingAppTeam6.Chat.UI
{
    internal class ChatFormViewModel
    {
        private readonly ChattingClient client;
        private readonly DB db;
        public ChatRoom room;

        public ChatFormViewModel(int roomId, int selfUserId)
        {
            this.client = ChattingClient.GetInstance();
            this.db = DB.GetInstance();
            
            LoadRoom(roomId, selfUserId);
        }

        public void LoadRoom(int roomId, int selfUserId)
        {
            DataTable rawRoom = db.ReadQuery("SELECT * FROM chat WHERE id = @id", new ParameterBuilder()
                .Add("@id", roomId)
                .Build());

            ChatUser user1 = GetChatUser((int)rawRoom.Rows[0]["profile_id_1"]);
            ChatUser user2 = GetChatUser((int)rawRoom.Rows[0]["profile_id_2"]);

            if (user2.user == selfUserId) {
                var temp = user1;
                user1 = user2;
                user2 = temp;
            }

            this.room = ChatRoom.FromTable(rawRoom, user1, user2);
        }

        private ChatUser GetChatUser(int profileId)
        {
            var parameters = new ParameterBuilder()
                .Add("@id", profileId)
                .Build();
            var chatUser = db.ReadQuery("SELECT * FROM profile WHERE @id = id", parameters);

            return ChatUser.FromTable(chatUser);
        }

        public void On(string command, Action<Packet> callbackFn)
        {
            client.commands[command] = callbackFn;
        }

        public void Listen()
        {
            client.Connect();
        }

        public void SendTextMessage(Entity.ChatMessage message)
        {
            client.SendMessage(message.room, room.me.id, message.message);
        }

        public void DeleteMessage(Entity.ChatMessage message)
        {
            client.DeleteMessage(message.room, message.id);
        }

        public void SendFileMessage(Entity.ChatMessage message, Stream fs)
        {
            client.SendFile(message.room, room.me.id, message.message, ByteString.FromStream(fs));
        }
    }
}
