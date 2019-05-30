using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    /// <summary>
    /// 冲正响应类，只有head部分
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class ResponseRefundModel : ResponseBaseModel { }
}
