using demo_csharp.Workers.IWorkService;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Text;

namespace demo_csharp.Workers
{
    //同步微信粉丝列表
    public class SyncWechatFansWorker : Wechat, IMasterWorker
    {
        public void Do()
        {
            string nextOpenId = QueryLastestOpenId();
            if (string.IsNullOrEmpty(nextOpenId))
            {
                nextOpenId = "start";
            }

            while (!nextOpenId.Equals(string.Empty))
            {
                if (nextOpenId.Equals("start"))
                {
                    nextOpenId = string.Empty;
                }

                string requestApi = string.Format(GET_FANS_LIST_API, FetchAccessToken(), nextOpenId);
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
            sqlCommand.Append("INSERT INTO ").Append(TABLE_NAME).Append("(OpenId) VALUES");
            for (int index = startIndex; index < startIndex + length; index++)
            {
                sqlCommand.Append("('").Append(openIdArray[index].ToString()).Append("'),");
            }
            Console.WriteLine(sqlCommand.ToString().Trim(','));
            sqlHelper.Insert(sqlCommand.ToString().Trim(','));
        }       

        private string QueryLastestOpenId()
        {
            StringBuilder sqlCommand = new StringBuilder(100);
            sqlCommand.Append("SELECT TOP 1 OpenId FROM ").Append(TABLE_NAME).Append(" ORDER BY Id DESC");

            DataSet queryDataSet = sqlHelper.Query(sqlCommand.ToString());

            if (null == queryDataSet || null == queryDataSet.Tables || queryDataSet.Tables.Count.Equals(0) || queryDataSet.Tables[0].Rows.Count.Equals(0))
            {
                return string.Empty;
            }

            return queryDataSet.Tables[0].Rows[0]["OpenId"].ToString();
        }
    }
}
