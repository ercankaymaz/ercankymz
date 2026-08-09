using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class JsonWriterGroupMessageDataType : WriterGroupMessageDataType
{
	private uint m_networkMessageContentMask;

	[DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 1)]
	public uint NetworkMessageContentMask
	{
		get
		{
			return m_networkMessageContentMask;
		}
		set
		{
			m_networkMessageContentMask = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.JsonWriterGroupMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultJson;

	public JsonWriterGroupMessageDataType()
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
		m_networkMessageContentMask = 0u;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("NetworkMessageContentMask", NetworkMessageContentMask);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is JsonWriterGroupMessageDataType jsonWriterGroupMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageContentMask, jsonWriterGroupMessageDataType.m_networkMessageContentMask))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (JsonWriterGroupMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonWriterGroupMessageDataType obj = (JsonWriterGroupMessageDataType)base.MemberwiseClone();
		obj.m_networkMessageContentMask = (uint)Utils.Clone(m_networkMessageContentMask);
		return obj;
	}
}
