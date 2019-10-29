using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class MaximumProductWorker : IMasterWorker
    {
        public void Do()
        {
            //最少有3个元素
            int[] nums = new int[] { -1, -2, 5, 4, 10, -5, -10 };
            Console.WriteLine(MaximumProduct(nums));
        }
        public int MaximumProduct(int[] nums)
        {
            if (null == nums || nums.Length < 3)
            {
                throw new ArgumentException("参数数量不足");
            }

            if (nums.Length == 3)
            {
                return nums[0] * nums[1] * nums[2];
            }

            Array.Sort(nums);

            int num1 = nums[0] * nums[1] * nums[nums.Length - 1];
            int num2 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];

            return Math.Max(num1, num2);
        }
    }
}
