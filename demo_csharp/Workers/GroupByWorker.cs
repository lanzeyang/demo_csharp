using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class GroupByWorker : IMasterWorker
    {
        public void Do()
        {
            List<string> dateGroup = new List<string>();
            dateGroup.Add("20190507194213");
            dateGroup.Add("20190506194213");
            dateGroup.Add("20190507194213");
            dateGroup.Add("20190508194213");
            dateGroup.Add("20190508194213");
            dateGroup.Add("20190509194213");
            dateGroup.Add("20190505194213");

            var query = dateGroup.GroupBy(item => item.Substring(0, 8)).OrderBy(item => item.Key);

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
