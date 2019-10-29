using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class ThreeSumWorker : IMasterWorker
    {
        public void Do()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> result = ThreeSum(nums);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (null == nums || nums.Length < 3)
            {
                return null;
            }

            int[] negativeNums = nums.Where(item => item <= 0).ToArray();
            int[] positiveNums = nums.Where(item => item > 0).ToArray();

            IList<IList<int>> result = new List<IList<int>>();

            for (int index = 0; index < negativeNums.Length; index++)
            {
                for (int secondIndex = index + 1; secondIndex < negativeNums.Length; secondIndex++)
                {
                    if (positiveNums.Contains(Math.Abs(negativeNums[index] + negativeNums[secondIndex])))
                    {
                        result.Add(new List<int>() { negativeNums[index], negativeNums[secondIndex], Math.Abs(negativeNums[index] + negativeNums[secondIndex]) });
                    }
                }
            }

            for (int index = 0; index < positiveNums.Length; index++)
            {
                for (int secondIndex = index + 1; secondIndex < positiveNums.Length; secondIndex++)
                {
                    if (negativeNums.Contains(-(positiveNums[index] + positiveNums[secondIndex])))
                    {
                        result.Add(new List<int>() { positiveNums[index], positiveNums[secondIndex], -(positiveNums[index] + positiveNums[secondIndex]) });
                    }
                }
            }

            return result;
        }
    }
}
