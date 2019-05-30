using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 请求参数基础类
    /// </summary>
    public class RequestBaseModel
    {
        /// <summary>
        /// 消息头
        /// </summary>
        [XmlElement("head")]
        public BaseHead Head { get; set; }
    }
}
