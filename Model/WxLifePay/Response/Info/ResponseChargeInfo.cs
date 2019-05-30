using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response.Info
{
    /// <summary>
    /// 销账返回类
    /// </summary>
    public class ResponseChargeInfo : BaseInfo
    {
        /// <summary>
        /// 缴费单流水号，微信生活缴费平台的业务流水号
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// YYYYMMDDHHMMSS,缴费单支付日期
        /// </summary>
        [XmlElement("pay_date")]
        public string PayDate { get; set; }

        /// <summary>
        /// 应缴金额, 单位：分
        /// </summary>
        [XmlElement("pay_amount")]
        public string PayAmount { get; set; }

        /// <summary>
        /// 缴费机构缴费单号
        /// </summary>
        [XmlElement("channel_bill_no")]
        public string ChannelBillNo { get; set; }
    }
}
