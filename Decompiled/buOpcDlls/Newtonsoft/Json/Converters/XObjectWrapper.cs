using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XObjectWrapper : IXmlNode
{
	private readonly XObject _xmlObject;

	public object WrappedNode => _xmlObject;

	public virtual XmlNodeType NodeType => _xmlObject?.NodeType ?? XmlNodeType.None;

	public virtual string LocalName => null;

	[Newtonsoft_002EJson_002ENullable(1)]
	public virtual List<IXmlNode> ChildNodes
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return XmlNodeConverter.EmptyChildNodes;
		}
	}

	[Newtonsoft_002EJson_002ENullable(1)]
	public virtual List<IXmlNode> Attributes
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return XmlNodeConverter.EmptyChildNodes;
		}
	}

	public virtual IXmlNode ParentNode => null;

	public virtual string Value
	{
		get
		{
			return null;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public virtual string NamespaceUri => null;

	public XObjectWrapper(XObject xmlObject)
	{
		_xmlObject = xmlObject;
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public virtual IXmlNode AppendChild(IXmlNode newChild)
	{
		throw new InvalidOperationException();
	}
}
