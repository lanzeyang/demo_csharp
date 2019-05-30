using SH3H.BM.Model.WxLifePay.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SH3H.BM.Model.WxLifePay.Response.Info
{
    /// <summary>
    /// 账单查询返回消息体
    /// </summary>
    public class ResponseQueryInfo : BaseInfo
    {
        /// <summary>
        /// 总笔数
        /// </summary>
        [XmlElement("total_num")]
        public int TotalNum { get; set; }


        /// <summary>
        /// 账单列表
        /// </summary>
        [XmlElement("data")]
        public List<BillInfo> Bills { get; set; }
    }
}
