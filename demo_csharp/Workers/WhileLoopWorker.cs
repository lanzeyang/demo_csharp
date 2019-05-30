using demo_csharp.Workers.IWorkService;

namespace demo_csharp.Workers
{
    public class WhileLoopWorker : IMasterWorker
    {
        public void Do()
        {
            bool flag = true;
            int index = 0;
            while (flag)
            {
                index++;
                if (index.Equals(100))
                {
                    break;
                }
            }
        }
    }
}
