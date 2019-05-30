using Model.CustomisedAttribute;

namespace Model.Socket
{
    public class BillDetail
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BillDetail() { }

        /// <summary>
        /// 账单年月
        /// </summary>
        [Section(1, 6)]
        public string YearMonth { get; set; }

        /// <summary>
        /// 上次读数
        /// </summary>
        [Section(2, 10)]
        public int LastReading { get; set; }

        /// <summary>
        /// 本次读数
        /// </summary>
        [Section(3, 10)]
        public int CurrentReading { get; set; }

        /// <summary>
        /// 用水量
        /// </summary>
        [Section(4, 10)]
        public int WaterUsage { get; set; }

        /// <summary>
        /// 基本用水量
        /// </summary>
        [Section(5, 10)]
        public int BasicWaterUsage { get; set; }

        /// <summary>
        /// 基本水费
        /// </summary>
        [Section(6, 13)]
        public decimal BasicWaterFee { get; set; }

        /// <summary>
        /// 二阶梯用水量
        /// </summary>
        [Section(7, 10)]
        public int Level2WaterUsage { get; set; }

        /// <summary>
        /// 二阶梯水费
        /// </summary>
        [Section(8, 13)]
        public decimal Level2WaterFee { get; set; }

        /// <summary>
        /// 三阶梯用水量
        /// </summary>
        [Section(9, 10)]
        public int Level3WaterUsage { get; set; }

        /// <summary>
        /// 三阶梯水费
        /// </summary>
        [Section(10, 13)]
        public decimal Level3WaterFee { get; set; }

        /// <summary>
        /// 污水处理费
        /// </summary>
        [Section(11, 13)]
        public decimal SwageFee { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        [Section(12, 13)]
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Section(13, 1)]
        public int Status { get; set; }
    }
}
