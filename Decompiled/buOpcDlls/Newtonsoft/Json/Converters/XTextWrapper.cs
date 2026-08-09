using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XTextWrapper : XObjectWrapper
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private XText Text
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return (XText)base.WrappedNode;
		}
	}

	public override string Value
	{
		get
		{
			return Text.Value;
		}
		set
		{
			Text.Value = value ?? string.Empty;
		}
	}

	public override IXmlNode ParentNode
	{
		get
		{
			if (Text.Parent == null)
			{
				return null;
			}
			return XContainerWrapper.WrapNode(Text.Parent);
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XTextWrapper(XText text)
		: base(text)
	{
	}
}
