using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class FileUploadWorker : IMasterWorker
    {
        private const char COMMA = ',';
        private static string filePathPrefix = string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "Resource\\image\\");

        public void Do()
        {
            //获取recordId - 文件名对应
            IEnumerable<Key2Value> key2Values = ReadKeyValueFromFile();
            //根据所获取的key2Values获取文件
            if (key2Values.Count().Equals(0))
            {
                Console.WriteLine("没有读取到文件信息");
                return;
            }

            UploadFilesFromFiles(key2Values);
        }

        private IEnumerable<Key2Value> ReadKeyValueFromFile()
        {
            string configFileName = "config.csv";

            string configFilePath = string.Format("{0}{1}", filePathPrefix, configFileName);
            Console.WriteLine(configFilePath);

            List<Key2Value> key2Values = new List<Key2Value>();

            using (FileStream fs = new FileStream(configFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                string str = string.Empty;
                while (str != null)
                {
                    str = sr.ReadLine();
                    if (string.IsNullOrEmpty(str))
                    {
                        break;
                    }

                    string[] keyValue = str.Split(COMMA);

                    Key2Value key2Value = new Key2Value()
                    {
                        RecordId = keyValue[0],
                        FileName = keyValue[1]
                    };

                    key2Values.Add(key2Value);
                }
                sr.Close();
            }

            return key2Values;
        }

        private void UploadFilesFromFiles(IEnumerable<Key2Value> key2Values)
        {
            Parallel.ForEach(key2Values, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (item) =>
            {
                //根据文件名称获取文件的字节流
                string imageFilePath = string.Format("{0}{1}", filePathPrefix, item.FileName);
                try
                {
                    using (FileStream fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);
                        byte[] bytes = Encoding.UTF8.GetBytes(reader.ReadToEnd());

                        //将图片上传至平台


                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("");
                }
            });
        }
    }

    public class Key2Value
    {
        public string RecordId { get; set; }

        public string FileName { get; set; }
    }
}
