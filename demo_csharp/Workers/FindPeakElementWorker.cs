using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class FindPeakElementWorker : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine(FindPeakElement(new int[] { 1, 2, 3 }));
        }

        public int FindPeakElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                map.Add(index, nums[index]);
            }

            if (nums.Length.Equals(1))
            {
                return 0;
            }

            if (nums.Length.Equals(2))
            {
                return map.Where(item => item.Value == map.Select(item_2 => item_2.Value).Max()).First().Key;
            }

            for (int index = 1; index < nums.Length - 1; index++)
            {
                if (index == 1 && map[index - 1] > nums[index])
                {
                    return 0;
                }

                if (index == nums.Length - 2 && map[index + 1] > nums[index])
                {
                    return nums.Length - 1;
                }

                if (map[index - 1] < nums[index] && map[index + 1] < nums[index])
                {
                    return index;
                }
            }

            return -1;
        }
    }
}
