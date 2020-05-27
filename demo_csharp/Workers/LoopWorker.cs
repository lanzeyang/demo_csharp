using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    public class LoopWorker : IMasterWorker
    {
        public void Do()
        {
            int n = 20;
            for (int i = 0; i < n; n--)
            {
                Console.WriteLine("-");
            }
        }
    }
}
