using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UadpDataSetReaderMessageDataType : DataSetReaderMessageDataType
{
	private uint m_groupVersion;

	private ushort m_networkMessageNumber;

	private ushort m_dataSetOffset;

	private Uuid m_dataSetClassId;

	private uint m_networkMessageContentMask;

	private uint m_dataSetMessageContentMask;

	private double m_publishingInterval;

	private double m_receiveOffset;

	private double m_processingOffset;

	[DataMember(Name = "GroupVersion", IsRequired = false, Order = 1)]
	public uint GroupVersion
	{
		get
		{
			return m_groupVersion;
		}
		set
		{
			m_groupVersion = value;
		}
	}

	[DataMember(Name = "NetworkMessageNumber", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "DataSetOffset", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "DataSetClassId", IsRequired = false, Order = 4)]
	public Uuid DataSetClassId
	{
		get
		{
			return m_dataSetClassId;
		}
		set
		{
			m_dataSetClassId = value;
		}
	}

	[DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 6)]
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

	[DataMember(Name = "PublishingInterval", IsRequired = false, Order = 7)]
	public double PublishingInterval
	{
		get
		{
			return m_publishingInterval;
		}
		set
		{
			m_publishingInterval = value;
		}
	}

	[DataMember(Name = "ReceiveOffset", IsRequired = false, Order = 8)]
	public double ReceiveOffset
	{
		get
		{
			return m_receiveOffset;
		}
		set
		{
			m_receiveOffset = value;
		}
	}

	[DataMember(Name = "ProcessingOffset", IsRequired = false, Order = 9)]
	public double ProcessingOffset
	{
		get
		{
			return m_processingOffset;
		}
		set
		{
			m_processingOffset = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UadpDataSetReaderMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultJson;

	public UadpDataSetReaderMessageDataType()
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
		m_groupVersion = 0u;
		m_networkMessageNumber = 0;
		m_dataSetOffset = 0;
		m_dataSetClassId = Uuid.Empty;
		m_networkMessageContentMask = 0u;
		m_dataSetMessageContentMask = 0u;
		m_publishingInterval = 0.0;
		m_receiveOffset = 0.0;
		m_processingOffset = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("GroupVersion", GroupVersion);
		encoder.WriteUInt16("NetworkMessageNumber", NetworkMessageNumber);
		encoder.WriteUInt16("DataSetOffset", DataSetOffset);
		encoder.WriteGuid("DataSetClassId", DataSetClassId);
		encoder.WriteUInt32("NetworkMessageContentMask", NetworkMessageContentMask);
		encoder.WriteUInt32("DataSetMessageContentMask", DataSetMessageContentMask);
		encoder.WriteDouble("PublishingInterval", PublishingInterval);
		encoder.WriteDouble("ReceiveOffset", ReceiveOffset);
		encoder.WriteDouble("ProcessingOffset", ProcessingOffset);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		GroupVersion = decoder.ReadUInt32("GroupVersion");
		NetworkMessageNumber = decoder.ReadUInt16("NetworkMessageNumber");
		DataSetOffset = decoder.ReadUInt16("DataSetOffset");
		DataSetClassId = decoder.ReadGuid("DataSetClassId");
		NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
		DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
		PublishingInterval = decoder.ReadDouble("PublishingInterval");
		ReceiveOffset = decoder.ReadDouble("ReceiveOffset");
		ProcessingOffset = decoder.ReadDouble("ProcessingOffset");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UadpDataSetReaderMessageDataType uadpDataSetReaderMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_groupVersion, uadpDataSetReaderMessageDataType.m_groupVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageNumber, uadpDataSetReaderMessageDataType.m_networkMessageNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetOffset, uadpDataSetReaderMessageDataType.m_dataSetOffset))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetClassId, uadpDataSetReaderMessageDataType.m_dataSetClassId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageContentMask, uadpDataSetReaderMessageDataType.m_networkMessageContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMessageContentMask, uadpDataSetReaderMessageDataType.m_dataSetMessageContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingInterval, uadpDataSetReaderMessageDataType.m_publishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_receiveOffset, uadpDataSetReaderMessageDataType.m_receiveOffset))
		{
			return false;
		}
		if (!Utils.IsEqual(m_processingOffset, uadpDataSetReaderMessageDataType.m_processingOffset))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UadpDataSetReaderMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpDataSetReaderMessageDataType obj = (UadpDataSetReaderMessageDataType)base.MemberwiseClone();
		obj.m_groupVersion = (uint)Utils.Clone(m_groupVersion);
		obj.m_networkMessageNumber = (ushort)Utils.Clone(m_networkMessageNumber);
		obj.m_dataSetOffset = (ushort)Utils.Clone(m_dataSetOffset);
		obj.m_dataSetClassId = (Uuid)Utils.Clone(m_dataSetClassId);
		obj.m_networkMessageContentMask = (uint)Utils.Clone(m_networkMessageContentMask);
		obj.m_dataSetMessageContentMask = (uint)Utils.Clone(m_dataSetMessageContentMask);
		obj.m_publishingInterval = (double)Utils.Clone(m_publishingInterval);
		obj.m_receiveOffset = (double)Utils.Clone(m_receiveOffset);
		obj.m_processingOffset = (double)Utils.Clone(m_processingOffset);
		return obj;
	}
}
