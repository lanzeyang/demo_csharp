using demo_csharp.Workers.IWorkService;
using System;
using System.Web;

namespace demo_csharp.Workers
{
    public class URIWorker : IMasterWorker
    {
        public void Do()
        {
            string encodedURI = "https://ds.alipay.com/?scheme=alipays%3A%2F%2Fplatformapi%2Fstartapp%3FappId%3D20000193%26url%3D%252Fwww%252FeBill.htm%253Freferer%253DGOPAY%2526billKey%253D7015245%2526instId%253DZZHKGQ5855%2526subBizType%253DWATER";
            string uri = HttpUtility.UrlDecode(encodedURI);

            Console.WriteLine(uri);

            Console.WriteLine(HttpUtility.UrlEncode(uri));
        }
    }
}
