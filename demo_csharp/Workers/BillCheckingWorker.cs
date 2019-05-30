using Common.AssemblyPathHelper;
using Common.TextAnalysor;
using demo_csharp.Workers.IWorkService;
using Model.Socket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 解析对账文件
    /// </summary>
    public class BillCheckingWorker : IMasterWorker
    {
        public void Do()
        {
            string filePath = AssemblyPathHelper.GetAssemblyPath() + "Resource/210311990023-20180712.txt";

            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                int offSet = 0;

                byte[] billsByte = File.ReadAllBytes(filePath);

                string bills = Encoding.GetEncoding("UTF-8").GetString(billsByte);
                int lines = bills.Count(item => item == '\n');

                Console.WriteLine(bills);

                BillCheckingSummary summary = TextAnalysor.AnalyseToBillCheckingSummary(billsByte, ref offSet);
                List<BillCheckingDetail> details = TextAnalysor.AnalyseToBillCheckingDetails(billsByte, summary.CheckCount, offSet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public Action<string> print = message =>
        {
            Console.WriteLine(message);
        };
    }
}
