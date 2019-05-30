using SH3H.BM.Model.WxLifePay.Response.Head;
using SH3H.BM.Model.WxLifePay.Response.Info;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response
{
    /// <summary>
    /// 查询响应类
    /// </summary>
    [XmlRoot("wxlifepay")]
    public class ResponseQueryModel : ResponseBaseModel
    {
        //public ResponseQueryModel()
        //{
        //    Head = new ResponseBaseHead();
        //    Info = new ResponseQueryInfo();
        //}

        /// <summary>
        /// 正文部分
        /// </summary>
        [XmlElement("info")]
        public ResponseQueryInfo Info { get; set; }
    }
}
