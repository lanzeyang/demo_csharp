using demo_csharp.Workers.IWorkService;
using Model.Enum;
using System;
using System.Text;

namespace demo_csharp.Workers
{
    public class EnumWorker : IMasterWorker
    {
        public void Do()
        {
            FeeType waterFee = FeeType.DEPOSIT;
            Console.WriteLine(waterFee.ToString());

            Console.WriteLine(1.Equals(FeeType.WATER_FEE));

            TestHasValue(FeeType.DEPOSIT);

            byte[] padZero = Encoding.UTF8.GetBytes("0");
            Console.WriteLine(padZero.Length);
            byte[] padSpace = Encoding.UTF8.GetBytes(" ");
            byte[] padChinese = Encoding.UTF8.GetBytes("练");
            Console.WriteLine(padChinese.Length);

            string s1 = "123";
            s1 += "4";
            Console.WriteLine(s1);

            StringBuilder builder = new StringBuilder(100);
            builder.Append("1");
            builder.AppendLine(string.Empty);

            string builderString = builder.ToString();
        }

        private void TestHasValue(FeeType? feeType = null)
        {
            if (feeType.HasValue)
            {
                Console.WriteLine("enum has value");
                return;
            }

            Console.WriteLine("enum does not have value");
        }
    }
}
