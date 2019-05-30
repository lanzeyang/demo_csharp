using System;

namespace SH3H.BM.Model.WxLifePay.Order
{
    /// <summary>
    /// 微信生活缴费订单类
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        public int FeeType { get; set; }

        /// <summary>
        /// 机构代号
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 表卡号
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 费用编号
        /// </summary>
        public string FeeId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 账务年月
        /// </summary>
        public string BillingMonth { get; set; }

        /// <summary>
        /// 缴费单流水号，微信生活缴费平台的业务流水号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 微信账单号
        /// </summary>
        public string WechatOrderNumber { get; set; }

        /// <summary>
        /// 处理状态， 0：默认状态，1：处理中，2：处理完成
        /// </summary>
        public int ProcessState { get; set; }

        /// <summary>
        /// 是否标记为删除
        /// </summary>
        public bool MarkForDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }
    }
}
