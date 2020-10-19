using demo_csharp.Workers.IWorkService;
using System;
using Common.HashHelper;
using System.Collections.Generic;
using Model;
using System.Linq;
using System.Text;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 文件hash值测试
    /// </summary>
    public class HashWorker : IMasterWorker
    {
        private static string filePathPrefix = string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "Resource\\");
        private static HashHelper hashHelper = HashHelper.CreateInstance();

        public void Do()
        {
            List<Film> films = new List<Film>();
            films.Add(new Film { Name = "1" });

            Console.WriteLine(films[0].Name);

            films.Select(item => item.Name = "2");

            Console.WriteLine(films[0].Name);

            //string file1 = filePathPrefix + "hash_test_1.txt";
            string file1 = filePathPrefix + "\\20200513150809.png";
            //string file2 = filePathPrefix + "hash_test_2.txt";
            string file2 = filePathPrefix + "\\image\\1022_2090910.png";

            Console.WriteLine(file1);
            Console.WriteLine(file2);

            byte[] file1Byte = ReadFile(file1);
            string base64String = Convert.ToBase64String(file1Byte);
            string file1MD5 = hashHelper.ComputeMD5(file1Byte);
            Console.WriteLine(file1MD5.ToUpper());

            byte[] file2Byte = ReadFile(file2);
            string file2MD5 = hashHelper.ComputeMD5(file2Byte);
            Console.WriteLine(file2MD5);

            Student xiaoming = new Student()
            {
                Gender = "male",
                Name = "xiaoming"
            };

            byte[] byte4Object = Encoding.UTF8.GetBytes(xiaoming.ToString());
            string objectMD5 = hashHelper.ComputeMD5(byte4Object);
            Console.WriteLine(objectMD5);

            xiaoming.Name = "xiaoming";
            byte4Object = Encoding.UTF8.GetBytes(xiaoming.ToString());
            objectMD5 = hashHelper.ComputeMD5(byte4Object);
            Console.WriteLine(objectMD5);
        }

        private byte[] ReadFile(string path)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                byte[] fileByte = new byte[fs.Length];
                fs.Read(fileByte, 0, (int)fs.Length);
                return fileByte;
            }
        }
    }
}
