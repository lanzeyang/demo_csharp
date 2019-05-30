using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    public class LoopWorker : IMasterWorker
    {
        public void Do()
        {
            int tradeNo = 0;
            for (int index = 0; index < 100; index++)
            {
                Console.WriteLine(index);
                tradeNo++;
                Console.WriteLine(tradeNo);
            }
        }
    }
}
