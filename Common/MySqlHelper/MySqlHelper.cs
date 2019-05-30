using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;

namespace Common
{
    public sealed class MySqlHelper
    {
        private static MySqlHelper instance = null;
        private static readonly object lockHelper = new object();
        private static string DB_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["GY_CSM"].ToString();
        private static string FUSHUN_DB_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Fushun_Web"].ToString();
        private static string LOCAL = ConfigurationManager.ConnectionStrings["LOCAL_DB"].ToString();
        private static string GG = ConfigurationManager.ConnectionStrings["GG_CSM"].ToString();

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

        public DataSet Query(string sql)
        {
            return SqlHelper.ExecuteDataset(FUSHUN_DB_CONNECTION_STRING, CommandType.Text, sql);
        }

        public int Update(string sql)
        {
            return SqlHelper.ExecuteNonQuery(FUSHUN_DB_CONNECTION_STRING, CommandType.Text, sql);
        }

        public int Insert(string sql)
        {
            return SqlHelper.ExecuteNonQuery(GG, CommandType.Text, sql);
        }

        public int InsertLocal(string sql)
        {
            return SqlHelper.ExecuteNonQuery(LOCAL, CommandType.Text, sql);

        }
    }
}
