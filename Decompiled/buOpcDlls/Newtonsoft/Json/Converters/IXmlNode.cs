using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
internal interface IXmlNode
{
	XmlNodeType NodeType { get; }

	string LocalName { get; }

	[Newtonsoft_002EJson_002ENullable(1)]
	List<IXmlNode> ChildNodes
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}

	[Newtonsoft_002EJson_002ENullable(1)]
	List<IXmlNode> Attributes
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}

	IXmlNode ParentNode { get; }

	string Value { get; set; }

	string NamespaceUri { get; }

	object WrappedNode { get; }

	[Newtonsoft_002EJson_002ENullableContext(1)]
	IXmlNode AppendChild(IXmlNode newChild);
}
