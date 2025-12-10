using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Chat.Entity
{
    public class ChatUser
    {
        public readonly int profile_id; // profile id
        public readonly int user_id; // user id
        public readonly string nickname;
        public readonly byte[] profileImageBytes;

        public ChatUser(int id, int user, string nickname, byte[] profileImageBytes)
        {
            this.profile_id = id;
            this.user_id = user;
            this.nickname = nickname;
            this.profileImageBytes = profileImageBytes;
        }

        public static ChatUser FromTable(DataTable table)
        {
            return new ChatUser(
                id: Convert.ToInt32(table.Rows[0]["id"]),
                user: Convert.ToInt32(table.Rows[0]["user_id"]),
                nickname: Convert.ToString(table.Rows[0]["nickname"]),
                profileImageBytes: table.Rows[0]["image"] == DBNull.Value ? new byte[] { } : (byte[])table.Rows[0]["image"]
            );
        }
    }
}
