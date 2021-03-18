using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers.Sort
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public class InsertionSort : SortBase, IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("插入排序前的数组：");
            PrintArray(ChaosArray);

            Sort(ChaosArray);

            Console.WriteLine("插入排序后的数组：");
            PrintArray(ChaosArray);
        }

        private void Sort(int[] array)
        {
            for (int index = 1; index < array.Length; index++)
            {
                int preIndex = index - 1;
                int temp = array[index];
                while (preIndex >= 0 && array[preIndex] > temp)
                {
                    array[preIndex + 1] = array[preIndex];
                    preIndex--;
                }

                array[preIndex + 1] = temp;

                PrintArray(ChaosArray);
            }
        }
    }
}
