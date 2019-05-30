using Common.SHA1Helper;
using Common.XmlHelper;
using demo_csharp.Workers.IWorkService;
using SH3H.BM.Model.WxLifePay.Request;
using System;

namespace demo_csharp.Workers
{
    public class SHA1Worker : IMasterWorker
    {
        private const string SECRECT_KEY = "7358ce5b186b4cc4a1e75fc8a643643a";

        public void Do()
        {
            //Guid guidKey = Guid.NewGuid();
            //Console.WriteLine(guidKey.ToString().Replace("-", string.Empty));
            //GenerateQueryRequestString();
            //GenerateChargeRequest();
            GenerateConfirmRequest();
            //GenerateRefundRequest();
        }

        private void GenerateQueryRequestString()
        {
            RequestQueryModel request = new RequestQueryModel
            {
                Head = new SH3H.BM.Model.WxLifePay.Generic.BaseHead
                {
                    Version = "1.0.1",
                    TranCode = "query",
                    TranSeqNum = "123456",
                    MerchantId = "123456"
                },
                Info = new SH3H.BM.Model.WxLifePay.Request.Info.RequestQueryInfo
                {
                    BillKey = "010055392",
                    CompanyId = "123456",
                    BeginNum = "1",
                    QueryNum = "1"
                }
            };

            Console.WriteLine(Sign(request));
        }

        private void GenerateChargeRequest()
        {
            RequestChargeModel request = new RequestChargeModel
            {
                Head = new SH3H.BM.Model.WxLifePay.Generic.BaseHead
                {
                    Version = "1.0.1",
                    TranCode = "charge",
                    TranSeqNum = "123456",
                    MerchantId = "123456"
                },
                Info = new SH3H.BM.Model.WxLifePay.Request.Info.RequestChargeInfo
                {
                    BillKey = "010055392",
                    CompanyId = "123456",
                    BillNo = "20190523221332",
                    TransactionId = "wx20190523221332",
                    PayDate = "20190523221332",
                    CustomerName = "林仕南",
                    PayAmount = 5443,
                    Attach = "4204721|1956614",
                    BillMonth = ""
                }
            };

            Console.WriteLine(Sign(request));
        }

        private void GenerateConfirmRequest()
        {
            RequestConfirmModel request = new RequestConfirmModel
            {
                Head = new SH3H.BM.Model.WxLifePay.Generic.BaseHead
                {
                    Version = "1.0.1",
                    TranCode = "confirm",
                    TranSeqNum = "123456",
                    MerchantId = "123456"
                },
                Info = new SH3H.BM.Model.WxLifePay.Request.Info.RequestConfirmInfo
                {
                    BillKey = "010032808",
                    TransactionId = "4200000336201905290528084674",
                    CompanyId = "123456",
                    BillNo = "2E9vto9lC0AGs0a2",
                    PayAmount = 100,
                }
            };

            Console.WriteLine(Sign(request));
        }

        private void GenerateRefundRequest()
        {
            RequestRefundModel request = new RequestRefundModel
            {
                Head = new SH3H.BM.Model.WxLifePay.Generic.BaseHead
                {
                    Version = "1.0.1",
                    TranCode = "refund",
                    TranSeqNum = "123456",
                    MerchantId = "123456"
                },
                Info = new SH3H.BM.Model.WxLifePay.Request.Info.RequestRefundInfo
                {
                    BillKey = "010037840",
                    CompanyId = "123456",
                    BillNo = "2019040313290003",
                    TransactionId = "wx2019040313290003",
                    Attach = ""
                }
            };

            Console.WriteLine(Sign(request));
        }

        private string Sign<T>(T t) where T : class
        {
            string xmlString = XmlHelper.Serialize(t);
            string xmlStringWithSecrectBehind = string.Format("{0}{1}", xmlString, SECRECT_KEY);

            return SHA1Helper.Hash(xmlStringWithSecrectBehind).ToUpper() + xmlString;
        }
    }
}
