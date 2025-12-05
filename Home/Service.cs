using System;
using System.Collections.Generic;
using System.Data;
using ChattingAppTeam6.Home.Models;

namespace ChattingAppTeam6.Home.Service
{
    public class ChatService
    {
        private readonly DBconnector _db;

        public ChatService(DBconnector db)
        {
            _db = db;
        }

        // 채팅목록 불러오기(함수중복가능;;)
        public List<ChatListItem> LoadMyChats(int meId)
        {
            string sql = @"
        SELECT
            c.id AS chat_id,
            c.name AS chat_name,
            c.profile_id_1,
            c.profile_id_2,
            c.last_chat_time,
            c.last_chat_content,
            CASE
                WHEN c.profile_id_1 = @meId THEN c.profile_id_2
                ELSE c.profile_id_1
            END AS other_user_id,
            u.name AS other_user_name
        FROM chat c
        JOIN `user` u
            ON u.id = CASE
                WHEN c.profile_id_1 = @meId THEN c.profile_id_2
                ELSE c.profile_id_1
            END
        WHERE c.profile_id_1 = @meId OR c.profile_id_2 = @meId
        ORDER BY c.last_chat_time DESC;
    ";

            var dt = _db.Query(sql, ("@meId", meId));
            var list = new List<ChatListItem>();

            foreach (DataRow row in dt.Rows)
            {
                var item = new ChatListItem
                {
                    ChatId = Convert.ToInt32(row["chat_id"]),
                    OtherUserId = Convert.ToInt32(row["other_user_id"]),

                    OriginalUserName = Convert.ToString(row["other_user_name"]) ?? "",
                    DisplayName = null,
                    ProfileImageBytes = null,
                    AvatarBytes = null,

                    LastMessage = Convert.ToString(row["last_chat_content"]) ?? "",
                    LastChatTime = row["last_chat_time"] == DBNull.Value
                        ? (DateTime?)null
                        : Convert.ToDateTime(row["last_chat_time"])
                };

                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// 두 사용자(meId, otherUserId) 간의 1:1 채팅방을 가져오거나,
        /// 없으면 새로 생성한 뒤 그 레코드를 DataRow로 반환한다.
        /// </summary>
        public DataRow GetOrCreateOneToOneChat(int meId, int otherUserId)
        {
            // 채팅방이 이미 잇는가?
            string selectSql = @"
                SELECT *
                FROM chat
                WHERE (profile_id_1 = @u1 AND profile_id_2 = @u2)
                   OR (profile_id_1 = @u2 AND profile_id_2 = @u1)
                LIMIT 1;
            ";

            var dt = _db.Query(selectSql,
                ("@u1", meId),
                ("@u2", otherUserId)
            );

            if (dt.Rows.Count > 0)
            {
                // 채팅방 이미 잇으    
                return dt.Rows[0];
            }

            // 업으면 뉴 채팅방 생성
            // 방 이름 일단 걍 대충함
            string roomName = $"채팅 ({meId}, {otherUserId})";

            string insertSql = @"
                INSERT INTO chat (name, profile_id_1, profile_id_2, last_chat_time, last_chat_content)
                VALUES (@name, @u1, @u2, NOW(), '');
            ";

            _db.ExecuteNonQuery(insertSql,
                ("@name", roomName),
                ("@u1", meId),
                ("@u2", otherUserId)
            );

            // 방금만든 채팅방 반환
            var dtNew = _db.Query(selectSql,
                ("@u1", meId),
                ("@u2", otherUserId)
            );

            if (dtNew.Rows.Count == 0)
            {
                return null; 
            }

            return dtNew.Rows[0];
        }
    }
}