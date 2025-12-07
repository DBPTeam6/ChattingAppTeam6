using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ChattingAppTeam6.Chat.Lib
{
    // MySqlParameter 배열을 빌드하는 유틸리티 클래스
    public class ParameterBuilder
    {
        private readonly List<MySqlParameter> parameters = new
       List<MySqlParameter>();
        public ParameterBuilder() { }
        public ParameterBuilder Add(string name, object value)
        {
            parameters.Add(new MySqlParameter(name, value));
            return this;
        }
        public MySqlParameter[] Build()
        {
            return parameters.ToArray();
        }
    }
}