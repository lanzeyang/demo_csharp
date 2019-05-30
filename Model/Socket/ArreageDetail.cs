using Model.CustomisedAttribute;

namespace Model.Socket
{
    /// <summary>
    /// 欠费明细
    /// </summary>
    public class ArreageDetail
    {
        /// <summary>
        /// 改部分的偏移量截取明细部分单独处理
        /// </summary>
        public ArreageDetail() { }

        /// <summary>
        /// 用水年月
        /// </summary>
        [Section(1, 6)]
        public string YearMonth { get; set; }

        /// <summary>
        /// 用水量
        /// </summary>
        [Section(2, 10)]
        public int WaterUsage { get; set; }

        /// <summary>
        /// 欠费金额
        /// </summary>
        public decimal WaterFee { get; set; }
    }
}
