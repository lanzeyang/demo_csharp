using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QuotaAlgorithm
{
    public class Algorithm
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 行业分类
        /// </summary>
        public string TopClass { get; set; }

        /// <summary>
        /// 行业二级分类
        /// </summary>
        public string SecondClass { get; set; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 定额基数（通用值）
        /// </summary>
        public decimal PrimaryAlgorithmBase { get; set; }

        /// <summary>
        /// 定额基数（后进值）
        /// </summary>
        public decimal SecondaryAlgorithmBase { get; set; }

        /// <summary>
        /// 是否使用定额基数（通用值）
        /// </summary>
        public bool UsePrimary { get; set; }

        /// <summary>
        /// 影响因素
        /// </summary>
        IEnumerable<InfluencedFactors> Factors { get; set; }
    }
}
