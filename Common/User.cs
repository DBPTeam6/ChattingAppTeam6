using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingAppTeam6.Common
{
    public record User
    {
        public readonly int id;
        public readonly int teamId;
        public readonly string name;
        public readonly Profile defaultProfile;

        public User(int id, int teamId, string name, Profile defaultProfile)
        {
            this.id = id;
            this.teamId = teamId;
            this.name = name;
            this.defaultProfile = defaultProfile;
        }
    }
}
