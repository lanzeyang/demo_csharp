using demo_csharp.Workers.IWorkService;
using System;
using System.Globalization;

namespace demo_csharp.Workers
{
    public class DateTimeWorker : IMasterWorker
    {
        public void Do()
        {
            string yyyyMMddHHmmss = "20190329172637";
            DateTime date = DateTime.ParseExact(yyyyMMddHHmmss, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Console.WriteLine(date.ToString("yyyyMMdd"));
            Console.WriteLine(date.ToString("HH:mm:ss"));

            string yyyyMMdd = "20190231";
            DateTime yyyyMMddDate = new DateTime();
            DateTime.TryParseExact(yyyyMMdd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out yyyyMMddDate);
            Console.WriteLine(yyyyMMddDate.Equals(new DateTime()));

            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd"));
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            string dateTimeString = "2019/04/01";
            DateTime dateTime = DateTime.Parse(dateTimeString);
            DateTime.TryParseExact(dateTimeString, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            Console.WriteLine(dateTime.ToString("yyyyMMdd"));

            string dateTimeStringNull = null;
        }
    }
}
