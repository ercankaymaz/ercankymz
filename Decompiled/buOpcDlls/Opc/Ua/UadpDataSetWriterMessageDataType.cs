using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UadpDataSetWriterMessageDataType : DataSetWriterMessageDataType
{
	private uint m_dataSetMessageContentMask;

	private ushort m_configuredSize;

	private ushort m_networkMessageNumber;

	private ushort m_dataSetOffset;

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

	[DataMember(Name = "ConfiguredSize", IsRequired = false, Order = 2)]
	public ushort ConfiguredSize
	{
		get
		{
			return m_configuredSize;
		}
		set
		{
			m_configuredSize = value;
		}
	}

	[DataMember(Name = "NetworkMessageNumber", IsRequired = false, Order = 3)]
	public ushort NetworkMessageNumber
	{
		get
		{
			return m_networkMessageNumber;
		}
		set
		{
			m_networkMessageNumber = value;
		}
	}

	[DataMember(Name = "DataSetOffset", IsRequired = false, Order = 4)]
	public ushort DataSetOffset
	{
		get
		{
			return m_dataSetOffset;
		}
		set
		{
			m_dataSetOffset = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UadpDataSetWriterMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultJson;

	public UadpDataSetWriterMessageDataType()
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
		m_configuredSize = 0;
		m_networkMessageNumber = 0;
		m_dataSetOffset = 0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("DataSetMessageContentMask", DataSetMessageContentMask);
		encoder.WriteUInt16("ConfiguredSize", ConfiguredSize);
		encoder.WriteUInt16("NetworkMessageNumber", NetworkMessageNumber);
		encoder.WriteUInt16("DataSetOffset", DataSetOffset);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
		ConfiguredSize = decoder.ReadUInt16("ConfiguredSize");
		NetworkMessageNumber = decoder.ReadUInt16("NetworkMessageNumber");
		DataSetOffset = decoder.ReadUInt16("DataSetOffset");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UadpDataSetWriterMessageDataType uadpDataSetWriterMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMessageContentMask, uadpDataSetWriterMessageDataType.m_dataSetMessageContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_configuredSize, uadpDataSetWriterMessageDataType.m_configuredSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageNumber, uadpDataSetWriterMessageDataType.m_networkMessageNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetOffset, uadpDataSetWriterMessageDataType.m_dataSetOffset))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UadpDataSetWriterMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpDataSetWriterMessageDataType obj = (UadpDataSetWriterMessageDataType)base.MemberwiseClone();
		obj.m_dataSetMessageContentMask = (uint)Utils.Clone(m_dataSetMessageContentMask);
		obj.m_configuredSize = (ushort)Utils.Clone(m_configuredSize);
		obj.m_networkMessageNumber = (ushort)Utils.Clone(m_networkMessageNumber);
		obj.m_dataSetOffset = (ushort)Utils.Clone(m_dataSetOffset);
		return obj;
	}
}
