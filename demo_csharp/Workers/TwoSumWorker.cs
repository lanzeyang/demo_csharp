using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class TwoSumWorker : IMasterWorker
    {
        public void Do()
        {
            int[] nums = new int[] { 3, 3 };
            int terget = 6;
            int[] result = TwoSum_2(nums, terget);

            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
        }

        private int[] TwoSum_1(int[] nums, int target)
        {
            for (int index_1 = 0; index_1 < nums.Length; index_1++)
            {
                for (int index_2 = index_1 + 1; index_2 < nums.Length; index_2++)
                {
                    if (nums[index_1] + nums[index_2] == target)
                    {
                        return new int[] { index_1, index_2 };
                    }
                }
            }

            return null;
        }

        private int[] TwoSum_2(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
            {
                map.Add(index, nums[index]);
            }

            for (int index = 0; index < nums.Length; index++)
            {
                int component = target - nums[index];

                if (map.ContainsValue(component) && map.Where(item => item.Value.Equals(component)).First().Key != index)
                {
                    return new int[] { index, map.Where(item => item.Value.Equals(component)).First().Key };
                }
            }

            return null;
        }
    }
}
