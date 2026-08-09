using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataSetReaderDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private bool m_enabled;

	private Variant m_publisherId;

	private ushort m_writerGroupId;

	private ushort m_dataSetWriterId;

	private DataSetMetaDataType m_dataSetMetaData;

	private uint m_dataSetFieldContentMask;

	private double m_messageReceiveTimeout;

	private uint m_keyFrameCount;

	private string m_headerLayoutUri;

	private MessageSecurityMode m_securityMode;

	private string m_securityGroupId;

	private EndpointDescriptionCollection m_securityKeyServices;

	private KeyValuePairCollection m_dataSetReaderProperties;

	private ExtensionObject m_transportSettings;

	private ExtensionObject m_messageSettings;

	private ExtensionObject m_subscribedDataSet;

	[DataMember(Name = "Name", IsRequired = false, Order = 1)]
	public string Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	[DataMember(Name = "Enabled", IsRequired = false, Order = 2)]
	public bool Enabled
	{
		get
		{
			return m_enabled;
		}
		set
		{
			m_enabled = value;
		}
	}

	[DataMember(Name = "PublisherId", IsRequired = false, Order = 3)]
	public Variant PublisherId
	{
		get
		{
			return m_publisherId;
		}
		set
		{
			m_publisherId = value;
		}
	}

	[DataMember(Name = "WriterGroupId", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "DataSetWriterId", IsRequired = false, Order = 5)]
	public ushort DataSetWriterId
	{
		get
		{
			return m_dataSetWriterId;
		}
		set
		{
			m_dataSetWriterId = value;
		}
	}

	[DataMember(Name = "DataSetMetaData", IsRequired = false, Order = 6)]
	public DataSetMetaDataType DataSetMetaData
	{
		get
		{
			return m_dataSetMetaData;
		}
		set
		{
			m_dataSetMetaData = value;
			if (value == null)
			{
				m_dataSetMetaData = new DataSetMetaDataType();
			}
		}
	}

	[DataMember(Name = "DataSetFieldContentMask", IsRequired = false, Order = 7)]
	public uint DataSetFieldContentMask
	{
		get
		{
			return m_dataSetFieldContentMask;
		}
		set
		{
			m_dataSetFieldContentMask = value;
		}
	}

	[DataMember(Name = "MessageReceiveTimeout", IsRequired = false, Order = 8)]
	public double MessageReceiveTimeout
	{
		get
		{
			return m_messageReceiveTimeout;
		}
		set
		{
			m_messageReceiveTimeout = value;
		}
	}

	[DataMember(Name = "KeyFrameCount", IsRequired = false, Order = 9)]
	public uint KeyFrameCount
	{
		get
		{
			return m_keyFrameCount;
		}
		set
		{
			m_keyFrameCount = value;
		}
	}

	[DataMember(Name = "HeaderLayoutUri", IsRequired = false, Order = 10)]
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

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 11)]
	public MessageSecurityMode SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			m_securityMode = value;
		}
	}

	[DataMember(Name = "SecurityGroupId", IsRequired = false, Order = 12)]
	public string SecurityGroupId
	{
		get
		{
			return m_securityGroupId;
		}
		set
		{
			m_securityGroupId = value;
		}
	}

	[DataMember(Name = "SecurityKeyServices", IsRequired = false, Order = 13)]
	public EndpointDescriptionCollection SecurityKeyServices
	{
		get
		{
			return m_securityKeyServices;
		}
		set
		{
			m_securityKeyServices = value;
			if (value == null)
			{
				m_securityKeyServices = new EndpointDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "DataSetReaderProperties", IsRequired = false, Order = 14)]
	public KeyValuePairCollection DataSetReaderProperties
	{
		get
		{
			return m_dataSetReaderProperties;
		}
		set
		{
			m_dataSetReaderProperties = value;
			if (value == null)
			{
				m_dataSetReaderProperties = new KeyValuePairCollection();
			}
		}
	}

	[DataMember(Name = "TransportSettings", IsRequired = false, Order = 15)]
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

	[DataMember(Name = "MessageSettings", IsRequired = false, Order = 16)]
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

	[DataMember(Name = "SubscribedDataSet", IsRequired = false, Order = 17)]
	public ExtensionObject SubscribedDataSet
	{
		get
		{
			return m_subscribedDataSet;
		}
		set
		{
			m_subscribedDataSet = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DataSetReaderDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DataSetReaderDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DataSetReaderDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DataSetReaderDataType_Encoding_DefaultJson;

	public DataSetReaderDataType()
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
		m_name = null;
		m_enabled = true;
		m_publisherId = Variant.Null;
		m_writerGroupId = 0;
		m_dataSetWriterId = 0;
		m_dataSetMetaData = new DataSetMetaDataType();
		m_dataSetFieldContentMask = 0u;
		m_messageReceiveTimeout = 0.0;
		m_keyFrameCount = 0u;
		m_headerLayoutUri = null;
		m_securityMode = MessageSecurityMode.Invalid;
		m_securityGroupId = null;
		m_securityKeyServices = new EndpointDescriptionCollection();
		m_dataSetReaderProperties = new KeyValuePairCollection();
		m_transportSettings = null;
		m_messageSettings = null;
		m_subscribedDataSet = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteBoolean("Enabled", Enabled);
		encoder.WriteVariant("PublisherId", PublisherId);
		encoder.WriteUInt16("WriterGroupId", WriterGroupId);
		encoder.WriteUInt16("DataSetWriterId", DataSetWriterId);
		encoder.WriteEncodeable("DataSetMetaData", DataSetMetaData, typeof(DataSetMetaDataType));
		encoder.WriteUInt32("DataSetFieldContentMask", DataSetFieldContentMask);
		encoder.WriteDouble("MessageReceiveTimeout", MessageReceiveTimeout);
		encoder.WriteUInt32("KeyFrameCount", KeyFrameCount);
		encoder.WriteString("HeaderLayoutUri", HeaderLayoutUri);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteString("SecurityGroupId", SecurityGroupId);
		encoder.WriteEncodeableArray("SecurityKeyServices", SecurityKeyServices.ToArray(), typeof(EndpointDescription));
		encoder.WriteEncodeableArray("DataSetReaderProperties", DataSetReaderProperties.ToArray(), typeof(KeyValuePair));
		encoder.WriteExtensionObject("TransportSettings", TransportSettings);
		encoder.WriteExtensionObject("MessageSettings", MessageSettings);
		encoder.WriteExtensionObject("SubscribedDataSet", SubscribedDataSet);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Enabled = decoder.ReadBoolean("Enabled");
		PublisherId = decoder.ReadVariant("PublisherId");
		WriterGroupId = decoder.ReadUInt16("WriterGroupId");
		DataSetWriterId = decoder.ReadUInt16("DataSetWriterId");
		DataSetMetaData = (DataSetMetaDataType)decoder.ReadEncodeable("DataSetMetaData", typeof(DataSetMetaDataType));
		DataSetFieldContentMask = decoder.ReadUInt32("DataSetFieldContentMask");
		MessageReceiveTimeout = decoder.ReadDouble("MessageReceiveTimeout");
		KeyFrameCount = decoder.ReadUInt32("KeyFrameCount");
		HeaderLayoutUri = decoder.ReadString("HeaderLayoutUri");
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		SecurityGroupId = decoder.ReadString("SecurityGroupId");
		SecurityKeyServices = (EndpointDescription[])decoder.ReadEncodeableArray("SecurityKeyServices", typeof(EndpointDescription));
		DataSetReaderProperties = (KeyValuePair[])decoder.ReadEncodeableArray("DataSetReaderProperties", typeof(KeyValuePair));
		TransportSettings = decoder.ReadExtensionObject("TransportSettings");
		MessageSettings = decoder.ReadExtensionObject("MessageSettings");
		SubscribedDataSet = decoder.ReadExtensionObject("SubscribedDataSet");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataSetReaderDataType dataSetReaderDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, dataSetReaderDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enabled, dataSetReaderDataType.m_enabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publisherId, dataSetReaderDataType.m_publisherId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writerGroupId, dataSetReaderDataType.m_writerGroupId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetWriterId, dataSetReaderDataType.m_dataSetWriterId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMetaData, dataSetReaderDataType.m_dataSetMetaData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetFieldContentMask, dataSetReaderDataType.m_dataSetFieldContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageReceiveTimeout, dataSetReaderDataType.m_messageReceiveTimeout))
		{
			return false;
		}
		if (!Utils.IsEqual(m_keyFrameCount, dataSetReaderDataType.m_keyFrameCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_headerLayoutUri, dataSetReaderDataType.m_headerLayoutUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, dataSetReaderDataType.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityGroupId, dataSetReaderDataType.m_securityGroupId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityKeyServices, dataSetReaderDataType.m_securityKeyServices))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetReaderProperties, dataSetReaderDataType.m_dataSetReaderProperties))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportSettings, dataSetReaderDataType.m_transportSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageSettings, dataSetReaderDataType.m_messageSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscribedDataSet, dataSetReaderDataType.m_subscribedDataSet))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DataSetReaderDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetReaderDataType obj = (DataSetReaderDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_enabled = (bool)Utils.Clone(m_enabled);
		obj.m_publisherId = (Variant)Utils.Clone(m_publisherId);
		obj.m_writerGroupId = (ushort)Utils.Clone(m_writerGroupId);
		obj.m_dataSetWriterId = (ushort)Utils.Clone(m_dataSetWriterId);
		obj.m_dataSetMetaData = (DataSetMetaDataType)Utils.Clone(m_dataSetMetaData);
		obj.m_dataSetFieldContentMask = (uint)Utils.Clone(m_dataSetFieldContentMask);
		obj.m_messageReceiveTimeout = (double)Utils.Clone(m_messageReceiveTimeout);
		obj.m_keyFrameCount = (uint)Utils.Clone(m_keyFrameCount);
		obj.m_headerLayoutUri = (string)Utils.Clone(m_headerLayoutUri);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_securityGroupId = (string)Utils.Clone(m_securityGroupId);
		obj.m_securityKeyServices = (EndpointDescriptionCollection)Utils.Clone(m_securityKeyServices);
		obj.m_dataSetReaderProperties = (KeyValuePairCollection)Utils.Clone(m_dataSetReaderProperties);
		obj.m_transportSettings = (ExtensionObject)Utils.Clone(m_transportSettings);
		obj.m_messageSettings = (ExtensionObject)Utils.Clone(m_messageSettings);
		obj.m_subscribedDataSet = (ExtensionObject)Utils.Clone(m_subscribedDataSet);
		return obj;
	}
}
