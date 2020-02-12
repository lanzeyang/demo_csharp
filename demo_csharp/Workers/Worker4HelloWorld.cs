using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 打印Hello World
    /// </summary>
    public class Worker4HelloWorld : IMasterWorker
    {
        public void Do()
        {
            List<int> ids = new List<int>();
            Console.WriteLine(string.Join(",", ids));
            Console.WriteLine("Hello World");
        }
    }
}
