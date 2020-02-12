using Common;
using Common.HttpHelper;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Text;

namespace demo_csharp
{
    public class Wechat
    {
        #region Configs

        protected static string APPID = ConfigurationManager.AppSettings["APPID"];
        protected static string APP_SECRECT = ConfigurationManager.AppSettings["APP_SECRECT"];
        protected static string ACCESS_TOKEN = ConfigurationManager.AppSettings["AccessToken"];

        #endregion

        #region Fields
        protected const string FETCH_ACCESS_TOKEN_URI = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        protected const string GET_FANS_LIST_API = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
        protected const string GET_FANS_DETAIL_API = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
        protected const string BATCH_GET_FANS_DETAIL_API = "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}";

        protected const string TABLE_NAME = "WECHAT_FANS";

        protected static HttpHelper httpHelper = HttpHelper.CreateInstance();
        protected static MySqlHelper sqlHelper = MySqlHelper.CreateInstance();

        protected string FetchAccessToken()
        {
            byte[] fetchedByte = httpHelper.DoGetByte(string.Format(FETCH_ACCESS_TOKEN_URI, APPID, APP_SECRECT)).Result;
            string stringResult = Encoding.UTF8.GetString(fetchedByte);

            JToken accessTokenJson = JToken.Parse(stringResult);

            string accessToken = string.Empty;
            JToken token = accessTokenJson["access_token"];
            if (null != token)
            {
                accessToken = token.ToString();
            }

            if (string.IsNullOrEmpty(accessToken))
            {
                accessToken = ACCESS_TOKEN;
            }

            return accessToken;
        }

        #endregion
    }
}
