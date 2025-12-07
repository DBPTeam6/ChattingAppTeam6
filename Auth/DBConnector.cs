using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChattingAppTeam6.Auth
{
    internal class DBConnector
    {
        private static DBConnector instance = new DBConnector();
        private string connectionStr = "";

        private DBConnector()
        {
            connectionStr = "Server=\"223.130.151.111\";Port=3306;Database=\"s5819937\";" +
                "User Id=\"s5819937\";Password=\"s5819937\";";
        }

        public static DBConnector GetInstance()
        {
            return instance;
        }

        public DataTable Table(string query)
        {
            using (var conn = new MySqlConnection(connectionStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                var table = new DataTable();
                table.Load(reader); // DataReader의 결과를 DataTable에 로드
                return table;
            }
        }

        public int Insert(string query)
        {
            using (var conn = new MySqlConnection(connectionStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);

                return cmd.ExecuteNonQuery(); // 실행된 행의 수 반환
            }
        }

        // INSERT / UPDATE / DELETE 실행 (파라미터 있는 경우) --- BLOB 처리
        public int Execute(string query, List<MySqlParameter> parameters)
        {
            using (var conn = new MySqlConnection(connectionStr))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 사용자 로그인 확인
        public DataTable CheckUser(string query)
        {
            return Table(query);
        }
    }
}
