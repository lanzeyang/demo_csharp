using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Linq;

namespace Common.UnityHelper
{
    public sealed class UnityHelper
    {
        #region Fields
        private static UnityContainer unityContainer = null;
        private static readonly object unityContainerLockHelper = new object();
        private static string[] UNITY_CONTAINER_WITH_MULTI_REGISTERS = ConfigurationManager.AppSettings["UnityContainerWithMultiRegisters"].Split(',');
        #endregion

        #region Constructors

        private UnityHelper() { }

        #endregion

        #region Public Methods
        /// <summary>
        /// 以单例模式注册UnityContainer
        /// </summary>
        public static UnityContainer RegisterUnityContainer()
        {
            if (unityContainer != null)
            {
                return unityContainer;
            }

            lock (unityContainerLockHelper)
            {
                if (unityContainer != null)
                {
                    return unityContainer;
                }

                unityContainer = new UnityContainer();

                //获取Unity的配置文件
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = AssemblyPathHelper.AssemblyPathHelper.GetAssemblyPath() + "Configs/unity.service.config";

                //读取配置
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                UnityConfigurationSection unityConfig = (UnityConfigurationSection)config.GetSection(UnityConfigurationSection.SectionName);

                UNITY_CONTAINER_WITH_MULTI_REGISTERS.ToList().ForEach(item => unityConfig.Configure(unityContainer, item.Trim()));

                return unityContainer;
            }
        }

        #endregion
    }
}
