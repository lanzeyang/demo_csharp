using System.Reflection;

namespace Common.AssemblyPathHelper
{
    public sealed class AssemblyPathHelper
    {
        private AssemblyPathHelper() { }

        /// <summary>
        /// 获取当前程序集的目录
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyPath()
        {
            string fullAssemblyPath = Assembly.GetExecutingAssembly().CodeBase;
            fullAssemblyPath = fullAssemblyPath.Substring(8, fullAssemblyPath.Length - 8);

            string[] pathSection = fullAssemblyPath.Split('/');

            string result = string.Empty;
            for (int index = 0; index < pathSection.Length - 1; index++)
            {
                result += pathSection[index] + "/";
            }

            return result;
        }
    }
}
