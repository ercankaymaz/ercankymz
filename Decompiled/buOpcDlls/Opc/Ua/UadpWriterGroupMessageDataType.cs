using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UadpWriterGroupMessageDataType : WriterGroupMessageDataType
{
	private uint m_groupVersion;

	private DataSetOrderingType m_dataSetOrdering;

	private uint m_networkMessageContentMask;

	private double m_samplingOffset;

	private DoubleCollection m_publishingOffset;

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

	[DataMember(Name = "DataSetOrdering", IsRequired = false, Order = 2)]
	public DataSetOrderingType DataSetOrdering
	{
		get
		{
			return m_dataSetOrdering;
		}
		set
		{
			m_dataSetOrdering = value;
		}
	}

	[DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "SamplingOffset", IsRequired = false, Order = 4)]
	public double SamplingOffset
	{
		get
		{
			return m_samplingOffset;
		}
		set
		{
			m_samplingOffset = value;
		}
	}

	[DataMember(Name = "PublishingOffset", IsRequired = false, Order = 5)]
	public DoubleCollection PublishingOffset
	{
		get
		{
			return m_publishingOffset;
		}
		set
		{
			m_publishingOffset = value;
			if (value == null)
			{
				m_publishingOffset = new DoubleCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UadpWriterGroupMessageDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultJson;

	public UadpWriterGroupMessageDataType()
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
		m_dataSetOrdering = DataSetOrderingType.Undefined;
		m_networkMessageContentMask = 0u;
		m_samplingOffset = 0.0;
		m_publishingOffset = new DoubleCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("GroupVersion", GroupVersion);
		encoder.WriteEnumerated("DataSetOrdering", DataSetOrdering);
		encoder.WriteUInt32("NetworkMessageContentMask", NetworkMessageContentMask);
		encoder.WriteDouble("SamplingOffset", SamplingOffset);
		encoder.WriteDoubleArray("PublishingOffset", PublishingOffset);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		GroupVersion = decoder.ReadUInt32("GroupVersion");
		DataSetOrdering = (DataSetOrderingType)(object)decoder.ReadEnumerated("DataSetOrdering", typeof(DataSetOrderingType));
		NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
		SamplingOffset = decoder.ReadDouble("SamplingOffset");
		PublishingOffset = decoder.ReadDoubleArray("PublishingOffset");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UadpWriterGroupMessageDataType uadpWriterGroupMessageDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_groupVersion, uadpWriterGroupMessageDataType.m_groupVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetOrdering, uadpWriterGroupMessageDataType.m_dataSetOrdering))
		{
			return false;
		}
		if (!Utils.IsEqual(m_networkMessageContentMask, uadpWriterGroupMessageDataType.m_networkMessageContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_samplingOffset, uadpWriterGroupMessageDataType.m_samplingOffset))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingOffset, uadpWriterGroupMessageDataType.m_publishingOffset))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UadpWriterGroupMessageDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpWriterGroupMessageDataType obj = (UadpWriterGroupMessageDataType)base.MemberwiseClone();
		obj.m_groupVersion = (uint)Utils.Clone(m_groupVersion);
		obj.m_dataSetOrdering = (DataSetOrderingType)Utils.Clone(m_dataSetOrdering);
		obj.m_networkMessageContentMask = (uint)Utils.Clone(m_networkMessageContentMask);
		obj.m_samplingOffset = (double)Utils.Clone(m_samplingOffset);
		obj.m_publishingOffset = (DoubleCollection)Utils.Clone(m_publishingOffset);
		return obj;
	}
}
