using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XmlElementWrapper : XmlNodeWrapper, IXmlElement, IXmlNode
{
	private readonly XmlElement _element;

	public bool IsEmpty => _element.IsEmpty;

	public XmlElementWrapper(XmlElement element)
		: base(element)
	{
		_element = element;
	}

	public void SetAttributeNode(IXmlNode attribute)
	{
		XmlNodeWrapper xmlNodeWrapper = (XmlNodeWrapper)attribute;
		_element.SetAttributeNode((XmlAttribute)xmlNodeWrapper.WrappedNode);
	}

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public string GetPrefixOfNamespace(string namespaceUri)
	{
		return _element.GetPrefixOfNamespace(namespaceUri);
	}
}
