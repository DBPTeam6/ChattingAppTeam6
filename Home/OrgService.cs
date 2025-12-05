using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ChattingAppTeam6.Home;

namespace ChattingAppTeam6.Home.Service
{
    // DB 조회
    public class OrgService
    {
        private readonly DBconnector _db;

        public OrgService(DBconnector db)
        {
            _db = db;
        }

        // 전체 부서
        public DataTable GetDepartments()
        {
            return _db.Query("SELECT id, name FROM department ORDER BY name;");
        }

        // 전체 팀
        public DataTable GetTeams()
        {
            return _db.Query("SELECT id, department_id, name FROM team ORDER BY name;");
        }

        // 부서/팀/사용자 이름 기준으로 멤버 검색
        public DataTable SearchMembers(int currentUserId, string keyword)
        {
            // 일단 다 검색
            var result = _db.Query(@"
                SELECT 
                    t.id AS team_id,
                    t.name AS team_name,
                    d.id AS dept_id,
                    d.name AS dept_name,
                    u.id AS user_id,
                    u.name AS user_name
                FROM team t
                JOIN department d ON d.id = t.department_id
                LEFT JOIN `user` u 
                       ON u.team_id = t.id
                WHERE (t.name LIKE CONCAT('%', @kw, '%')
                    OR d.name LIKE CONCAT('%', @kw, '%')
                    OR u.name LIKE CONCAT('%', @kw, '%'))
                ORDER BY d.name, t.name, u.name;",
                ("@kw", keyword)
            );

            // 현재 유저 기준 숨겨진 부서나 유저 찾기
            var hiddenDeptIds = new HashSet<int>();
            var hiddenUserIds = new HashSet<int>();

            var relDt = _db.Query(@"
                SELECT target_user_id, relation_type
                FROM user_relation
                WHERE user_id = @uid
                  AND relation_type IN ('HIDE_DEPT', 'HIDE_USER');
            ", ("@uid", currentUserId));

            foreach (DataRow row in relDt.Rows)
            {
                string relType = Convert.ToString(row["relation_type"]);
                int targetId = Convert.ToInt32(row["target_user_id"]);

                if (relType == "HIDE_DEPT")
                    hiddenDeptIds.Add(targetId);
                else if (relType == "HIDE_USER")
                    hiddenUserIds.Add(targetId);
            }

            // 숨김 처리된거 빼고
            var filtered = result.Clone();

            foreach (DataRow r in result.Rows)
            {
                int deptId = r.IsNull("dept_id") ? -1 : Convert.ToInt32(r["dept_id"]);
                int userId = r.IsNull("user_id") ? -1 : Convert.ToInt32(r["user_id"]);

                // HIDE_DEPT: 부서 전체 숨김
                if (deptId != -1 && hiddenDeptIds.Contains(deptId))
                    continue;

                // HIDE_USER: 특정 유저 숨김
                if (userId != -1 && hiddenUserIds.Contains(userId))
                    continue;

                filtered.ImportRow(r);
            }

            return filtered;
        }
    }
}