using SH3H.BM.Model.WxLifePay.Generic;
using SH3H.BM.Model.WxLifePay.Response.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    /// <summary>
    /// 销账结果查询响应类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class ResponseConfirmModel
    {
        /// <summary>
        /// 消息头
        /// </summary>
        [XmlElement("head")]
        public BaseHead Head { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [XmlElement("info")]
        public ResponseConfirmInfo Info { get; set; }
    }
}
