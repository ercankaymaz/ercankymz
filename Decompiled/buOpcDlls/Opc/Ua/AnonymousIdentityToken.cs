using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AnonymousIdentityToken : UserIdentityToken
{
	public override ExpandedNodeId TypeId => DataTypeIds.AnonymousIdentityToken;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.AnonymousIdentityToken_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.AnonymousIdentityToken_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.AnonymousIdentityToken_Encoding_DefaultJson;

	public AnonymousIdentityToken()
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
		if (!(encodeable is AnonymousIdentityToken))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (AnonymousIdentityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return (AnonymousIdentityToken)base.MemberwiseClone();
	}
}
