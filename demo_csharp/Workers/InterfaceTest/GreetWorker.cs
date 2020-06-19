using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers.InterfaceTest
{
    public class GreetWorker : IMasterWorker
    {
        public void Do()
        {
            IGreet greeter_1 = new NewYearGreet();
            SayGreet(greeter_1);

            IGreet greeter_2 = new ChristmasGreet();
            SayGreet(greeter_2);

            IGreet greeter_3 = new ThanksGivingGreet();
            SayGreet(greeter_3);
        }

        private void SayGreet(IGreet greeter)
        {
            Console.WriteLine(greeter.Greet());
        }
    }
}
