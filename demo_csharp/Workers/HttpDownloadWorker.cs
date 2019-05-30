using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace demo_csharp.Workers
{
    public class HttpDownloadWorker : IMasterWorker
    {
        public void Do()
        {
            string downloadUrl = "http://128.1.8.31:8083/api/wap/v2/fs/image/a8062f98213b1aae23de6804895e8c3a";
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient client = new HttpClient(handler))
            {
                HttpResponseMessage response = client.GetAsync(downloadUrl).Result;

                response.EnsureSuccessStatusCode();

                byte[] contentByte = response.Content.ReadAsByteArrayAsync().Result;

                Console.WriteLine(contentByte.Length);
            }
        }
    }
}
