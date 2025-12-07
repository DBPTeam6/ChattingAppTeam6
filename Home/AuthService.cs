using System;
using System.Data;
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
        public int? CurrentUserId { get; private set; }
        public string CurrentUserName { get; private set; }
        public string CurrentUserNickname { get; private set; }
        public byte[] CurrentUserImageBytes { get; private set; }   

        /// <summary>
        /// DI용으로 DBconnector 주입.
        /// </summary>
        public AuthService(DBconnector db)
        {
            _db = db;
        }

        // 로그인 시돈데 이거 새빈이 쪽에서 아이디 받아오는걸로 바꿔야됨
        public bool Login(string loginId, string loginPw, out string error)
        {
            error = null;

            var dt = _db.Query(@"
                SELECT 
                    u.id, 
                    u.name, 
                    p.nickname, 
                    p.image
                FROM s5819937.`user` u
                LEFT JOIN s5819937.profile p 
                    ON p.user_id = u.id
                    AND p.is_default = 1
                WHERE u.login_id = @loginId
                  AND u.login_pw = @loginPw
                LIMIT 1;
            ",
                ("@loginId", loginId),
                ("@loginPw", loginPw)
            );

            // 일치하는 계정 없으면 로그인 실패
            if (dt.Rows.Count == 0)
            {
                error = "아이디 또는 비밀번호가 올바르지 않습니다.";
                return false;
            }

            // 한 명만 나온다고 가정
            var row = dt.Rows[0];

            CurrentUserId = Convert.ToInt32(row["id"]);
            CurrentUserName = Convert.ToString(row["name"]) ?? string.Empty;

            // 기본 프로필이 없을 수도 있으니 null 체크
            CurrentUserNickname = row.IsNull("nickname")
                ? null
                : Convert.ToString(row["nickname"]);

            CurrentUserImageBytes = row.IsNull("image")
                ? null
                : (byte[])row["image"];

            // 로그인 시간 저장하고 싶으면 여기에 UPDATE 추가
            // _db.ExecuteNonQuery(
            //     "UPDATE s5819937.`user` SET login_time = NOW() WHERE id = @uid;",
            //     ("@uid", CurrentUserId.Value)
            // );

            return true;
        }

        /// <summary>
        /// 현재 로그인 상태 정리 + 필요하면 로그아웃 기록 남기는 용도.
        /// </summary>
        public void Logout()
        {
            if (!CurrentUserId.HasValue)
            {
                // 로그아웃 시간 저장하고 싶으면 사용
                // _db.ExecuteNonQuery(
                //     "UPDATE s5819937.`user` SET logout_time = NOW() WHERE id = @uid;",
                //     ("@uid", CurrentUserId.Value)
                // );
            }

            // 메모리 텅
            CurrentUserId = null;
            CurrentUserName = null;
            CurrentUserNickname = null;
            CurrentUserImageBytes = null;
        }

        /// <summary>
        /// 로그인 되어 있으면 true.
        /// </summary>
        public bool IsAuthenticated => CurrentUserId.HasValue;
    }
}