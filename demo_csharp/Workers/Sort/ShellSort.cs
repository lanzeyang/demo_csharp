using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers.Sort
{
    /// <summary>
    /// 希尔排序
    /// </summary>
    public class ShellSort : SortBase, IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("希尔排序前的数组：");
            PrintArray(ChaosArray);

            Sort(ChaosArray);

            Console.WriteLine("希尔排序后的数组：");
            PrintArray(ChaosArray);
        }

        private void Sort(int[] array)
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                for (int index1 = 0; index1 < gap; index1++)
                {
                    for (int index2 = index1 + gap; index2 < array.Length; index2 += gap)
                    {
                        if (array[index2] < array[index2 - gap])
                        {
                            int temp = array[index2];
                            int k = index2 - gap;

                            while (k >= 0 && array[k] > temp)
                            {
                                array[k + gap] = array[k];
                                k -= gap;
                            }

                            array[k + gap] = temp;
                        }
                    }
                }

                PrintArray(ChaosArray);
            }
        }
    }
}
