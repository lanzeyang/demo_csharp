using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    public class ArrayWorker : IMasterWorker
    {
        public void Do()
        {
            int[] source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            int[] result = new int[source.Length - 1];

            Array.Copy(source, 1, result, 0, source.Length - 1);

            Console.WriteLine(result);
        }
    }
}
