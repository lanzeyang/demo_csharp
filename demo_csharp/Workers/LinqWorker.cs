using demo_csharp.Workers.IWorkService;
using Model;
using Model.Product;
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

            foreach (WaterFee item in groupedFees)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Volume);
                Console.WriteLine(item.Money);
            }

            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "AMD CPU" });
            products.Add(new Product { Id = 2, Name = "Intel CPU" });
            products.Add(new Product { Id = 3, Name = "Samsung CPU" });
            products.Add(new Product { Id = 4, Name = "Huawei CPU" });
            List<Order> orders = new List<Order>();
            orders.Add(new Order { Id = 1, ProductId = 1 });
            orders.Add(new Order { Id = 1, ProductId = 2 });
            orders.Add(new Order { Id = 1, ProductId = 3 });
            orders.Add(new Order { Id = 1, ProductId = 4 });

            var orderDetail = from a in products
                              join b in orders on a.Id equals b.ProductId
                              select new { Id = b.Id, ProductId = a.Id, ProductName = a.Name };

            foreach (var item in orderDetail)
            {
                Console.WriteLine(string.Format("ProductId:{0},ProductName:{1}", item.ProductId, item.ProductName));
            }
        }
    }
}
