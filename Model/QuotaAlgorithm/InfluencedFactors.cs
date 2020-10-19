using Model.Enum;
using System.Collections.Generic;

namespace Model.QuotaAlgorithm
{
    public class InfluencedFactors
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 影响因素值
        /// </summary>
        public decimal? PrimaryFactorValue { get; set; }

        /// <summary>
        /// 影响因素计算方式（加减乘除）
        /// </summary>
        public AlgorithmType AlgorithmType { get; set; }

        /// <summary>
        /// 计算优先级，优先级高的先进行计算
        /// </summary>
        public int AlgorithmIndex { get; set; }

        /// <summary>
        /// 子影响因素，如果有值则决定父级的PrimaryFactorValue值
        /// </summary>
        public IEnumerable<InfluencedFactors> Children { get; set; }
    }
}
