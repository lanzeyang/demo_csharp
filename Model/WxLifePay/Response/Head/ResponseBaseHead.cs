using SH3H.BM.Model.WxLifePay.Generic;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response.Head
{
    /// <summary>
    /// 返回结果头
    /// </summary>
    public class ResponseBaseHead : BaseHead
    {
        /// <summary>
        /// 查询返回码
        /// </summary>
        [XmlElement("ret_code")]
        public string RetCode { get; set; }

        /// <summary>
        /// 返回提示信息
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrorMessage { get; set; }
    }
}
