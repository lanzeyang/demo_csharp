using SH3H.BM.Model.WxLifePay.Request.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 销帐结果查询类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class RequestConfirmModel : RequestBaseModel
    {
        /// <summary>
        /// 消息体
        /// </summary>
        [XmlElement("info")]
        public RequestConfirmInfo Info { get; set; }
    }
}
