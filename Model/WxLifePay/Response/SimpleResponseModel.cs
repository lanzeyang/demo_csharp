using SH3H.BM.Model.WxLifePay.Response.Head;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    [XmlRoot("wxlifepay")]
    public class SimpleResponseModel
    {
        /// <summary>
        /// 响应头
        /// </summary>
        [XmlElement("head")]
        public ResponseBaseHead Head { get; set; }
    }
}
