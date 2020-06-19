using demo_csharp.Workers.IWorkService;
using System;

namespace demo_csharp.Workers
{
    public class ExceptionWorker : IMasterWorker
    {
        public void Do()
        {
            try
            {
                for (int index = 0; index < 100; index++)
                {
                    throw new AccessViolationException();
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                Do();
            }
        }
    }
}
