using SH3H.BM.Model.WxLifePay.Response.Head;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    /// <summary>
    /// 响应基础类
    /// </summary>
    public class ResponseBaseModel
    {
        /// <summary>
        /// 响应头
        /// </summary>
        [XmlElement("head")]
        public ResponseBaseHead Head { get; set; }
    }
}
