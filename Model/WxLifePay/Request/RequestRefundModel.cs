using SH3H.BM.Model.WxLifePay.Request.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 冲正接口数据类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class RequestRefundModel : RequestBaseModel
    {
        /// <summary>
        /// 请求体
        /// </summary>
        [XmlElement("info")]
        public RequestRefundInfo Info { get; set; }
    }
}
