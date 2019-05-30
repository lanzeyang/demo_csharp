using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request.Info
{
    /// <summary>
    /// 销帐结果查询消息体
    /// </summary>
    public class RequestConfirmInfo : BaseInfo
    {
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 缴费单流水号
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// 应缴金额，单位：分
        /// </summary>
        [XmlElement("pay_amount")]
        public int PayAmount { get; set; } 
    }
}
