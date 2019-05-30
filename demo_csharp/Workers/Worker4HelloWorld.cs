using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 打印Hello World
    /// </summary>
    public class Worker4HelloWorld : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine("Hello World");
        }
    }
}
