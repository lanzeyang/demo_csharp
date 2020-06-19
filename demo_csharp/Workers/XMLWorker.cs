using Common.AssemblyPathHelper;
using demo_csharp.Workers.IWorkService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace demo_csharp.Workers
{
    /// <summary>
    /// XML测试类
    /// </summary>
    public class XMLWorker : IMasterWorker
    {
        public void Do()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"GBK\"?><RetData><RetCode>1</RetCode><RetMsg><![CDATA[单据生成发票时出现错误！红字开票金额-27.5大于可冲红金额0.0]]></RetMsg></RetData>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode firstChild = doc.ChildNodes[1];
            if (firstChild.HasChildNodes)
            {
                Console.WriteLine(firstChild.ChildNodes.Item(0).InnerXml);
                Console.WriteLine(firstChild.ChildNodes.Item(1).InnerXml);

                //foreach (XmlNode node in firstChild.ChildNodes)
                //{
                //    Console.WriteLine("[node name]:{0}, [node xml]:{1}, [node text]:{2}", node.Name, node.InnerXml, node.InnerText);
                //}
            }

            XDocument xmldoc = XDocument.Parse(xml);
            string element = xmldoc.Root.Elements().FirstOrDefault(p => p.Name == "RetMsg").Value;

            //AnalyseXMLFromFile();
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
