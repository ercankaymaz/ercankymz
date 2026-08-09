using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XmlDocumentWrapper : XmlNodeWrapper, IXmlDocument, IXmlNode
{
	private readonly XmlDocument _document;

	[Newtonsoft_002EJson_002ENullable(2)]
	public IXmlElement DocumentElement
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get
		{
			if (_document.DocumentElement == null)
			{
				return null;
			}
			return new XmlElementWrapper(_document.DocumentElement);
		}
	}

	public XmlDocumentWrapper(XmlDocument document)
		: base(document)
	{
		_document = document;
	}

	public IXmlNode CreateComment([Newtonsoft_002EJson_002ENullable(2)] string data)
	{
		return new XmlNodeWrapper(_document.CreateComment(data));
	}

	public IXmlNode CreateTextNode([Newtonsoft_002EJson_002ENullable(2)] string text)
	{
		return new XmlNodeWrapper(_document.CreateTextNode(text));
	}

	public IXmlNode CreateCDataSection([Newtonsoft_002EJson_002ENullable(2)] string data)
	{
		return new XmlNodeWrapper(_document.CreateCDataSection(data));
	}

	public IXmlNode CreateWhitespace([Newtonsoft_002EJson_002ENullable(2)] string text)
	{
		return new XmlNodeWrapper(_document.CreateWhitespace(text));
	}

	public IXmlNode CreateSignificantWhitespace([Newtonsoft_002EJson_002ENullable(2)] string text)
	{
		return new XmlNodeWrapper(_document.CreateSignificantWhitespace(text));
	}

	public IXmlNode CreateXmlDeclaration(string version, [Newtonsoft_002EJson_002ENullable(2)] string encoding, [Newtonsoft_002EJson_002ENullable(2)] string standalone)
	{
		return new XmlDeclarationWrapper(_document.CreateXmlDeclaration(version, encoding, standalone));
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	[return: Newtonsoft_002EJson_002ENullable(1)]
	public IXmlNode CreateXmlDocumentType([Newtonsoft_002EJson_002ENullable(1)] string name, string publicId, string systemId, string internalSubset)
	{
		return new XmlDocumentTypeWrapper(_document.CreateDocumentType(name, publicId, systemId, null));
	}

	public IXmlNode CreateProcessingInstruction(string target, string data)
	{
		return new XmlNodeWrapper(_document.CreateProcessingInstruction(target, data));
	}

	public IXmlElement CreateElement(string elementName)
	{
		return new XmlElementWrapper(_document.CreateElement(elementName));
	}

	public IXmlElement CreateElement(string qualifiedName, string namespaceUri)
	{
		return new XmlElementWrapper(_document.CreateElement(qualifiedName, namespaceUri));
	}

	public IXmlNode CreateAttribute(string name, [Newtonsoft_002EJson_002ENullable(2)] string value)
	{
		return new XmlNodeWrapper(_document.CreateAttribute(name))
		{
			Value = value
		};
	}

	public IXmlNode CreateAttribute(string qualifiedName, [Newtonsoft_002EJson_002ENullable(2)] string namespaceUri, [Newtonsoft_002EJson_002ENullable(2)] string value)
	{
		return new XmlNodeWrapper(_document.CreateAttribute(qualifiedName, namespaceUri))
		{
			Value = value
		};
	}
}
