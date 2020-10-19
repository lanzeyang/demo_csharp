using Model.CustomisedAttribute;
using Model.Socket;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    /// <summary>
    /// 解析器
    /// </summary>
    public sealed class MessageAnalysor
    {
        private const string ENCODING_GBK = "GBK";

        /// <summary>
        /// Constructor
        /// </summary>
        private MessageAnalysor() { }

        /// <summary>
        /// 解析欠费
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Arreage AnalyseToArreage(byte[] originBytes)
        {
            if (originBytes == null || originBytes.Length == 0)
            {
                throw new ArgumentNullException("originBytes");
            }

            Arreage result = new Arreage();
            int offset = 0;

            //head
            result = ParseFromBytes<Arreage>(originBytes, ref offset);
            //body
            for (int index = 0; index < result.Count; index++)
            {
                ArreageDetail billDetail = ParseFromBytes<ArreageDetail>(originBytes, ref offset);
                result.ArreageDetails.Add(billDetail);
            }

            return result;
        }

        /// <summary>
        /// 解析账单
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Bill AnalyseToBill(byte[] originBytes)
        {
            if (originBytes == null || originBytes.Length == 0)
            {
                throw new ArgumentNullException("originBytes");
            }

            Bill result = new Bill();
            int offset = 0;

            //head
            result = ParseFromBytes<Bill>(originBytes, ref offset);
            //body
            for (int index = 0; index < result.Count; index++)
            {
                BillDetail billDetail = ParseFromBytes<BillDetail>(originBytes, ref offset);
                result.BillDetails.Add(billDetail);
            }

            return result;
        }

        /// <summary>
        /// 按照未转码的byte数组对T的各属性进行赋值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="originBytes">未进行GBK转码的密文解析结果</param>
        /// <returns>T的实例</returns>
        private static T ParseFromBytes<T>(byte[] originBytes, ref int offset) where T : class
        {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo[] sortedProperties = SortPropertyInfo(typeof(T).GetProperties());

            for (int index = 0; index < sortedProperties.Length; index++)
            {
                PropertyInfo property = sortedProperties[index];
                if (property == null)
                {
                    continue;
                }

                SectionAttribute sectionAttribute = (SectionAttribute)property.GetCustomAttribute(typeof(SectionAttribute));

                byte[] sectionBytes = originBytes.Skip(offset).Take(sectionAttribute.Length).ToArray();
                string section = Encoding.GetEncoding(ENCODING_GBK).GetString(sectionBytes);

                //Property赋值
                if (property.PropertyType.Equals(typeof(string)))
                {
                    //去除左右空格
                    property.SetValue(instance, section.Trim());
                }

                if (property.PropertyType.Equals(typeof(int)))
                {
                    int temp = 0;
                    Int32.TryParse(section, out temp);
                    property.SetValue(instance, temp);
                }

                if (property.PropertyType.Equals(typeof(decimal)))
                {
                    decimal temp = 0;
                    Decimal.TryParse(section, out temp);
                    property.SetValue(instance, temp);
                }

                offset += sectionAttribute.Length;
            }

            return instance;
        }

        /// <summary>
        /// 按照Section特性的index对各属性排序
        /// </summary>
        /// <param name="defaultPropertyInfos">默认的属性数组</param>
        /// <returns></returns>
        private static PropertyInfo[] SortPropertyInfo(PropertyInfo[] defaultPropertyInfos)
        {
            PropertyInfo[] sortedProperties = new PropertyInfo[defaultPropertyInfos.Length];

            for (int index = 0; index < defaultPropertyInfos.Length; index++)
            {
                PropertyInfo property = defaultPropertyInfos[index];
                Attribute attribute = property.GetCustomAttribute(typeof(SectionAttribute));
                if (attribute == null)
                {
                    continue;
                }

                SectionAttribute sectionAttribute = (SectionAttribute)attribute;

                sortedProperties[sectionAttribute.Index - 1] = property;
            }

            return sortedProperties;
        }
    }
}