using demo_csharp.Workers.IWorkService;
using Model.Customer;
using Newtonsoft.Json;
using System;

namespace demo_csharp.Workers
{
    public class CustomerServiceWorker : IMasterWorker
    {
        public void Do()
        {
            CustomerService.CustomerServicePortTypeClient client = new CustomerService.CustomerServicePortTypeClient();
            string result = client.QueryInfo("100194049");

            CustomerServiceResult customerResult = JsonConvert.DeserializeObject<CustomerServiceResult>(result);

            Console.WriteLine(customerResult.Code);
            Console.WriteLine(customerResult.Message);
            Console.WriteLine(customerResult.Data);

        }
    }
}
