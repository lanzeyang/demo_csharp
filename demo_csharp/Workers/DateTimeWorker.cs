using demo_csharp.Workers.IWorkService;
using System;
using System.Globalization;

namespace demo_csharp.Workers
{
    public class DateTimeWorker : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine(DateTime.UtcNow.ToString());
            return;

            Console.WriteLine(DateTime.Compare(DateTime.Now.AddMinutes(1), DateTime.Now));
            return;

            Console.WriteLine(CompareTimeSize(DateTime.Now, DateTime.Now.AddMinutes(-8)).TotalMinutes);
            return;

            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");

            Console.WriteLine(string.Format("{0}年{1}月{2}日", year, month, day));

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

            double timeStamp = 1551510137;
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            time = time.AddSeconds(timeStamp).ToLocalTime();
            Console.WriteLine(time.ToString("yyyy-MM-dd HH:mm:ss"));

            int minutesFromStart = 1435;
            TimeSpan timeSpan = new TimeSpan(minutesFromStart / 60, minutesFromStart % 60, 0);
            Console.WriteLine(timeSpan.ToString());

            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));

            long ticksFrom19700101 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks;

            Console.WriteLine((DateTime.Now.ToUniversalTime().Ticks - ticksFrom19700101) / 10000);
        }

        public TimeSpan CompareTimeSize(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts1 = new TimeSpan(dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(dt2.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            return ts3;
        }
    }
}
