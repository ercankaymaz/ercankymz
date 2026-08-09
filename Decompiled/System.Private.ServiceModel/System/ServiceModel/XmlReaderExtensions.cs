using System.Xml;

namespace System.ServiceModel;

internal static class XmlReaderExtensions
{
	internal static string ReadElementString(this XmlReader reader)
	{
		if (reader.MoveToContent() != XmlNodeType.Element)
		{
			IXmlLineInfo xmlLineInfo = reader as IXmlLineInfo;
			throw new XmlException(System.SR.Format(System.SR.Xml_InvalidNodeType, reader.NodeType.ToString()), null, xmlLineInfo?.LineNumber ?? 0, xmlLineInfo?.LinePosition ?? 0);
		}
		return reader.ReadElementContentAsString();
	}

	internal static string ReadElementString(this XmlReader reader, string localname, string ns)
	{
		if (reader.MoveToContent() != XmlNodeType.Element)
		{
			IXmlLineInfo xmlLineInfo = reader as IXmlLineInfo;
			throw new XmlException(System.SR.Format(System.SR.Xml_InvalidNodeType, reader.NodeType.ToString()), null, xmlLineInfo?.LineNumber ?? 0, xmlLineInfo?.LinePosition ?? 0);
		}
		return reader.ReadElementContentAsString(localname, ns);
	}
}
