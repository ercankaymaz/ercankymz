using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public class ApplicationConfigurationSection
{
	public object Create(object parent, object configContext, XmlNode section)
	{
		if (section == null)
		{
			throw new ArgumentNullException("section");
		}
		XmlNode xmlNode = section.FirstChild;
		while (xmlNode != null && typeof(XmlElement) != xmlNode.GetType())
		{
			xmlNode = xmlNode.NextSibling;
		}
		using XmlReader reader = XmlReader.Create(new StringReader(xmlNode.OuterXml), Utils.DefaultXmlReaderSettings());
		return new DataContractSerializer(typeof(ConfigurationLocation)).ReadObject(reader) as ConfigurationLocation;
	}
}
