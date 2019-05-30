using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.UrlParamHelper
{
    /// <summary>
    /// URL参数化类
    /// </summary>
    public sealed class UrlParamHelper
    {
        private UrlParamHelper() { }

        public static string ToUrl(SortedDictionary<string, string> uriParams, bool needEncode = true)
        {
            IEnumerable<string> parametrized = uriParams.Select(item => parametrization(item, needEncode));
            return string.Join(string.Empty, parametrized).Trim('&');
        }

        private static Func<KeyValuePair<string, string>, bool, string> parametrization = (keyValuePair, needEncode) =>
        {
            if (string.IsNullOrEmpty(keyValuePair.Key) || string.IsNullOrEmpty(keyValuePair.Value))
            {
                return string.Empty;
            }

            return keyValuePair.Key + "=" + (needEncode ? HttpUtility.UrlEncode(keyValuePair.Value) : keyValuePair.Value) + "&";
        };
    }
}
