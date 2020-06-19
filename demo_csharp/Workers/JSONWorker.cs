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
            JObject result = new JObject();
            result.Add("appId", "wx2421b1c4370ec43b");
            result.Add("timeStamp", "1395712654");
            result.Add("nonceStr", "e61463f8efa94090b1f366cccfbbb444");
            result.Add("package", "prepay_id=u802345jgfjsdfgsdg888");
            result.Add("signType", "MD5");
            result.Add("paySign", "70EA570631E4BB79628FBCA90534C63FF7FADD89");

            Console.WriteLine(result.ToString());
            Console.WriteLine(result["xxx"]);

            Film film = new Film();
            film.Name = "流浪地球";
            film.Year = 2019;

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            Console.WriteLine(JsonConvert.SerializeObject(film));
        }
    }
}
