using MySql.Data.MySqlClient;
using System.Data;

namespace ChattingAppTeam6.Chat.Lib
{
    public class DB
    {
        private static DB instance = null;
        private readonly string connStr;

        private DB(string connStr)
        {
            this.connStr = connStr;
        }

        public static DB GetInstance()
        {
            if (instance == null)
            {
                instance = new DB("Server=223.130.151.111;Port=3306;Database=s5819937;User Id=s5819937; Password=s5819937;");
            }
            return instance;
        }

        // MySqlConnection 객체를 생성하여 반환
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        // Read 쿼리를 실행 후 DataTable로 반환
        public DataTable ReadQuery(string query)
        {
            return ReadQuery(query, new MySqlParameter[] { });
        }

        // Read 쿼리를 실행 후 DataTable로 반환 (파라미터 포함)
        public DataTable ReadQuery(string query, MySqlParameter[] parameters)
        {
            var table = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                foreach (var param in parameters)
                    cmd.Parameters.Add(param);
                var reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            return table;
        }

        // Write 쿼리를 실행
        public long CreateQuery(string query, MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                foreach (var param in parameters)
                    cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
        }
    }
}
