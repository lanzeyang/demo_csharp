using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Common.UnityHelper
{
    public sealed class UnityHelper
    {
        #region Fields
        private static UnityContainer unityContainer = null;
        private static readonly object unityContainerLockHelper = new object();
        private static string[] UNITY_CONTAINER_WITH_MULTI_REGISTERS = ConfigurationManager.AppSettings["UnityContainerWithMultiRegisters"].Split(',');
        private static Dictionary<string, IUnityContainer> containers = new Dictionary<string, IUnityContainer>();
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

        /// <summary>
        /// 通过文件路径获取Unity配置
        /// </summary>
        /// <typeparam name="TSection">Unity配置</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <param name="sectionName">配置节点名称，默认unity</param>
        /// <returns></returns>
        public static TSection GetSection<TSection>(string filePath = "Configs/unity.service.config", string sectionName = "unity") where TSection : class
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath null");
            }

            if (string.IsNullOrEmpty(sectionName))
            {
                throw new ArgumentNullException("sectionName null");
            }

            //获取Unity的配置文件
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = Path.Combine(AssemblyPathHelper.AssemblyPathHelper.GetAssemblyPath(), filePath);

            //读取配置
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if (config != null)
            {
                return config.GetSection(UnityConfigurationSection.SectionName) as TSection;
            }

            return default(TSection);
        }

        /// <summary>
        /// 注册IUnityContainer
        /// </summary>
        /// <param name="section"></param>
        /// <param name="containerName"></param>
        /// <param name="parentContainer"></param>
        /// <returns></returns>
        public static IUnityContainer GetContainer(UnityConfigurationSection section, string containerName, IUnityContainer parentContainer)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }

            IUnityContainer unityContainer;

            if (parentContainer == null)
            {
                unityContainer = new UnityContainer();
            }
            else
            {
                unityContainer = parentContainer.CreateChildContainer();
            }

            if (string.IsNullOrEmpty(containerName))
            {
                section.Configure(unityContainer);
            }
            else
            {
                section.Configure(unityContainer, containerName);
            }

            return unityContainer;
        }

        public static IUnityContainer GetContainer(string configFilePath, string containerName, IUnityContainer parentContainer)
        {
            try
            {
                string text = containerName;
                if (text == null)
                {
                    text = string.Empty;
                }
                string key = configFilePath + "_" + text;
                if (!containers.ContainsKey(key))
                {
                    UnityConfigurationSection section = GetSection<UnityConfigurationSection>(configFilePath, UnityConfigurationSection.SectionName);
                    IUnityContainer container = GetContainer(section, text, parentContainer);
                    containers[key] = container;
                }

                return containers[key];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
