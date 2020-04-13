using demo_csharp.Workers.IWorkService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo_csharp.Workers
{
    public class StringWorker : IMasterWorker
    {
        Action<string> print = text => Console.WriteLine(text);

        public void Do()
        {
            TestAnalyseFileName();
            return;

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "lianzeyang", Gender = "male" });
            students.Add(new Student { Name = "zhangsan", Gender = "male" });
            students.Add(new Student { Name = "lisi", Gender = "male" });
            students.Add(new Student { Name = "limei", Gender = "female" });
            students.Add(new Student { Name = "wangfang", Gender = "female" });

            var aggregatedData = students.GroupBy(item => item.Gender);

            foreach (var data in aggregatedData)
            {
                Console.WriteLine(data.Key);
                foreach (var student in data)
                {
                    Console.WriteLine(student.Name);
                }
            }

            string response = "\\\"0000031522\"";
            Console.WriteLine(response);


            response = response.Replace("\\\"", "");
            Console.WriteLine(response);

            string mobilePhone = "13127571386";
            string mobilePhoneToBeShown = string.Empty;
            mobilePhoneToBeShown = string.Format("{0}****{1}", mobilePhone.Substring(0, 3), mobilePhone.Substring(7, 4));

            Console.WriteLine(mobilePhoneToBeShown);

            string testString = "\r\nhello word\r\n";
            Console.WriteLine(testString);

            char[] trimedChars = new char[] { '\r', '\n' };

            Console.WriteLine(testString.Trim(trimedChars));

            string fullFileName = "yyyyMMdd_waterfee.txt";
            string[] fileNameWithExtra = fullFileName.Split('.');

            string fileName = fileNameWithExtra[0];
            Console.WriteLine(fileName);

            string[] dateWithType = fileName.Split('_');

            string type = dateWithType[1];
            Console.WriteLine(type);

            Console.WriteLine(fullFileName.Substring(fullFileName.IndexOf('_') + 1, fullFileName.IndexOf('.') - fullFileName.IndexOf('_') - 1));

            List<int> ids = new List<int>();
            string joinedIds = string.Join(",", ids);

            int year = DateTime.Now.Year;
            int month = 11;
            int day = 31;
            Console.WriteLine(string.Format("{0}年{1}月{2}日", DateNumber2CHN(year), DateNumber2CHN(month), DateNumber2CHN(day)));


            Console.WriteLine(Guid.NewGuid().ToString().Replace("-", ""));
        }

        private string DateNumber2CHN(int number)
        {
            if (number.ToString().Length.Equals(4))
            {
                return string.Format("{0}{1}{2}{3}", SingleNum2CHN(number / 1000), SingleNum2CHN(number / 100 % 10), SingleNum2CHN(number / 10 % 10), SingleNum2CHN(number % 10));
            }

            if (number.ToString().Length.Equals(2))
            {
                if (number == 10)
                {
                    return "十";
                }

                if (number / 10 == 1)
                {
                    return string.Format("十{0}", SingleNum2CHN(number % 10));
                }

                if (number % 10 == 0)
                {
                    return string.Format("{0}十", SingleNum2CHN(number / 10));
                }

                return string.Format("{0}十{1}", SingleNum2CHN(number / 10), SingleNum2CHN(number % 10));
            }

            if (number.ToString().Length.Equals(1))
            {
                return SingleNum2CHN(number);
            }

            return string.Empty;
        }

        public string SingleNum2CHN(int singleNumber)
        {
            string result = string.Empty;

            switch (singleNumber)
            {
                case 0:
                    result = "〇";
                    break;
                case 1:
                    result = "一";
                    break;
                case 2:
                    result = "二";
                    break;
                case 3:
                    result = "三";
                    break;
                case 4:
                    result = "四";
                    break;
                case 5:
                    result = "五";
                    break;
                case 6:
                    result = "六";
                    break;
                case 7:
                    result = "七";
                    break;
                case 8:
                    result = "八";
                    break;
                case 9:
                    result = "九";
                    break;
                default:
                    break;
            }

            return result;
        }

        public void TestAnalyseFileName()
        {
            string fileName = "20190813_waterfee_SELF_HELP_SCAN_PAY.txt";

            int currentIndex = 0;
            string date = fileName.Substring(currentIndex, 8);
            Console.WriteLine(date);

            currentIndex += date.Length + 1;
            string feeType = fileName.Substring(currentIndex, fileName.IndexOf('_', currentIndex) - currentIndex);
            Console.WriteLine(feeType);

            currentIndex += feeType.Length + 1;
            string mchId = fileName.Substring(currentIndex, fileName.IndexOf('.') - currentIndex);
            Console.WriteLine(mchId);
        }
    }
}
