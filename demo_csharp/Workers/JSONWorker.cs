using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        }
    }
}
