using Model.CustomisedAttribute;

namespace Model.Socket
{
    /// <summary>
    /// 对账汇总信息
    /// </summary>
    public class BillCheckingSummary
    {
        /// <summary>
        /// 入账日期
        /// </summary>
        [Section(1, 8)]
        public string CheckingDate { get; set; }

        /// <summary>
        /// 订单总笔数
        /// </summary>
        [Section(2, 10)]
        public int CheckCount { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [Section(3, 18)]
        public int TotalMoney { get; set; }
    }
}
