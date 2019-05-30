using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Generic
{
    /// <summary>
    /// 消息头
    /// </summary>
    public class BaseHead
    {
        /// <summary>
        /// 版本号
        /// </summary>
        [XmlElement("version")]
        public string Version { get; set; }

        /// <summary>
        /// 交易码
        /// </summary>
        [XmlElement("trancode")]
        public string TranCode { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("transeqnum")]
        public string TranSeqNum { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [XmlElement("merchantid")]
        public string MerchantId { get; set; }
    }
}
