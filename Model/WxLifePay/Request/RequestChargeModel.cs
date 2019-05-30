using SH3H.BM.Model.WxLifePay.Request.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 缴费单销账类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class RequestChargeModel : RequestBaseModel
    {
        /// <summary>
        /// 消息体
        /// </summary>
        [XmlElement("info")]
        public RequestChargeInfo Info { get; set; }
    }
}
