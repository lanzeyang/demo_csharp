using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class CalculatorWorker : IMasterWorker
    {
        public void Do()
        {
            int amount = 10;
            int balance = 4;
            amount -= balance;
            Console.WriteLine(amount);
        }
    }
}
