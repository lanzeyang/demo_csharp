using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class TupleWorker : IMasterWorker
    {
        public void Do()
        {
            Tuple<string, string> id2Name = new Tuple<string, string>("1", "lianzeyang");

            Console.WriteLine(id2Name.Item1);
        }
    }
}
