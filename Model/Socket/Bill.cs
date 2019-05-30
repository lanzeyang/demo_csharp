using Model.CustomisedAttribute;
using System.Collections.Generic;

namespace Model.Socket
{
    public class Bill : BasicResponse
    {
        public Bill() { BillDetails = new List<BillDetail>(); }

        /// <summary>
        /// 总账单份数
        /// </summary>
        [Section(8, 3)]
        public int Count { get; set; }

        /// <summary>
        /// 账单详情
        /// </summary>
        public List<BillDetail> BillDetails { get; set; }
    }
}
