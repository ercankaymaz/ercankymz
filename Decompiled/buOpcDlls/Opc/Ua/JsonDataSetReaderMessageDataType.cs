using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class JsonDataSetReaderMessageDataType : DataSetReaderMessageDataType
{
	private uint m_networkMessageContentMask;

	private uint m_dataSetMessageContentMask;

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

	[DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 2)]
	public uint DataSetMessageContentMask
	{
		get
		{
			return m_dataSetMessageContentMask;
		}
		set
		{
			m_dataSetMessageContentMask = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.JsonDataSetReaderMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultJson;

	public JsonDataSetReaderMessageDataType()
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
		m_dataSetMessageContentMask = 0u;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("NetworkMessageContentMask", NetworkMessageContentMask);
		encoder.WriteUInt32("DataSetMessageContentMask", DataSetMessageContentMask);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
		DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is JsonDataSetReaderMessageDataType jsonDataSetReaderMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageContentMask, jsonDataSetReaderMessageDataType.m_networkMessageContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMessageContentMask, jsonDataSetReaderMessageDataType.m_dataSetMessageContentMask))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (JsonDataSetReaderMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonDataSetReaderMessageDataType obj = (JsonDataSetReaderMessageDataType)base.MemberwiseClone();
		obj.m_networkMessageContentMask = (uint)Utils.Clone(m_networkMessageContentMask);
		obj.m_dataSetMessageContentMask = (uint)Utils.Clone(m_dataSetMessageContentMask);
		return obj;
	}
}
