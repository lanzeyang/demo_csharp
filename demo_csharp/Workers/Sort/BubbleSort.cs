using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers.Sort
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public class BubbleSort : SortBase, IMasterWorker
    {
        public void Do()
        {
            int temp = 0;
            int[] chaosNumbers = { 23, 44, 66, 76, 98, 11, 3, 9, 7 };
            // index1 = 0
            // index2 = 0
            // 23, 44, 66, 76, 98, 11, 3, 9, 7
            // index2 = 1
            // 23, 44, 66, 76, 98, 11, 3, 9, 7
            // index2 = 2
            // 23, 44, 66, 76, 98, 11, 3, 9, 7
            // index2 = 3
            // 23, 44, 66, 76, 98, 11, 3, 9, 7
            // index2 = 4
            // 23, 44, 66, 76, 11, 98, 3, 9, 7
            // index2 = 5
            // 23, 44, 66, 76, 11, 3, 98, 9, 7
            // index2 = 6
            // 23, 44, 66, 76, 11, 3, 9, 98, 7
            // index2 = 7
            // 23, 44, 66, 76, 11, 3, 9, 7, 98

            // index1 = 1
            // index2 = 0
            // 23, 44, 66, 76, 11, 3, 9, 7, 98
            // index2 = 1
            // 23, 44, 66, 76, 11, 3, 9, 7, 98
            // index2 = 2
            // 23, 44, 66, 76, 11, 3, 9, 7, 98
            // index2 = 3
            // 23, 44, 66, 11, 76, 3, 9, 7, 98
            // index2 = 4
            // 23, 44, 66, 11, 3, 76, 9, 7, 98
            // index2 = 5
            // 23, 44, 66, 11, 3, 9, 76, 7, 98
            // index2 = 6
            // 23, 44, 66, 11, 3, 9, 7, 76, 98

            // index1 = 2
            // index2 = 0
            // 23, 44, 66, 11, 3, 9, 7, 76, 98
            // index2 = 1
            // 23, 44, 66, 11, 3, 9, 7, 76, 98
            // index2 = 2
            // 23, 44, 11, 66, 3, 9, 7, 76, 98
            // index2 = 3
            // 23, 44, 11, 3, 66, 9, 7, 76, 98
            // index2 = 4
            // 23, 44, 11, 3, 9, 66, 7, 76, 98
            // index2 = 5
            // 23, 44, 11, 3, 9, 7, 66, 76, 98

            // index1 = 3
            // idex2 = 0
            // 23, 44, 11, 3, 9, 7, 66, 76, 98
            // idex2 = 1
            // 23, 11, 44, 3, 9, 7, 66, 76, 98
            // idex2 = 2
            // 23, 11, 3, 44, 9, 7, 66, 76, 98
            // idex2 = 3
            // 23, 11, 3, 9, 44, 7, 66, 76, 98
            // idex2 = 4
            // 23, 11, 3, 9, 7, 44, 66, 76, 98

            // index1 = 4
            // index2 = 0
            // 11, 23, 3, 9, 7, 44, 66, 76, 98
            // index2 = 1
            // 11, 3, 23, 9, 7, 44, 66, 76, 98
            // index2 = 2
            // 11, 3, 9, 23, 7, 44, 66, 76, 98
            // index2 = 3
            // 11, 3, 9, 7, 23, 44, 66, 76, 98

            // index1 = 4
            // index2 = 0
            // 3, 11, 9, 7, 23, 44, 66, 76, 98
            // index2 = 1
            // 3, 9, 11, 7, 23, 44, 66, 76, 98
            // index2 = 2
            // 3, 9, 7, 11, 23, 44, 66, 76, 98

            // index1 = 6
            // index1 = 6
            // index2 = 0
            // 3, 9, 7, 11, 23, 44, 66, 76, 98
            // index2 = 1
            // 3, 7, 9, 11, 23, 44, 66, 76, 98

            // index1 = 7
            // index2 = 0
            // 3, 7, 9, 11, 23, 44, 66, 76, 98

            Console.WriteLine("数组长度：" + chaosNumbers.Length);

            Console.WriteLine("排序前的数组：");
            PrintArray(chaosNumbers);

            for (int index1 = 0; index1 < chaosNumbers.Length - 1; index1++)
            {
                for (int index2 = 0; index2 < chaosNumbers.Length - 1 - index1; index2++)
                {
                    if (chaosNumbers[index2] > chaosNumbers[index2 + 1])
                    {
                        temp = chaosNumbers[index2 + 1];
                        chaosNumbers[index2 + 1] = chaosNumbers[index2];
                        chaosNumbers[index2] = temp;
                    }

                    PrintArray(chaosNumbers);
                }
            }

            Console.WriteLine("排序后的数据：");
            PrintArray(chaosNumbers);
        }
    }
}
