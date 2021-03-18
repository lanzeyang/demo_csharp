using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers.Sort
{
    /// <summary>
    /// 快速排序
    /// </summary>
    public class QuickSortWorker : SortBase, IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("快速排序前的数组：");
            PrintArray(ChaosArray);

            QuickSort(ChaosArray, 0, ChaosArray.Length - 1);

            Console.WriteLine("快速排序后的数组：");
            PrintArray(ChaosArray);
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int index = GetIndex(array, low, high);
                QuickSort(array, low, index - 1);
                QuickSort(array, low + 1, high);
            }
        }

        private int GetIndex(int[] arr, int low, int high)
        {
            int temp = arr[low];
            while (low < high)
            {
                while (low < high && arr[high] >= temp)
                {
                    high--;
                }
                arr[low] = arr[high];

                while (low < high && arr[low] <= temp)
                {
                    low++;
                }
                arr[high] = arr[low];
            }
            arr[low] = temp;

            return low;
        }
    }
}
