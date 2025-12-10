using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ChatMessage;
using ChattingAppTeam6.Chat.Entity;
using ChattingAppTeam6.Chat.Lib;
using Google.Protobuf;

namespace ChattingAppTeam6.Chat.UI
{
    public class ChatFormViewModel
    {
        private readonly ChattingClient client;
        private readonly BadWordFilter filter;
        private readonly DB db;
        public ChatRoom room;

        public ChatFormViewModel(int roomId, int selfUserId)
        {
            this.client = ChattingClient.GetInstance();
            this.filter = BadWordFilter.GetInstance();
            this.db = DB.GetInstance();
            
            LoadRoom(roomId, selfUserId);
        }

        public void LoadRoom(int roomId, int selfUserId)
        {
            DataTable rawRoom = db.ReadQuery("SELECT * FROM chat WHERE id = @id", new ParameterBuilder()
                .Add("@id", roomId)
                .Build());

            var otherId = Convert.ToInt32(rawRoom.Rows[0]["user_id_1"]);
            otherId = otherId == selfUserId ? Convert.ToInt32(rawRoom.Rows[0]["user_id_2"]) : otherId;

            ChatUser user1 = GetChatUser(Convert.ToInt32(rawRoom.Rows[0]["profile_id_1"]));
            ChatUser user2 = GetChatUser(Convert.ToInt32(rawRoom.Rows[0]["profile_id_2"]));

            if (user2.user_id == selfUserId) {
                var temp = user1;
                user1 = user2;
                user2 = temp;
            }

            var meToTargetProfile = db.ReadQuery("SELECT profile_id FROM profile_access WHERE user_id = @user_id AND target_user_id = @target_user_id", new ParameterBuilder()
                .Add("@user_id", selfUserId)
                .Add("@target_user_id", otherId)
                .Build());
            var targetToMeProfile = db.ReadQuery("SELECT profile_id FROM profile_access WHERE user_id = @user_id AND target_user_id = @target_user_id", new ParameterBuilder()
                .Add("@user_id", otherId)
                .Add("@target_user_id", selfUserId)
                .Build());

            if (meToTargetProfile.Rows.Count > 0)
                user1 = GetChatUser(Convert.ToInt32(meToTargetProfile.Rows[0]["profile_id"]));
            if (targetToMeProfile.Rows.Count > 0)
                user2 = GetChatUser(Convert.ToInt32(targetToMeProfile.Rows[0]["profile_id"]));

            // room 업데이트
            db.CreateQuery($"UPDATE chat SET {(user1.user_id == selfUserId ? "profile_id_1=@profile_id_1" : "profile_id_1=@profile_id_2")}, {(user1.user_id == otherId ? "profile_id_2=@profile_id_1" : "profile_id_2=@profile_id_2")} WHERE id = @id", new ParameterBuilder()
                .Add("@id", roomId)
                .Add("@profile_id_1", user1.profile_id)
                .Add("@profile_id_2", user2.profile_id)
                .Build());

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

        public List<Entity.ChatMessage> LoadAllMessages()
        {
            var parameters = new ParameterBuilder()
                .Add("@chat_id", room.id)
                .Build();
            var rawMessages = db.ReadQuery("SELECT * FROM message_log WHERE chat_id = @chat_id ORDER BY timestamp ASC", parameters);
            List<Entity.ChatMessage> messages = new List<Entity.ChatMessage>();
            foreach (DataRow message in rawMessages.Rows)
            {
                messages.Add(Entity.ChatMessage.FromTableRow(message, room.me, room.target));
            }
            return messages;
        }

        public void On(string command, Action<Packet> callbackFn)
        {
            client.commands[command] = callbackFn;
        }

        public void SendTextMessage(Entity.ChatMessage message)
        {
            string filterdMessage = filter.FilteredText(message.message);
            client.SendMessage(message.room, room.me.profile_id, filterdMessage);
        }

        public void DeleteMessage(Entity.ChatMessage message)
        {
            client.DeleteMessage(message.room, message.id);
        }

        public void SendFileMessage(Entity.ChatMessage message, Stream fs)
        {
            client.SendFile(message.room, room.me.profile_id, message.message, ByteString.FromStream(fs));
        }

        public void StopListen()
        {
            client.commands[$"{room.id}-SEND_MESSAGE"] = (packet) => { };
            client.commands[$"{room.id}-DELETE_MESSAGE"] = (packet) => { };
            client.commands[$"{room.id}-SEND_FILE"] = (packet) => { };
            client.commands[$"{room.id}-EDIT_BANNER"] = (packet) => { };
        }
    }
}
