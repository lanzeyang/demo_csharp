using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Common.XmlHelper
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public sealed class XmlHelper
    {
        #region Constructors
        private XmlHelper() { }
        #endregion

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">目标Model</typeparam>
        /// <param name="xmlString">XML格式的字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlString) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t) where T : class
        {
            XmlSerializerNamespaces nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Utf8StringWriter stringWriter = new Utf8StringWriter();

            //不使用换行符
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineHandling = NewLineHandling.None;
            settings.Indent = false;

            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, t, nameSpace);
                return stringWriter.ToString();
            }
        }
    }
}
