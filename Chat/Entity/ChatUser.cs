using System.Data;

namespace ChattingAppTeam6.Chat.Entity
{
    public class ChatUser
    {
        public readonly int id;
        public readonly string username;

        public ChatUser(int id, string username)
        {
            this.id = id;
            this.username = username;
        }

        public DataRow ToDataRow(DataTable table)
        {
            DataRow row = table.NewRow();
            row["Id"] = id;
            row["Username"] = username;
            return row;
        }
    }
}
