using demo_csharp.Workers.IWorkService;
using System;
using System.Text.RegularExpressions;

namespace demo_csharp.Workers
{
    public class RegxWorker : IMasterWorker
    {
        public void Do()
        {
            Regex regx = new Regex(@"^\d{4}(0[1-9]|1[0-2])\d{2}$");
            Console.WriteLine(regx.IsMatch("20180149"));
            Console.WriteLine(regx.IsMatch("201802"));
            Console.WriteLine(regx.IsMatch("201803"));
            Console.WriteLine(regx.IsMatch("201804"));
            Console.WriteLine(regx.IsMatch("201805"));
            Console.WriteLine(regx.IsMatch("201806"));
            Console.WriteLine(regx.IsMatch("201807"));
            Console.WriteLine(regx.IsMatch("201808"));
            Console.WriteLine(regx.IsMatch("201809"));
            Console.WriteLine(regx.IsMatch("201810"));
            Console.WriteLine(regx.IsMatch("201811"));
            Console.WriteLine(regx.IsMatch("201812"));
            Console.WriteLine(regx.IsMatch(null));
        }
    }
}
