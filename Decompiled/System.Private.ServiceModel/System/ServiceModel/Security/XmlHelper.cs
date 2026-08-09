using System.Text;
using System.Xml;

namespace System.ServiceModel.Security;

internal static class XmlHelper
{
	internal static void AddNamespaceDeclaration(XmlDictionaryWriter writer, string prefix, XmlDictionaryString ns)
	{
		string text = writer.LookupPrefix(ns.Value);
		if (text == null || text != prefix)
		{
			writer.WriteXmlnsAttribute(prefix, ns);
		}
	}

	internal static string EnsureNamespaceDefined(XmlDictionaryWriter writer, XmlDictionaryString ns, string defaultPrefix)
	{
		string text = writer.LookupPrefix(ns.Value);
		if (text == null)
		{
			writer.WriteXmlnsAttribute(defaultPrefix, ns);
			text = defaultPrefix;
		}
		return text;
	}

	internal static XmlQualifiedName GetAttributeValueAsQName(XmlReader reader, string attributeName)
	{
		string attribute = reader.GetAttribute(attributeName);
		if (attribute == null)
		{
			return null;
		}
		return GetValueAsQName(reader, attribute);
	}

	internal static XmlElement GetChildElement(XmlElement parent)
	{
		if (parent == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		}
		XmlElement xmlElement = null;
		for (int i = 0; i < parent.ChildNodes.Count; i++)
		{
			XmlNode xmlNode = parent.ChildNodes[i];
			if (xmlNode.NodeType != XmlNodeType.Whitespace && xmlNode.NodeType != XmlNodeType.Comment)
			{
				if (xmlNode.NodeType == XmlNodeType.Element && xmlElement == null)
				{
					xmlElement = (XmlElement)xmlNode;
				}
				else
				{
					OnUnexpectedChildNodeError(parent, xmlNode);
				}
			}
		}
		if (xmlElement == null)
		{
			OnChildNodeTypeMissing(parent, XmlNodeType.Element);
		}
		return xmlElement;
	}

	internal static XmlElement GetChildElement(XmlElement parent, string childLocalName, string childNamespace)
	{
		if (parent == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		}
		for (int i = 0; i < parent.ChildNodes.Count; i++)
		{
			XmlNode xmlNode = parent.ChildNodes[i];
			if (xmlNode.NodeType == XmlNodeType.Whitespace || xmlNode.NodeType == XmlNodeType.Comment)
			{
				continue;
			}
			if (xmlNode.NodeType == XmlNodeType.Element)
			{
				if (xmlNode.LocalName == childLocalName && xmlNode.NamespaceURI == childNamespace)
				{
					return (XmlElement)xmlNode;
				}
			}
			else
			{
				OnUnexpectedChildNodeError(parent, xmlNode);
			}
		}
		return null;
	}

	internal static XmlQualifiedName GetValueAsQName(XmlReader reader, string value)
	{
		SplitIntoPrefixAndName(value, out var prefix, out var name);
		string text = reader.LookupNamespace(prefix);
		if (text == null && prefix.Length > 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CouldNotFindNamespaceForPrefix, prefix)));
		}
		return new XmlQualifiedName(name, text);
	}

	internal static string GetWhiteSpace(XmlReader reader)
	{
		string text = null;
		StringBuilder stringBuilder = null;
		while (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.SignificantWhitespace)
		{
			if (stringBuilder != null)
			{
				stringBuilder.Append(reader.Value);
			}
			else if (text != null)
			{
				stringBuilder = new StringBuilder(text);
				stringBuilder.Append(reader.Value);
				text = null;
			}
			else
			{
				text = reader.Value;
			}
			if (!reader.Read())
			{
				break;
			}
		}
		if (stringBuilder == null)
		{
			return text;
		}
		return stringBuilder.ToString();
	}

	internal static bool IsWhitespaceOrComment(XmlReader reader)
	{
		if (reader.NodeType == XmlNodeType.Comment)
		{
			return true;
		}
		if (reader.NodeType == XmlNodeType.Whitespace)
		{
			return true;
		}
		return false;
	}

	internal static void OnChildNodeTypeMissing(string parentName, XmlNodeType expectedNodeType)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ChildNodeTypeMissing, parentName, expectedNodeType)));
	}

	internal static void OnChildNodeTypeMissing(XmlElement parent, XmlNodeType expectedNodeType)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ChildNodeTypeMissing, parent.Name, expectedNodeType)));
	}

	internal static void OnEmptyElementError(XmlReader r)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.EmptyXmlElementError, r.Name)));
	}

	internal static void OnEmptyElementError(XmlElement e)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.EmptyXmlElementError, e.Name)));
	}

	internal static void OnEOF()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedEndOfFile)));
	}

	internal static void OnNamespaceMissing(string prefix)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CouldNotFindNamespaceForPrefix, prefix)));
	}

	internal static void OnRequiredAttributeMissing(string attrName, string elementName)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.RequiredAttributeMissing, attrName, elementName)));
	}

	internal static void OnRequiredElementMissing(string elementName, string elementNamespace)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ExpectedElementMissing, elementName, elementNamespace)));
	}

	internal static void OnUnexpectedChildNodeError(string parentName, XmlReader r)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, r.Name, r.NodeType, parentName)));
	}

	internal static void OnUnexpectedChildNodeError(XmlElement parent, XmlNode n)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, n.Name, n.NodeType, parent.Name)));
	}

	internal static string ReadEmptyElementAndRequiredAttribute(XmlDictionaryReader reader, XmlDictionaryString name, XmlDictionaryString namespaceUri, XmlDictionaryString attributeName, out string prefix)
	{
		reader.MoveToStartElement(name, namespaceUri);
		prefix = reader.Prefix;
		bool isEmptyElement = reader.IsEmptyElement;
		string attribute = reader.GetAttribute(attributeName, null);
		if (attribute == null)
		{
			OnRequiredAttributeMissing(attributeName.Value, null);
		}
		reader.Read();
		if (!isEmptyElement)
		{
			reader.ReadEndElement();
		}
		return attribute;
	}

	internal static string GetRequiredNonEmptyAttribute(XmlDictionaryReader reader, XmlDictionaryString name, XmlDictionaryString ns)
	{
		string attribute = reader.GetAttribute(name, ns);
		if (attribute == null || attribute.Length == 0)
		{
			OnRequiredAttributeMissing(name.Value, reader?.Name);
		}
		return attribute;
	}

	internal static byte[] GetRequiredBase64Attribute(XmlDictionaryReader reader, XmlDictionaryString name, XmlDictionaryString ns)
	{
		if (!reader.MoveToAttribute(name.Value, ns?.Value))
		{
			OnRequiredAttributeMissing(name.Value, ns?.Value);
		}
		byte[] array = reader.ReadContentAsBase64();
		if (array == null || array.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.EmptyBase64Attribute, name, ns)));
		}
		return array;
	}

	internal static string ReadTextElementAsTrimmedString(XmlElement element)
	{
		if (element == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
		}
		using XmlReader xmlReader = new XmlNodeReader(element);
		xmlReader.MoveToContent();
		return XmlUtil.Trim(xmlReader.ReadElementContentAsString());
	}

	internal static void SplitIntoPrefixAndName(string qName, out string prefix, out string name)
	{
		string[] array = qName.Split(new char[1] { ':' });
		if (array.Length > 2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.InvalidQName));
		}
		if (array.Length == 2)
		{
			prefix = array[0].Trim();
			name = array[1].Trim();
		}
		else
		{
			prefix = string.Empty;
			name = qName.Trim();
		}
	}

	internal static void ValidateIdPrefix(string idPrefix)
	{
		if (idPrefix == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("idPrefix"));
		}
		if (idPrefix.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("idPrefix", System.SR.Format(System.SR.ValueMustBeGreaterThanZero)));
		}
		if (!char.IsLetter(idPrefix[0]) && idPrefix[0] != '_')
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("idPrefix", System.SR.Format(System.SR.InValidateIdPrefix, idPrefix[0])));
		}
		for (int i = 1; i < idPrefix.Length; i++)
		{
			char c = idPrefix[i];
			if (!char.IsLetter(c) && !char.IsNumber(c) && c != '.' && c != '_' && c != '-')
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("idPrefix", System.SR.Format(System.SR.InValidateId, idPrefix[i])));
			}
		}
	}

	internal static UniqueId GetAttributeAsUniqueId(XmlDictionaryReader reader, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		return GetAttributeAsUniqueId(reader, localName.Value, ns?.Value);
	}

	private static UniqueId GetAttributeAsUniqueId(XmlDictionaryReader reader, string name, string ns)
	{
		if (!reader.MoveToAttribute(name, ns))
		{
			return null;
		}
		UniqueId result = reader.ReadContentAsUniqueId();
		reader.MoveToElement();
		return result;
	}

	public static void WriteAttributeStringAsUniqueId(XmlDictionaryWriter writer, string prefix, XmlDictionaryString localName, XmlDictionaryString ns, UniqueId id)
	{
		writer.WriteStartAttribute(prefix, localName, ns);
		writer.WriteValue(id);
		writer.WriteEndAttribute();
	}

	public static void WriteElementStringAsUniqueId(XmlWriter writer, string localName, UniqueId id)
	{
		writer.WriteStartElement(localName);
		writer.WriteValue(id);
		writer.WriteEndElement();
	}

	public static void WriteElementStringAsUniqueId(XmlDictionaryWriter writer, XmlDictionaryString localName, XmlDictionaryString ns, UniqueId id)
	{
		writer.WriteStartElement(localName, ns);
		writer.WriteValue(id);
		writer.WriteEndElement();
	}

	public static void WriteElementContentAsInt64(XmlDictionaryWriter writer, XmlDictionaryString localName, XmlDictionaryString ns, long value)
	{
		writer.WriteStartElement(localName, ns);
		writer.WriteValue(value);
		writer.WriteEndElement();
	}

	public static long ReadElementContentAsInt64(XmlDictionaryReader reader)
	{
		reader.ReadFullStartElement();
		long result = reader.ReadContentAsLong();
		reader.ReadEndElement();
		return result;
	}

	public static void WriteStringAsUniqueId(XmlDictionaryWriter writer, UniqueId id)
	{
		writer.WriteValue(id);
	}

	public static UniqueId ReadElementStringAsUniqueId(XmlDictionaryReader reader, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		if (reader.IsStartElement(localName, ns) && reader.IsEmptyElement)
		{
			reader.Read();
			return new UniqueId(string.Empty);
		}
		reader.ReadStartElement(localName, ns);
		UniqueId result = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		return result;
	}

	public static UniqueId ReadElementStringAsUniqueId(XmlDictionaryReader reader)
	{
		if (reader.IsStartElement() && reader.IsEmptyElement)
		{
			reader.Read();
			return new UniqueId(string.Empty);
		}
		reader.ReadStartElement();
		UniqueId result = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		return result;
	}

	public static UniqueId ReadTextElementAsUniqueId(XmlElement element)
	{
		return new UniqueId(ReadTextElementAsTrimmedString(element));
	}
}
