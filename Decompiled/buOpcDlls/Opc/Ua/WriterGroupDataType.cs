using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class WriterGroupDataType : PubSubGroupDataType
{
	private ushort m_writerGroupId;

	private double m_publishingInterval;

	private double m_keepAliveTime;

	private byte m_priority;

	private StringCollection m_localeIds;

	private string m_headerLayoutUri;

	private ExtensionObject m_transportSettings;

	private ExtensionObject m_messageSettings;

	private DataSetWriterDataTypeCollection m_dataSetWriters;

	[DataMember(Name = "WriterGroupId", IsRequired = false, Order = 1)]
	public ushort WriterGroupId
	{
		get
		{
			return m_writerGroupId;
		}
		set
		{
			m_writerGroupId = value;
		}
	}

	[DataMember(Name = "PublishingInterval", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "KeepAliveTime", IsRequired = false, Order = 3)]
	public double KeepAliveTime
	{
		get
		{
			return m_keepAliveTime;
		}
		set
		{
			m_keepAliveTime = value;
		}
	}

	[DataMember(Name = "Priority", IsRequired = false, Order = 4)]
	public byte Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			m_priority = value;
		}
	}

	[DataMember(Name = "LocaleIds", IsRequired = false, Order = 5)]
	public StringCollection LocaleIds
	{
		get
		{
			return m_localeIds;
		}
		set
		{
			m_localeIds = value;
			if (value == null)
			{
				m_localeIds = new StringCollection();
			}
		}
	}

	[DataMember(Name = "HeaderLayoutUri", IsRequired = false, Order = 6)]
	public string HeaderLayoutUri
	{
		get
		{
			return m_headerLayoutUri;
		}
		set
		{
			m_headerLayoutUri = value;
		}
	}

	[DataMember(Name = "TransportSettings", IsRequired = false, Order = 7)]
	public ExtensionObject TransportSettings
	{
		get
		{
			return m_transportSettings;
		}
		set
		{
			m_transportSettings = value;
		}
	}

	[DataMember(Name = "MessageSettings", IsRequired = false, Order = 8)]
	public ExtensionObject MessageSettings
	{
		get
		{
			return m_messageSettings;
		}
		set
		{
			m_messageSettings = value;
		}
	}

	[DataMember(Name = "DataSetWriters", IsRequired = false, Order = 9)]
	public DataSetWriterDataTypeCollection DataSetWriters
	{
		get
		{
			return m_dataSetWriters;
		}
		set
		{
			m_dataSetWriters = value;
			if (value == null)
			{
				m_dataSetWriters = new DataSetWriterDataTypeCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.WriterGroupDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.WriterGroupDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.WriterGroupDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.WriterGroupDataType_Encoding_DefaultJson;

	public WriterGroupDataType()
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
		m_writerGroupId = 0;
		m_publishingInterval = 0.0;
		m_keepAliveTime = 0.0;
		m_priority = 0;
		m_localeIds = new StringCollection();
		m_headerLayoutUri = null;
		m_transportSettings = null;
		m_messageSettings = null;
		m_dataSetWriters = new DataSetWriterDataTypeCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt16("WriterGroupId", WriterGroupId);
		encoder.WriteDouble("PublishingInterval", PublishingInterval);
		encoder.WriteDouble("KeepAliveTime", KeepAliveTime);
		encoder.WriteByte("Priority", Priority);
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteString("HeaderLayoutUri", HeaderLayoutUri);
		encoder.WriteExtensionObject("TransportSettings", TransportSettings);
		encoder.WriteExtensionObject("MessageSettings", MessageSettings);
		encoder.WriteEncodeableArray("DataSetWriters", DataSetWriters.ToArray(), typeof(DataSetWriterDataType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		WriterGroupId = decoder.ReadUInt16("WriterGroupId");
		PublishingInterval = decoder.ReadDouble("PublishingInterval");
		KeepAliveTime = decoder.ReadDouble("KeepAliveTime");
		Priority = decoder.ReadByte("Priority");
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		HeaderLayoutUri = decoder.ReadString("HeaderLayoutUri");
		TransportSettings = decoder.ReadExtensionObject("TransportSettings");
		MessageSettings = decoder.ReadExtensionObject("MessageSettings");
		DataSetWriters = (DataSetWriterDataType[])decoder.ReadEncodeableArray("DataSetWriters", typeof(DataSetWriterDataType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is WriterGroupDataType writerGroupDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writerGroupId, writerGroupDataType.m_writerGroupId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingInterval, writerGroupDataType.m_publishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_keepAliveTime, writerGroupDataType.m_keepAliveTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_priority, writerGroupDataType.m_priority))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, writerGroupDataType.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_headerLayoutUri, writerGroupDataType.m_headerLayoutUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportSettings, writerGroupDataType.m_transportSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageSettings, writerGroupDataType.m_messageSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetWriters, writerGroupDataType.m_dataSetWriters))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (WriterGroupDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriterGroupDataType obj = (WriterGroupDataType)base.MemberwiseClone();
		obj.m_writerGroupId = (ushort)Utils.Clone(m_writerGroupId);
		obj.m_publishingInterval = (double)Utils.Clone(m_publishingInterval);
		obj.m_keepAliveTime = (double)Utils.Clone(m_keepAliveTime);
		obj.m_priority = (byte)Utils.Clone(m_priority);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_headerLayoutUri = (string)Utils.Clone(m_headerLayoutUri);
		obj.m_transportSettings = (ExtensionObject)Utils.Clone(m_transportSettings);
		obj.m_messageSettings = (ExtensionObject)Utils.Clone(m_messageSettings);
		obj.m_dataSetWriters = (DataSetWriterDataTypeCollection)Utils.Clone(m_dataSetWriters);
		return obj;
	}
}
