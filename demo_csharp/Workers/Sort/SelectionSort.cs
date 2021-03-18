using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers.Sort
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SelectionSort : SortBase, IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("选择排序前的数组：");
            PrintArray(ChaosArray);

            Sort(ChaosArray);

            Console.WriteLine("选择排序后的数组：");
            PrintArray(ChaosArray);
        }

        private void Sort(int[] array)
        {
            for (int index1 = 0; index1 < array.Length - 1; index1++)
            {
                int minIndex = index1;
                for (int index2 = index1 + 1; index2 < array.Length; index2++)
                {
                    if (array[index2] < array[minIndex])
                    {
                        minIndex = index2;
                    }
                }

                int temp = array[index1];
                array[index1] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}
