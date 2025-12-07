using System;
using System.Data;

namespace ChattingAppTeam6.Home.Service
{
    public class ProfileService
    {
        private readonly DBconnector _db;

        public ProfileService(DBconnector db)
        {
            _db = db;
        }

        public DataRow GetVisibleProfileFor(int meId, int otherUserId)
        {
            // 딴놈이 로그인 유저한테 뭔 프로필 보여주는지 확인
            var pa = _db.Query(@"
        SELECT profile_id
        FROM profile_access
        WHERE user_id = @owner       -- 프로필 주인
          AND target_user_id = @viewer  -- 보는 사람(나)
        LIMIT 1;
    ",
                ("@owner", otherUserId),
                ("@viewer", meId)
            );

            int? profileId = null;
            if (pa.Rows.Count > 0)
            {
                profileId = Convert.ToInt32(pa.Rows[0]["profile_id"]);
            }

            DataTable pdt;

            if (profileId.HasValue)
            {
                // 멀프 불러옴
                pdt = _db.Query(@"
            SELECT id, user_id, nickname, image, is_default
            FROM profile
            WHERE id = @pid
            LIMIT 1;
        ", ("@pid", profileId.Value));
            }
            else
            {
                // 멀프 업으면 그냥 기본프ㅗ필 가져옴
                pdt = _db.Query(@"
            SELECT id, user_id, nickname, image, is_default
            FROM profile
            WHERE user_id = @uid
              AND is_default = 1
            LIMIT 1;
        ", ("@uid", otherUserId));
            }

            if (pdt.Rows.Count == 0)
                return null;

            return pdt.Rows[0];
        }
    }
}