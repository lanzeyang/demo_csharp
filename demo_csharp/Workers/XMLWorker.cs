using Common.AssemblyPathHelper;
using demo_csharp.Workers.IWorkService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml;

namespace demo_csharp.Workers
{
    /// <summary>
    /// XML测试类
    /// </summary>
    public class XMLWorker : IMasterWorker
    {
        public void Do()
        {
            AnalyseSwiftpassPayResponse();   
        }

        private void AnalyseXMLFromFile()
        {
            string filePath = AssemblyPathHelper.GetAssemblyPath() + "Resource/PaymentNotification.xml";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not exist");
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode firstChild = doc.FirstChild;
            if (firstChild.HasChildNodes)
            {
                foreach (XmlNode node in firstChild.ChildNodes)
                {
                    Console.WriteLine("[node name]:{0}, [node xml]:{1}, [node text]:{2}", node.Name, node.InnerXml, node.InnerText);
                }
            }
        }

        private void AnalyseSwiftpassPayResponse()
        { 
            string filePath = AssemblyPathHelper.GetAssemblyPath() + "Resource/SwiftPayResponse.xml";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not exist");
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode nodes = doc.FirstChild;

            string status = nodes.SelectSingleNode("status").InnerText;
            string resultCode = nodes.SelectSingleNode("result_code").InnerText;
            string payInfoNodeJson = nodes.SelectSingleNode("pay_info").InnerText;

            JObject payInfoObj = (JObject)JsonConvert.DeserializeObject(payInfoNodeJson);
        }
    }
}
