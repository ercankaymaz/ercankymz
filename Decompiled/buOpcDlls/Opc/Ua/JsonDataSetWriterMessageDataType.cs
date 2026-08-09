using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class JsonDataSetWriterMessageDataType : DataSetWriterMessageDataType
{
	private uint m_dataSetMessageContentMask;

	[DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 1)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.JsonDataSetWriterMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultJson;

	public JsonDataSetWriterMessageDataType()
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
		m_dataSetMessageContentMask = 0u;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("DataSetMessageContentMask", DataSetMessageContentMask);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is JsonDataSetWriterMessageDataType jsonDataSetWriterMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMessageContentMask, jsonDataSetWriterMessageDataType.m_dataSetMessageContentMask))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (JsonDataSetWriterMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		JsonDataSetWriterMessageDataType obj = (JsonDataSetWriterMessageDataType)base.MemberwiseClone();
		obj.m_dataSetMessageContentMask = (uint)Utils.Clone(m_dataSetMessageContentMask);
		return obj;
	}
}
