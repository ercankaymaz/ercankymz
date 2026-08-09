using System.Xml;

namespace System.ServiceModel.Channels;

internal struct XmlAttributeHolder(string prefix, string localName, string ns, string value)
{
	private string _value = value;

	public static XmlAttributeHolder[] emptyArray = new XmlAttributeHolder[0];

	public string Prefix { get; } = prefix;

	public string NamespaceUri { get; } = ns;

	public string LocalName { get; } = localName;

	public string Value => _value;

	public void WriteTo(XmlWriter writer)
	{
		writer.WriteStartAttribute(Prefix, LocalName, NamespaceUri);
		writer.WriteString(_value);
		writer.WriteEndAttribute();
	}

	public static void WriteAttributes(XmlAttributeHolder[] attributes, XmlWriter writer)
	{
		for (int i = 0; i < attributes.Length; i++)
		{
			attributes[i].WriteTo(writer);
		}
	}

	public static XmlAttributeHolder[] ReadAttributes(XmlDictionaryReader reader)
	{
		int maxSizeOfHeaders = int.MaxValue;
		return ReadAttributes(reader, ref maxSizeOfHeaders);
	}

	public static XmlAttributeHolder[] ReadAttributes(XmlDictionaryReader reader, ref int maxSizeOfHeaders)
	{
		if (reader.AttributeCount == 0)
		{
			return emptyArray;
		}
		XmlAttributeHolder[] array = new XmlAttributeHolder[reader.AttributeCount];
		reader.MoveToFirstAttribute();
		for (int i = 0; i < array.Length; i++)
		{
			string namespaceURI = reader.NamespaceURI;
			string localName = reader.LocalName;
			string prefix = reader.Prefix;
			string text = string.Empty;
			while (reader.ReadAttributeValue())
			{
				text = ((text.Length != 0) ? (text + reader.Value) : reader.Value);
			}
			Deduct(prefix, ref maxSizeOfHeaders);
			Deduct(localName, ref maxSizeOfHeaders);
			Deduct(namespaceURI, ref maxSizeOfHeaders);
			Deduct(text, ref maxSizeOfHeaders);
			array[i] = new XmlAttributeHolder(prefix, localName, namespaceURI, text);
			reader.MoveToNextAttribute();
		}
		reader.MoveToElement();
		return array;
	}

	private static void Deduct(string s, ref int maxSizeOfHeaders)
	{
		int num = s.Length * 2;
		if (num > maxSizeOfHeaders)
		{
			string xmlBufferQuotaExceeded = System.SR.XmlBufferQuotaExceeded;
			Exception innerException = new QuotaExceededException(xmlBufferQuotaExceeded);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(xmlBufferQuotaExceeded, innerException));
		}
		maxSizeOfHeaders -= num;
	}

	public static string GetAttribute(XmlAttributeHolder[] attributes, string localName, string ns)
	{
		for (int i = 0; i < attributes.Length; i++)
		{
			if (attributes[i].LocalName == localName && attributes[i].NamespaceUri == ns)
			{
				return attributes[i].Value;
			}
		}
		return null;
	}
}
