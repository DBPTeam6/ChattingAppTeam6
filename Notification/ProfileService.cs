using System;
using System.Data;
using System.Drawing;

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

        // Fetch profile image from profile table by profile id
        public static Image GetProfileImage(int profileId)
        {
            try
            {
                var db = DBconnector.DBConnector.GetInstance();
                string sql = $"SELECT image FROM profile WHERE id = {profileId} LIMIT 1";
                var dt = db.Query(sql);
                if (dt.Rows.Count > 0 && dt.Rows[0]["image"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])dt.Rows[0]["image"];
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        return ChattingAppTeam6.Home.Utils.ImageUtils.BytesToImage(imageBytes);
                    }
                }
            }
            catch
            {
                // ignore and fallback
            }
            return null;
        }
    }
}
