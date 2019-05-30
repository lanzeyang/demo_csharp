using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class SwitchCaseWorker : IMasterWorker
    {
        public void Do()
        {
            int num = 1;
            switch (num)
            {
                case 0:
                case 2:
                case 4:
                    Console.WriteLine("这是偶数");
                    break;
                case 1:
                case 3:
                case 5:
                    Console.WriteLine("这是奇数");
                    break;
                default:
                    Console.WriteLine("负数");
                    break;
            }
        }
    }
}
