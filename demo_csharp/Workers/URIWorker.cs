using demo_csharp.Workers.IWorkService;
using System;
using System.Web;

namespace demo_csharp.Workers
{
    public class URIWorker : IMasterWorker
    {
        public void Do()
        {
            string encodedURI = "http%3a%2f%2f116.62.46.42%3a14000%2fOauthTokenHandler.ashx";
            string uri = HttpUtility.UrlDecode(encodedURI);

            Console.WriteLine(uri);

            Console.WriteLine(HttpUtility.UrlEncode(uri));
        }
    }
}
