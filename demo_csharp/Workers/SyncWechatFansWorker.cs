using Common;
using Common.HttpHelper;
using demo_csharp.Workers.IWorkService;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Text;

namespace demo_csharp.Workers
{
    //同步微信粉丝列表
    public class SyncWechatFansWorker : IMasterWorker
    {
        private static string ACCESS_TOKEN = ConfigurationManager.AppSettings["AccessToken"];
        private const string GET_FANS_LIST_API = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
        private static HttpHelper httpHelper = HttpHelper.CreateInstance();
        private static MySqlHelper sqlHelper = MySqlHelper.CreateInstance();
        private const string tableName = "WECHAT_FANS";

        public void Do()
        {
            string nextOpenId = "start";
            while (!nextOpenId.Equals(string.Empty))
            {
                if (nextOpenId.Equals("start"))
                {
                    nextOpenId = string.Empty;
                }

                string requestApi = string.Format(GET_FANS_LIST_API, ACCESS_TOKEN, nextOpenId);
                byte[] byteResult = httpHelper.DoGetByte(requestApi).Result;
                string stringResult = Encoding.UTF8.GetString(byteResult);

                //数据
                JToken fansListObject = JToken.Parse(stringResult);
                //总粉丝数
                Console.WriteLine(fansListObject["total"]);
                //本次拉取的数量
                int count = Int32.Parse(fansListObject["count"].ToString());

                if (count.Equals(0))
                {
                    break;
                }

                //Next Open Id
                nextOpenId = fansListObject["next_openid"].ToString();

                JToken dataToken = fansListObject["data"];
                JArray openIdArray = (JArray)dataToken["openid"];

                int stepSize = 500;
                if (openIdArray.Count < stepSize)
                {
                    AddData(openIdArray, 0, openIdArray.Count);
                }
                else
                {
                    int steps = openIdArray.Count / stepSize;
                    int tailCount = openIdArray.Count % stepSize;

                    for (int index = 0; index < steps; index++)
                    {
                        AddData(openIdArray, index * stepSize, stepSize);
                    }

                    if (tailCount > 0)
                    {
                        AddData(openIdArray, steps * stepSize, tailCount);
                    }
                }
            }
        }

        private void AddData(JArray openIdArray, int startIndex, int length)
        {
            StringBuilder sqlCommand = new StringBuilder(500);
            sqlCommand.Append("INSERT INTO ").Append(tableName).Append("(OpenId) VALUES");
            for (int index = startIndex; index < startIndex + length; index++)
            {
                sqlCommand.Append("('").Append(openIdArray[index].ToString()).Append("'),");
            }
            Console.WriteLine(sqlCommand.ToString().Trim(','));
            sqlHelper.Insert(sqlCommand.ToString().Trim(','));
        }
    }
}
