using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Text;

namespace Common.SequenceRepository
{
    public class SequenceRepository
    {
        private static string WECHAT_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["sh3hWeChat"].ConnectionString;

        public string GetNext(string sequenceName)
        {
            StringBuilder sqlCommand = new StringBuilder(100);
            sqlCommand.Append("SELECT NEXT VALUE FOR ").Append(sequenceName);

            Object nextSequence = SqlHelper.ExecuteScalar(WECHAT_CONNECTION_STRING, CommandType.Text, sqlCommand.ToString());

            return nextSequence.ToString();
        }
    }
}
