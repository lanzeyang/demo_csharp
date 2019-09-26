using Common;
using Common.HttpHelper;
using demo_csharp.Workers.IWorkService;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace demo_csharp.Workers
{
    //获取微信粉丝的明细数据
    public class SyncWechatFansDetailWorker : IMasterWorker
    {
        private static string ACCESS_TOKEN = ConfigurationManager.AppSettings["AccessToken"];
        private const string GET_FANS_DETAIL_API = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
        private const string BATCH_GET_FANS_DETAIL_API = "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}";
        private static HttpHelper httpHelper = HttpHelper.CreateInstance();
        private static MySqlHelper sqlHelper = MySqlHelper.CreateInstance();
        private const string tableName = "WECHAT_FANS";

        public void Do()
        {
            bool dataProcessed = false;
            while (!dataProcessed)
            {
                StringBuilder queryCommand = new StringBuilder(100);
                queryCommand.Append("SELECT TOP 100 OPENID FROM WECHAT_FANS WHERE STATE = 0 ORDER BY ID");

                DataSet openIds = sqlHelper.QueryGG(queryCommand.ToString());
                if (null == openIds || null == openIds.Tables || openIds.Tables.Count.Equals(0))
                {
                    dataProcessed = true;
                    break;
                }

                Dictionary<string, string> openId2Detail = new Dictionary<string, string>();
                JObject dataToBePosted = new JObject();

                JArray userInfos = new JArray();
                for (int index = 0; index < openIds.Tables[0].Rows.Count; index++)
                {
                    JObject userInfo = new JObject();
                    userInfo["openid"] = openIds.Tables[0].Rows[index]["OPENID"].ToString();
                    userInfo["lang"] = "zh_CN";
                    userInfos.Add(userInfo);
                }

                //参考https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140839
                dataToBePosted["user_list"] = userInfos;

                string requestApi = string.Format(BATCH_GET_FANS_DETAIL_API, ACCESS_TOKEN);
                string stringResult = httpHelper.SendPostHttpRequest(requestApi, "application/json", dataToBePosted.ToString());
                stringResult = stringResult.Replace("'", "''");

                Console.WriteLine(stringResult);
                JToken json4StringResult = JToken.Parse(stringResult);

                JArray userInfoList = (JArray)json4StringResult["user_info_list"];

                StringBuilder updateCommand = new StringBuilder(100);
                foreach (var item in userInfoList)
                {
                    updateCommand.Append("UPDATE WECHAT_FANS SET STATE = 1, UpdateTime = GETDATE(), FansDetail = '").Append(item.ToString()).Append("' WHERE OPENID = '").Append(item["openid"]).Append("' ");
                }

                sqlHelper.UpdateGG(updateCommand.ToString());

                openId2Detail.Clear();
            }
        }
    }
}
