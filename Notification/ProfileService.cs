using System;
using System.Data;

namespace ChattingAppTeam6.Notification
{
    internal static class ProfileService
    {
        // Fetch nickname from profile table by profile id
        public static string GetNickname(int profileId)
        {
            try
            {
                var db = DBconnector.DBConnector.GetInstance();
                // Assumes connection string has been set during app init
                string sql = $"SELECT nickname FROM profile WHERE id = {profileId} LIMIT 1";
                var dt = db.Query(sql);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToString(dt.Rows[0]["nickname"]) ?? string.Empty;
                }
            }
            catch
            {
                // ignore and fallback
            }
            return string.Empty;
        }
    }
}
