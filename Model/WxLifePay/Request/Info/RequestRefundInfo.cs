using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request.Info
{
    /// <summary>
    /// 冲正接口消息体
    /// </summary>
    public class RequestRefundInfo : BaseInfo
    {
        /// <summary>
        /// 缴费单流水号
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get;set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }
    }
}
