using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 打印Hello Jack
    /// </summary>
    public class Worker4HelloJack : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("Hello Jack");
        }
    }
}
