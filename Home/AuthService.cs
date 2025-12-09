using System;
using System.Data;
using ChattingAppTeam6.Common;
using ChattingAppTeam6.Home;

namespace ChattingAppTeam6.Home
{
    /// <summary>
    /// 로그인 / 로그아웃 상태를 관리하는 서비스
    /// </summary>
    public class AuthService
    {
        private readonly DBconnector _db;

        // 현재 로그인한 사용자 정보 
        public User? CurrentUser { get; private set; }

        /// <summary>
        /// DI용으로 DBconnector 주입.
        /// </summary>
        public AuthService(DBconnector db)
        {
            _db = db;
        }

        public void Login(int userId)
        {
            var user = _db.Query(@"
                SELECT id, name, team_id
                FROM `user`
                WHERE id = @id
                LIMIT 1;", 
                ("@id", userId));

            var profile = _db.Query(@"
                SELECT *
                FROM profile
                WHERE user_id = @id AND is_default = 1
                LIMIT 1;",
                ("@id", userId));

            if (user.Rows.Count == 0)
                return;

            CurrentUser = new User(
                Convert.ToInt32(user.Rows[0]["id"]),
                Convert.ToInt32(user.Rows[0]["team_id"]),
                (string)user.Rows[0]["name"],
                new Profile(
                    Convert.ToInt32(profile.Rows[0]["id"]),
                    Convert.ToInt32(profile.Rows[0]["user_id"]),
                    (string)profile.Rows[0]["nickname"],
                    profile.Rows[0]["image"] == DBNull.Value ? null : (byte[])profile.Rows[0]["image"],
                    (int)profile.Rows[0]["is_default"] == 1)
                );
        }

        /// <summary>
        /// 현재 로그인 상태 정리 + 필요하면 로그아웃 기록 남기는 용도.
        /// </summary>
        public void Logout()
        {
            // 메모리 텅
            CurrentUser = null;
        }

        /// <summary>
        /// 로그인 되어 있으면 true.
        /// </summary>
        public bool IsAuthenticated => CurrentUser != null;
    }
}