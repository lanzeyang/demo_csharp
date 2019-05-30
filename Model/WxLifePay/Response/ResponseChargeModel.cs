using SH3H.BM.Model.WxLifePay.Response.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    /// <summary>
    /// 销账响应类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class ResponseChargeModel : ResponseBaseModel
    {
        /// <summary>
        /// 正文部分
        /// </summary>
        [XmlElement("info")]
        public ResponseChargeInfo Info { get; set; }
    }
}
