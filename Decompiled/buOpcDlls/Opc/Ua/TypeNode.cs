using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TypeNode : Node
{
	public override ExpandedNodeId TypeId => DataTypeIds.TypeNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.TypeNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.TypeNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.TypeNode_Encoding_DefaultJson;

	public TypeNode()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TypeNode))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (TypeNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (TypeNode)base.MemberwiseClone();
	}

	public TypeNode(ILocalNode source)
		: base(source)
	{
	}
}
