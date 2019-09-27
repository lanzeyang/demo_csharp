using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class ParallelWorker : IMasterWorker
    {
        public void Do()
        {
            //Demo4Invoke();
            Demo4For();
        }

        private void Demo4Invoke()
        {
            Action[] actions = new Action[]
            {
                () => ActionTest("test 1"),
                () => ActionTest("test 2"),
                () => ActionTest("test 3"),
                () => ActionTest("test 4")
            };

            Parallel.Invoke(actions);
            Console.WriteLine("Parallel.Invoke结束");
        }

        /// <summary>
        /// Parallel.For测试
        /// </summary>
        private void Demo4For()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Dictionary<int, int> result = new Dictionary<int, int>();
            Parallel.For(0, nums.Length, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (index) =>
            {
                Console.WriteLine(string.Format("索引：{0}，值：{1}，Thread：{2}，time：{3}", index, nums[index], Thread.CurrentThread.ManagedThreadId, DateTime.Now));
                int addedResult = Add(nums[index]);
                result.Add(nums[index], addedResult);
                Thread.Sleep(1000);
            });

            Parallel.ForEach(result, (item) =>
            {
                Console.WriteLine(string.Format("Key:{0},Value:{1}", item.Key, item.Value));
            });
        }

        private void ActionTest(object value)
        {
            Thread.Sleep(1000);
            Console.WriteLine(string.Format("Thread:{0}, value: {1}, time:{2}", Thread.CurrentThread.ManagedThreadId, value, DateTime.Now));
        }

        private int Add(int num)
        {
            return ++num;
        }
    }
}
