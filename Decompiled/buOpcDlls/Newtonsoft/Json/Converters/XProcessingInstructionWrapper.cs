using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XProcessingInstructionWrapper : XObjectWrapper
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private XProcessingInstruction ProcessingInstruction
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return (XProcessingInstruction)base.WrappedNode;
		}
	}

	public override string LocalName => ProcessingInstruction.Target;

	public override string Value
	{
		get
		{
			return ProcessingInstruction.Data;
		}
		set
		{
			ProcessingInstruction.Data = value ?? string.Empty;
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XProcessingInstructionWrapper(XProcessingInstruction processingInstruction)
		: base(processingInstruction)
	{
	}
}
