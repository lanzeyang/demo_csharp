using demo_csharp.Workers.IWorkService;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class ListJsonWorker : IMasterWorker
    {
        public void Do()
        {
            string result = "{\"errcode\":0,\"errmsg\":\"ok\",\"msgid\":1002084479206293504}";
            JsonData jd = JsonMapper.ToObject(result);

            Console.WriteLine(jd[0].ToString());
        }
    }
}
