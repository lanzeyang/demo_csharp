using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Generic
{
    /// <summary>
    /// <info></info>节点中的公共部分
    /// </summary>
    public class BaseInfo
    {
        /// <summary>
        /// 机表号
        /// </summary>
        [XmlElement("bill_key")]
        public string BillKey { get; set; }

        /// <summary>
        /// 机构代号
        /// </summary>
        [XmlElement("company_id")]
        public string CompanyId { get; set; }
    }
}
