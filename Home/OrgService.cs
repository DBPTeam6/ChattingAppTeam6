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


        // 전체부서 불러오기(없어도됨)
        public DataTable GetDepartments()
        {
            return _db.Query("SELECT id, name FROM department ORDER BY name;");
        }

        // 전체팀 불러오기(없어도됨)
        public DataTable GetTeams()
        {
            return _db.Query("SELECT id, department_id, name FROM team ORDER BY name;");
        }

        // 검색기능에 숨김처리도 같이
        public DataTable SearchMembers(int currentUserId, string keyword)
        {
            // 검색결과 가져옴
            var result = SearchMembersRaw(keyword);

            // 지금 유저 기준 가려진 멤버 로드
            var (hiddenDeptIds, hiddenUserIds) = LoadHiddenRelations(currentUserId);

            // 적용 후 필터링
            return ApplyHiddenFilters(result, hiddenDeptIds, hiddenUserIds);
        }

        private DataTable SearchMembersRaw(string keyword)
        {
            return _db.Query(@"
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
                ORDER BY d.name, t.name, u.name;
            ", ("@kw", keyword));
        }

        private (HashSet<int> hiddenDeptIds, HashSet<int> hiddenUserIds)
            LoadHiddenRelations(int currentUserId)
        {
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

            return (hiddenDeptIds, hiddenUserIds);
        }

        private DataTable ApplyHiddenFilters(
            DataTable result,
            HashSet<int> hiddenDeptIds,
            HashSet<int> hiddenUserIds)
        {
            var filtered = result.Clone(); 

            foreach (DataRow r in result.Rows)
            {
                int deptId = r.IsNull("dept_id") ? -1 : Convert.ToInt32(r["dept_id"]);
                int userId = r.IsNull("user_id") ? -1 : Convert.ToInt32(r["user_id"]);

                // 부서숨김
                if (deptId != -1 && hiddenDeptIds.Contains(deptId))
                    continue;

                // 유저숨김
                if (userId != -1 && hiddenUserIds.Contains(userId))
                    continue;

                filtered.ImportRow(r);
            }

            return filtered;
        }
    }
}