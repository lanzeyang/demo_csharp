using SH3H.BM.Model.WxLifePay.Request.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Request
{
    /// <summary>
    /// 查询缴费单信息类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class RequestQueryModel : RequestBaseModel
    {
        /// <summary>
        /// 请求体
        /// </summary>
        [XmlElement("info")]
        public RequestQueryInfo Info { get; set; }
    }
}
