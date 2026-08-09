using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XAttributeWrapper : XObjectWrapper
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private XAttribute Attribute
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return (XAttribute)base.WrappedNode;
		}
	}

	public override string Value
	{
		get
		{
			return Attribute.Value;
		}
		set
		{
			Attribute.Value = value ?? string.Empty;
		}
	}

	public override string LocalName => Attribute.Name.LocalName;

	public override string NamespaceUri => Attribute.Name.NamespaceName;

	public override IXmlNode ParentNode
	{
		get
		{
			if (Attribute.Parent == null)
			{
				return null;
			}
			return XContainerWrapper.WrapNode(Attribute.Parent);
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XAttributeWrapper(XAttribute attribute)
		: base(attribute)
	{
	}
}
