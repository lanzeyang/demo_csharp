using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;

namespace Common
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public sealed class MySqlHelper
    {
        private static MySqlHelper instance = null;
        private static readonly object lockHelper = new object();
        private static string CSM_BM = ConfigurationManager.ConnectionStrings["PrimaryConnectionString"].ToString();

        private MySqlHelper() { }

        public static MySqlHelper CreateInstance()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new MySqlHelper();
                    }
                }
            }

            return instance;
        }

        public int Insert(string sql)
        {
            return SqlHelper.ExecuteNonQuery(CSM_BM, CommandType.Text, sql);
        }

        public int Update(string sql)
        {
            return SqlHelper.ExecuteNonQuery(CSM_BM, CommandType.Text, sql);
        }

        public DataSet Query(string sql)
        {
            return SqlHelper.ExecuteDataset(CSM_BM, CommandType.Text, sql);
        }
    }
}
