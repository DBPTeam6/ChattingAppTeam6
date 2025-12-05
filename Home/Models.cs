using System;

namespace ChattingAppTeam6.Home.Models
{
    internal class Models
    {
    }

    public class ChatListItem
    {
        // 채팅방/대화 ID
        public int ChatId { get; set; }

        // 상대방 유저 ID
        public int OtherUserId { get; set; }

        // 원래이름
        public string OriginalUserName { get; set; }

        // 화면표시 이름
        public string DisplayName { get; set; } = "";

        // 프로필 이미지 바이트
        public byte[] ProfileImageBytes { get; set; }

        // 마지막 메시지 내용
        public string LastMessage { get; set; } = "";

        // 마지막 대화 시각
        public DateTime? LastChatTime { get; set; }

        // 상대방 프로필 이미지
        public byte[] AvatarBytes { get; set; }
    }
}