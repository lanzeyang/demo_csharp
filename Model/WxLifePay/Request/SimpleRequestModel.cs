using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 用于预处理读取交易码使用
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class SimpleRequestModel
    {
        /// <summary>
        /// 消息头
        /// </summary>
        [XmlElement("head")]
        public BaseHead Head { get; set; }
    }
}
