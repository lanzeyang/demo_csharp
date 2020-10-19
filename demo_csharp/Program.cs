using Common.UnityHelper;
using demo_csharp.Workers.IWorkService;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;

namespace demo_csharp
{
    /// <summary>
    /// 程序入口
    /// </summary>
    public class Program
    {
        #region Configurations
        private static string WORKER_ON_DUTY = ConfigurationManager.AppSettings["WorkerOnDuty"];
        #endregion

        public static void Main(string[] args)
        {
            try
            {
                IUnityContainer unityContainer = UnityHelper.RegisterUnityContainer();
                IMasterWorker worker = unityContainer.Resolve<IMasterWorker>(WORKER_ON_DUTY);
                worker.Do();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }

            Console.ReadKey();
        }
    }
}
