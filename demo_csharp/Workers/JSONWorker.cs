using demo_csharp.Workers.IWorkService;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace demo_csharp.Workers
{
    public class JSONWorker : IMasterWorker
    {
        public void Do()
        {
            WaterFee fee = new WaterFee
            {
                Name = "用水费",
                Volume = 100,
                Money = 200m
            };

            Console.WriteLine(JsonConvert.SerializeObject(fee));
        }
    }
}
