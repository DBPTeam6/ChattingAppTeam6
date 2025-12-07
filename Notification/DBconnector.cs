using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Notification
{
    internal class DBconnector
    {
        internal class DBConnector
        {
            private static DBConnector instance = new DBConnector();
            public string login_id = "";

            private string connection_string = "";

            private DBConnector() { }

            static DBConnector()
            {
                // Initialize default connection string for notifications
                try
                {
                    instance.SetConnectString(
                        "223.130.151.111",
                        "3306",
                        "s5819937",
                        "s5819937",
                        "s5819937"
                    );
                }
                catch { }
            }

            public static DBConnector GetInstance() { return instance; }

            public void SetConnectString(string server, string port, string database, string user_id, string password)
            {
                connection_string = $"Server={server};Port={port};Database={database};User id={user_id};Password={password};";
            }

            public DataTable Query(string query)
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }

            // INSERT / UPDATE / DELETE용
            public int ExecuteNonQuery(string query)
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteNonQuery();
                }
            }

            // 단일 값(예: MAX, COUNT, LAST_INSERT_ID 등) 가져올 때
            public object ExecuteScalar(string query)
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
