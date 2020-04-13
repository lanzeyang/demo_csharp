using demo_csharp.Workers.IWorkService;
using System;
using System.Text.RegularExpressions;

namespace demo_csharp.Workers
{
    public class RegxWorker : IMasterWorker
    {
        public void Do()
        {
            Regex regx = new Regex(@"^3|3\#\w*$");
            Console.WriteLine(regx.IsMatch("1"));
            Console.WriteLine(regx.IsMatch("3"));
            Console.WriteLine(regx.IsMatch("3#123456"));
            Console.WriteLine("3#123456".Substring(2));
            Console.WriteLine(regx.IsMatch("4"));
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
