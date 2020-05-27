using demo_csharp.Workers.IWorkService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo_csharp.Workers
{
    public class LinqWorker : IMasterWorker
    {
        public void Do()
        {
            List<WaterFee> fees = new List<WaterFee>();
            fees.Add(new WaterFee { Name = "用水费", Volume = 10, Money = 20m });
            fees.Add(new WaterFee { Name = "用水费", Volume = 10, Money = 15m });
            fees.Add(new WaterFee { Name = "污水费", Volume = 10, Money = 15m });
            fees.Add(new WaterFee { Name = "污水费", Volume = 10, Money = 5m });

            var groupedFees = from item in fees
                              group item by item.Name into temp
                              select new WaterFee
                              {
                                  Name = temp.Key,
                                  Volume = temp.Max(item => item.Volume),
                                  Money = temp.Sum(item => item.Money)
                              };

            foreach(WaterFee item in groupedFees)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Volume);
                Console.WriteLine(item.Money);
            }
        }
    }
}
