using System.IO;
using System.Linq;
using System.Xml;

namespace Google_Project____Hao_Li
{
    public class XmlConfigRW
    {
        private string _xmlPath;
        private string _rootName = "XmlConfig";

        public XmlConfigRW(string xmlPath, string rootName)
        {
            _xmlPath = Path.GetFullPath(xmlPath);
            _rootName = rootName;
        }

        public void Write(string value, params string[] nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath))
            {
                xmlDoc.Load(_xmlPath);
            }
            else
            {
                //xmlDoc.LoadXml("<XmlConfig />");
                xmlDoc.LoadXml("<" + _rootName + "/>");
            }

            XmlNode xmlRoot = xmlDoc.DocumentElement; ;

            string xpath = string.Join("/", nodes);
            XmlNode node = xmlDoc.SelectSingleNode(xpath);
            if (node == null)
            {
                node = makeXPath(xmlDoc, xmlRoot, xpath);
            }
            node.InnerText = value;
            xmlDoc.Save(_xmlPath);
        }

        public string Read(params string[] nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath) == false)
            {
                return null;
            }
            xmlDoc.Load(_xmlPath);
            string xpath = string.Join("/", nodes);
            XmlNode node = xmlDoc.SelectSingleNode(@"/" + _rootName + @"/" + xpath);
            return node?.InnerText;
        }

        XmlNode makeXPath(XmlDocument xmlDoc, XmlNode xmlParent, string xpath)
        {
            string[] partsOfXPath = xpath.Trim('/').Split('/');
            string childNodeInXPath = partsOfXPath.First();
            if (string.IsNullOrEmpty(childNodeInXPath))
            {
                return xmlParent;
            }
            XmlNode node = xmlParent.SelectSingleNode(childNodeInXPath);
            if (node == null)
            {
                node = xmlParent.AppendChild(xmlDoc.CreateElement(childNodeInXPath));
            }

            string rest = string.Join("/", partsOfXPath.Skip(1).ToArray());
            return makeXPath(xmlDoc, node, rest);
        }
    }
}