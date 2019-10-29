using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class IntReverseWorker : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine(Reverse(-2147483648));
        }

        public int Reverse(int x)
        {
            if (x.Equals(0))
            {
                return x;
            }

            if (x.Equals(Int32.MinValue))
            {
                return 0;
            }

            string originString = string.Empty;
            char[] originArray = Math.Abs(x).ToString().ToArray();

            Array.Reverse(originArray);

            int result = 0;
            Int32.TryParse(new string(originArray), out result);

            if (result != 0)
            {
                if (x < 0)
                {
                    return -result;
                }
            }

            return result;
        }
    }
}
