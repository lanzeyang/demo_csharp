using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request.Info
{
    /// <summary>
    /// 销账请求消息体
    /// </summary>
    public class RequestChargeInfo : BaseInfo
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
        public string TransactionId { get; set; }

        /// <summary>
        /// 缴费单支付日期
        /// </summary>
        [XmlElement("pay_date")]
        public string PayDate { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [XmlElement("customer_name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 应缴金额，单位：分
        /// </summary>
        [XmlElement("pay_amount")]
        public int PayAmount { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 账期字段
        /// </summary>
        [XmlElement("bill_month")]
        public string BillMonth { get; set; }
    }
}
