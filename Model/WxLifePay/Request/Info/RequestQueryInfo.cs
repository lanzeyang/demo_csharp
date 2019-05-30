using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request.Info
{
    /// <summary>
    /// 查询缴费单信息，消息体
    /// </summary>
    public class RequestQueryInfo : BaseInfo
    {
        /// <summary>
        /// 起始笔数
        /// </summary>
        [XmlElement("begin_num")]
        public string BeginNum { get; set; }

        /// <summary>
        /// 查询笔数
        /// </summary>
        [XmlElement("query_num")]
        public string QueryNum { get; set; }
    }
}
