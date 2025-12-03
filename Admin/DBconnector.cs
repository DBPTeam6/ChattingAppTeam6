using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace ChattingAppTeam6.Admin
{
    internal class DBconnector
    {
        internal class DBConnector
        {
            private static DBConnector instance = new DBConnector();
            public string login_id = "";

            private string connection_string = "";

            private DBConnector() { }

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
