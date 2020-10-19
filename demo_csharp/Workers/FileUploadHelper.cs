using Common.HttpHelper;
using demo_csharp.Workers.IWorkService;
using System;
using System.IO;

namespace demo_csharp.Workers
{
    public class FileUploadHelper : IMasterWorker
    {
        private static HttpHelper httpHelper = HttpHelper.CreateInstance();

        public void Do()
        {
            string fileName = "20200513150809.png"; 
            string filePath = @"Resource/20200513150809.png";

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    byte[] buffur = new byte[fs.Length];
                    fs.Read(buffur, 0, (int)fs.Length);
                    string result = httpHelper.UploadFileByFormData("http://localhost:18008/API/v1/webmedia/savemedia", fileName, buffur).Result;
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
