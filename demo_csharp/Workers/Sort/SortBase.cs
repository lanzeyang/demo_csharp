using System;

namespace demo_csharp.Workers.Sort
{
    public class SortBase
    {
        protected static int[] ChaosArray = { 23, 66, 44, 76, 7, 11, 3, 9, 98, 1 };

        protected void PrintArray(int[] array, string seprator = " ")
        {
            Console.WriteLine(string.Join(seprator, array));
        }
    }
}
