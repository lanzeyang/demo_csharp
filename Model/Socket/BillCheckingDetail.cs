using Model.CustomisedAttribute;

namespace Model.Socket
{
    /// <summary>
    /// 对账明细
    /// </summary>
    public class BillCheckingDetail
    {
        /// <summary>
        /// 交易序号
        /// </summary>
        [Section(1, 6)]
        public string TradeNo { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        [Section(2, 8)]
        public int TradeDate { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        [Section(3, 6)]
        public string TradeTime { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Section(4, 30)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [Section(5, 18)]
        public int OrderMoney { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [Section(6, 18)]
        public int TradeMoney { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [Section(7, 18)]
        public int ServiceCharge { get; set; }

        /// <summary>
        /// 实际收入
        /// </summary>
        [Section(8, 18)]
        public int IncomeMoney { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Section(9, 50)]
        public string MerchantOrder { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [Section(10, 20)]
        public string TradeType { get; set; }
    }
}
