using Model.CustomisedAttribute;

namespace Model.Socket
{
    /// <summary>
    /// 公用
    /// </summary>
    public class BasicResponse
    {
        public BasicResponse() { }

        /// <summary>
        /// 报文长度
        /// </summary>
        [Section(1, 6)]
        public int MessageLength { get; set; }

        /// <summary>
        /// 交易码
        /// </summary>
        [Section(2, 2)]
        public string TradeCode { get; set; }

        /// <summary>
        /// 响应码
        /// </summary>
        [Section(3, 3)]
        public string ResponseCode { get; set; }

        /// <summary>
        /// 代收方标识号
        /// </summary>
        [Section(4, 10)]
        public string CollectorIndentity { get; set; }

        /// <summary>
        /// 用户代码
        /// </summary>
        [Section(5, 10)]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [Section(6, 100)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        [Section(7, 100)]
        public string UserAddress { get; set; }
    }
}
