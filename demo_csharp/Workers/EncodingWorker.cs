using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace demo_csharp.Workers
{
    public class EncodingWorker : IMasterWorker
    {
        public void Do()
        {
            string content = "MSG=PE1TRz48TWVzc2FnZT48VHJ4UmVzcG9uc2U+PFJldHVybkNvZGU+MDAwMDwvUmV0dXJuQ29kZT48RXJyb3JNZXNzYWdlPr270tezybmmPC9FcnJvck1lc3NhZ2U+PEVDTWVyY2hhbnRUeXBlPkVCVVM8L0VDTWVyY2hhbnRUeXBlPjxNZXJjaGFudElEPjEwMzg4MTU2MDAwMDE4MTwvTWVyY2hhbnRJRD48VHJ4VHlwZT5SZWN2UVJQYXlSZXN1bHQ8L1RyeFR5cGU+PE9yZGVyTm8+MjAxOTA1MDYxOTUwNDUwMDAwMDc1NTYzPC9PcmRlck5vPjxBbW91bnQ+MS4wMDwvQW1vdW50PjxCYXRjaE5vPjAwMDU0NjwvQmF0Y2hObz48Vm91Y2hlck5vPjI1MTg5NTwvVm91Y2hlck5vPjxIb3N0RGF0ZT4yMDE5LzA1LzA2PC9Ib3N0RGF0ZT48SG9zdFRpbWU+MTk6NTA6NTM8L0hvc3RUaW1lPjxQYXlUeXBlPkVQMTM5PC9QYXlUeXBlPjxOb3RpZnlUeXBlPjE8L05vdGlmeVR5cGU+PFBheUlQPjExMS4xNy4xODYuNDM8L1BheUlQPjxpUnNwUmVmPjU2RUNFUDAxMTgxNzI5Nzg3MjIwPC9pUnNwUmVmPjxBY2NEYXRlPjIwMTkwNTA2PC9BY2NEYXRlPjxiYW5rX3R5cGU+Q0ZUPC9iYW5rX3R5cGU+PFRoaXJkT3JkZXJObz4xMDM4ODE1NjAwMDAxODE3MTQzNDQ1MzQ2MDIzMTUyODwvVGhpcmRPcmRlck5vPjwvVHJ4UmVzcG9uc2U+PC9NZXNzYWdlPjxTaWduYXR1cmUtQWxnb3JpdGhtPlNIQTF3aXRoUlNBPC9TaWduYXR1cmUtQWxnb3JpdGhtPjxTaWduYXR1cmU+QStROEpXTkEzazlDNWkva1pYaVZwd3RqTHlCNEdTVEdTOGhoYW9xdm0zNmFJZnZndTlzNi9CdTFDQ2FFVDl1Ni9lVnpzZVl5K2ZpM2RnNnVSNng4K1JveDlsOXo3QWRhcVFNWWhLczc3VTRXNHYrOHlxKzNLbFhjRTJNcmhYU3B0QnkyczJGQUwwU1gxOGdNeHRNbC90YnVWc1lTejJDRlRTRndyeGhrVmdjPTwvU2lnbmF0dXJlPjwvTVNHPg==";


            string url = "https://payapp.weixin.qq.com/life/index?showwxpaytitle=1&from=3rd_cib#/agency/1/city/450800/companyid/m20180306000007360";
            url = "https://payapp.weixin.qq.com/life/index?showwxpaytitle=1&from=3rd_cib";
            string encodedURL = HttpUtility.UrlEncode(url);
            Console.WriteLine(encodedURL);

            string Url1 = "http%3a%2f%2fbkwx.gybkwater.com%2fGetWxIndex%2fWxCallBack";
            string decodedURL = HttpUtility.UrlDecode(Url1);
            Console.WriteLine(decodedURL);


            string decodedContent = HttpUtility.UrlEncode(content);



            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(content);

            string gbkContent = Encoding.GetEncoding("GBK").GetString(bytes);
            string utf8Content = Encoding.GetEncoding("UTF-8").GetString(bytes);
            string asciiContent = Encoding.GetEncoding("ascii").GetString(bytes);

            Console.WriteLine(content.Equals(gbkContent));

            Console.WriteLine(content.Equals(utf8Content));
            Console.WriteLine(content.Equals(asciiContent));


            Console.WriteLine(content);
        }
    }
}