﻿using Common;
using demo_csharp.Workers.IWorkService;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Text;

namespace demo_csharp.Workers
{
    //读取微信粉丝的JSON格式详情并更新至数据库
    public class AnalyseWechatFansAndUpdateWorker : IMasterWorker
    {
        private static MySqlHelper sqlHelper = MySqlHelper.CreateInstance();
        private const string tableName = "WECHAT_FANS";

        public void Do()
        {
            /* --可以通过SQL实现 （有版本限制）
              UPDATE [CSM_BM_REPORT].[dbo].[WECHAT_FANS]
              SET NICKNAME = JSON_VALUE([FansDetail], '$.nickname'),
              SEX = JSON_VALUE([FansDetail], '$.sex'),
              language = JSON_VALUE([FansDetail], '$.language'),
              city = JSON_VALUE([FansDetail], '$.city'),
              province =  JSON_VALUE([FansDetail], '$.province'),
              country = JSON_VALUE([FansDetail], '$.country'),
              HEAD_IMG_URL = JSON_VALUE([FansDetail], '$.headimgurl'),
              subscribe_time =   DATEADD(SECOND, CAST(JSON_VALUE([FansDetail], '$.subscribe_time') AS INT), '1970-01-01'),
              UpdateTime = GETDATE()
              WHERE NICKNAME IS NULL 
            */

            bool dataProcessed = false;
            while (!dataProcessed)
            {
                StringBuilder queryCommand = new StringBuilder(100);
                queryCommand.Append("SELECT TOP 200 FansDetail FROM WECHAT_FANS WHERE NICKNAME IS NULL ORDER BY ID ASC");

                DataSet fansDetails = sqlHelper.Query(queryCommand.ToString());
                if (null == fansDetails || null == fansDetails.Tables || fansDetails.Tables.Count.Equals(0))
                {
                    dataProcessed = true;
                    Console.WriteLine("processed!");
                    break;
                }

                StringBuilder updateCommand = new StringBuilder(100);
                for (int index = 0; index < fansDetails.Tables[0].Rows.Count; index++)
                {
                    JToken fansDetail = JToken.Parse(fansDetails.Tables[0].Rows[index]["FansDetail"].ToString());

                    Console.WriteLine(fansDetails.Tables[0].Rows[index]["FansDetail"].ToString());

                    string openId = fansDetail["openid"].ToString();
                    string subscribe = fansDetail["subscribe"].ToString();

                    if (subscribe.Equals("0"))
                    {
                        updateCommand.Append("UPDATE WECHAT_FANS SET NICKNAME = '' ");
                        updateCommand.Append("WHERE OPENID = '").Append(openId).Append("' ");
                        continue;
                    }

                    string nickName = fansDetail["nickname"].ToString();
                    string sex = fansDetail["sex"].ToString();
                    string language = fansDetail["language"].ToString();
                    string city = fansDetail["city"].ToString();
                    string province = fansDetail["province"].ToString();
                    string country = fansDetail["country"].ToString();
                    string headimgurl = fansDetail["headimgurl"].ToString();
                    string subscribeTimeString = fansDetail["subscribe_time"].ToString();

                    DateTime subscribeTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    subscribeTime = subscribeTime.AddSeconds(Double.Parse(subscribeTimeString));

                    updateCommand.Append("UPDATE WECHAT_FANS SET NICKNAME = '").Append(nickName.Replace("'", "''")).Append("',");
                    updateCommand.Append("SEX = '").Append(sex).Append("',");
                    updateCommand.Append("CITY = '").Append(city).Append("',");
                    updateCommand.Append("PROVINCE = '").Append(province).Append("',");
                    updateCommand.Append("COUNTRY = '").Append(country).Append("',");
                    updateCommand.Append("LANGUAGE = '").Append(language).Append("',");
                    updateCommand.Append("HEAD_IMG_URL = '").Append(headimgurl).Append("',");
                    updateCommand.Append("UpdateTime = GETDATE(),");
                    updateCommand.Append("SUBSCRIBE_TIME = '").Append(subscribeTime.ToString("yyyy-MM-dd HH:mm:ss")).Append("' ");
                    updateCommand.Append("WHERE OPENID = '").Append(openId).Append("' ");
                }

                Console.WriteLine(updateCommand.ToString());

                sqlHelper.Update(updateCommand.ToString());
            }
        }
    }
}
