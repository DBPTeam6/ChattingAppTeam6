using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ChattingAppTeam6.Home
{
    public sealed class DBconnector
    {
        private static readonly Lazy<DBconnector> _inst = new Lazy<DBconnector>(() => new DBconnector());
        public static DBconnector GetInstance() => _inst.Value;

        private DBconnector() { }

        private string _connectionString;

        public void InitServer(string host, int port, string database, string username, string password)
        {
            var csb = new MySqlConnectionStringBuilder
            {
                Server = host,
                Port = (uint)port,
                Database = database,
                UserID = username,
                Password = password,
                CharacterSet = "utf8mb4",
                ConnectionTimeout = 5,
                SslMode = MySqlSslMode.Preferred,
                AllowPublicKeyRetrieval = true
            };
            _connectionString = csb.ConnectionString;
        }

        private MySqlConnection CreateConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new InvalidOperationException("DBconnector가 초기화되지 않았습니다. InitServer를 먼저 호출하세요.");
            return new MySqlConnection(_connectionString);
        }

        public bool ConnectionTest()
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("SELECT 1;", conn))
                    {
                        _ = cmd.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable Query(string sql, params (string name, object value)[] parameters)
        {
            using (var conn = CreateConnection())
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                    }

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public object ExecuteScalar(string sql, params (string name, object value)[] parameters)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        public int ExecuteNonQuery(string sql, params (string name, object value)[] parameters)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}