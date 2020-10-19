using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ_N_SMS;

namespace demo_csharp.Workers
{
    public class SMSWorker : IMasterWorker
    {
        public void Do()
        {
            WZ_Sms sms = new WZ_Sms();
            string sendResult = sms.CallSms("224342", "wz_sms", "wzzls,123", "测试", "13127571386", "9999", null, "1", "", "", "");
            Console.WriteLine(sendResult);

            SMS_SERVICE.SmsPortTypeClient client = new SMS_SERVICE.SmsPortTypeClient();
            sendResult =  client.Sms("224342", "wz_sms", "wzzls,123", "测试", "13127571386", "9999", null, "1", "", "", "");
            Console.WriteLine(sendResult);

        }
    }
}
