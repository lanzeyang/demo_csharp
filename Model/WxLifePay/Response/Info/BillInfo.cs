using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response.Info
{
    /// <summary>
    /// 账单明细
    /// </summary>
    public class BillInfo
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        [XmlElement("customer_name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 余额，单位：分
        /// </summary>
        [XmlElement("balance")]
        public int Balance { get; set; }

        /// <summary>
        /// 应缴金额
        /// </summary>
        [XmlElement("pay_amount")]
        public int PayAmount { get; set; }

        /// <summary>
        /// 起始日期，填账务年月即可
        /// </summary>
        [XmlElement("begin_date")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 截止日期，填账务年月即可
        /// </summary>
        [XmlElement("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// 附加信息
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }
    }
}
