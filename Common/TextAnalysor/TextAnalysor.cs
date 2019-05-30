using Model.CustomisedAttribute;
using Model.Socket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.TextAnalysor
{
    public class TextAnalysor
    {
        private const string ENCODING_UTF8 = "UTF-8";

        /// <summary>
        /// Constructor
        /// </summary>
        private TextAnalysor() { }

        /// <summary>
        /// 解析对账汇总
        /// </summary>
        /// <param name="textByte"></param>
        /// <param name="offSet"></param>
        /// <returns></returns>
        public static BillCheckingSummary AnalyseToBillCheckingSummary(byte[] textByte, ref int offSet)
        {
            if (textByte == null || textByte.Length == 0)
            {
                throw new ArgumentNullException("textByte");
            }

            PropertyInfo[] sortedProperties = SortPropertyInfo(typeof(BillCheckingSummary).GetProperties());
            string text = Encoding.GetEncoding(ENCODING_UTF8).GetString(textByte);

            return ParseFromBytes<BillCheckingSummary>(text, sortedProperties, ref offSet);
        }

        /// <summary>
        /// 解析对账详情
        /// </summary>
        /// <param name="textByte">文件字节数组</param>
        /// <param name="cycleCount">循环次数</param>
        /// <param name="offSet">偏移量</param>
        /// <returns></returns>
        public static List<BillCheckingDetail> AnalyseToBillCheckingDetails(byte[] textByte, int cycleCount, int offSet)
        {
            if (textByte == null || textByte.Length == 0)
            {
                throw new ArgumentNullException("textByte");
            }

            PropertyInfo[] sortedProperties = SortPropertyInfo(typeof(BillCheckingDetail).GetProperties());
            List<BillCheckingDetail> details = new List<BillCheckingDetail>();
            string text = Encoding.GetEncoding(ENCODING_UTF8).GetString(textByte);

            for (int index = 0; index < cycleCount; index++)
            {
                BillCheckingDetail detail = ParseFromBytes<BillCheckingDetail>(text, sortedProperties, ref offSet);
                details.Add(detail);
            }

            return details;
        }

        /// <summary>
        /// 按照字符串对T进行赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originText"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private static T ParseFromBytes<T>(string originText, PropertyInfo[] properties, ref int offset) where T : class
        {
            T instance = Activator.CreateInstance<T>();

            for (int index = 0; index < properties.Length; index++)
            {
                PropertyInfo property = properties[index];
                if (property == null)
                {
                    continue;
                }

                SectionAttribute sectionAttribute = (SectionAttribute)property.GetCustomAttribute(typeof(SectionAttribute));

                string section = originText.Substring(offset, sectionAttribute.Length).Trim();

                //Property赋值
                if (property.PropertyType.Equals(typeof(string)))
                {
                    property.SetValue(instance, section);
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

            //\r\n换行符和回车占两个字符
            offset += 2;

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
