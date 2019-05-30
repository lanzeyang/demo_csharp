using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response.Info
{
    public class ResponseConfirmInfo : BaseInfo
    {
        /// <summary>
        /// 查询返回码
        /// </summary>
        [XmlElement("ret_code")]
        public string RetCode { get; set; }

        /// <summary>
        /// 返回提示信息
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 缴费单流水号
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// 缴费单支付日期，与发起缴费接口传入一致
        /// </summary>
        [XmlElement("pay_date")]
        public string PayDate { get; set; }

        /// <summary>
        /// 应缴金额，与发起缴费接口传入一致
        /// </summary>
        [XmlElement("pay_amount")]
        public int PayAmount { get; set; }

        /// <summary>
        /// 缴费机构缴费单号
        /// </summary>
        [XmlElement("channel_bill_no")]
        public string ChannelBillNo { get; set; }
    }
}
