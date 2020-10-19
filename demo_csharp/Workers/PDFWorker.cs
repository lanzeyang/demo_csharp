using Common;
using Common.HttpHelper;
using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class PDFWorker : IMasterWorker
    {
        public void Do()
        {
            MySqlHelper mySqlHelper = MySqlHelper.CreateInstance();

            string sqlCommand = "SELECT PLATFORM_SERIAL_NO, INVOICE_REMOTE_PATH FROM IM_E_INVOICE WHERE ID >= 15450 AND INVOICE_STATE = 1";

            DataSet queryResult = mySqlHelper.Query(sqlCommand);
            if (null == queryResult || null == queryResult.Tables || queryResult.Tables.Count.Equals(0))
            {
                return;
            }

            Dictionary<string, string> name2Url = new Dictionary<string, string>();
            foreach (DataRow item in queryResult.Tables[0].Rows)
            {
                string platformSerialNo = item["PLATFORM_SERIAL_NO"].ToString();
                string url = item["INVOICE_REMOTE_PATH"].ToString();

                name2Url.Add(platformSerialNo, url);

                string fileName = "E:/LG/" + platformSerialNo + ".pdf";

                WebClient webClient = new WebClient();
                byte[] pdfByteFromWebClient = webClient.DownloadData(url);

                using (FileStream pdfFile = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    pdfFile.Write(pdfByteFromWebClient, 0, pdfByteFromWebClient.Length);
                }
            }
        }
    }
}
