using Model.CustomisedAttribute;
using System.Collections.Generic;

namespace Model.Socket
{
    /// <summary>
    /// 欠费信息
    /// </summary>
    public class Arreage : BasicResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Arreage() { ArreageDetails = new List<ArreageDetail>(); }

        /// <summary>
        /// 总金额
        /// </summary>
        [Section(8, 13)]
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 笔数
        /// </summary>
        [Section(9, 4)]
        public int Count { get; set; }

        /// <summary>
        /// 欠费明细
        /// </summary>
        public List<ArreageDetail> ArreageDetails { get; set; }
    }
}
