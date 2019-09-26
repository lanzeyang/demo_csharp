using demo_csharp.Workers.IWorkService;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace demo_csharp.Workers
{
    public class StringWorker : IMasterWorker
    {
        Action<string> print = text => Console.WriteLine(text);

        public void Do()
        {
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
        }
    }
}
