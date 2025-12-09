using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Common
{
    public record Profile
    {
        public readonly int id;
        public readonly int userId;
        public readonly string nickname;
        public readonly byte[]? image;
        public readonly bool isDefault;

        public Profile(int id, int userId, string nickname, byte[]? image, bool isDefault)
        {
            this.id = id;
            this.userId = userId;
            this.nickname = nickname;
            this.image = image;
            this.isDefault = isDefault;
        }
    }
}
