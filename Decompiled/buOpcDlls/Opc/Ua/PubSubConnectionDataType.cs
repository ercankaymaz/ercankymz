using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PubSubConnectionDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private bool m_enabled;

	private Variant m_publisherId;

	private string m_transportProfileUri;

	private ExtensionObject m_address;

	private KeyValuePairCollection m_connectionProperties;

	private ExtensionObject m_transportSettings;

	private WriterGroupDataTypeCollection m_writerGroups;

	private ReaderGroupDataTypeCollection m_readerGroups;

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

	[DataMember(Name = "TransportProfileUri", IsRequired = false, Order = 4)]
	public string TransportProfileUri
	{
		get
		{
			return m_transportProfileUri;
		}
		set
		{
			m_transportProfileUri = value;
		}
	}

	[DataMember(Name = "Address", IsRequired = false, Order = 5)]
	public ExtensionObject Address
	{
		get
		{
			return m_address;
		}
		set
		{
			m_address = value;
		}
	}

	[DataMember(Name = "ConnectionProperties", IsRequired = false, Order = 6)]
	public KeyValuePairCollection ConnectionProperties
	{
		get
		{
			return m_connectionProperties;
		}
		set
		{
			m_connectionProperties = value;
			if (value == null)
			{
				m_connectionProperties = new KeyValuePairCollection();
			}
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

	[DataMember(Name = "WriterGroups", IsRequired = false, Order = 8)]
	public WriterGroupDataTypeCollection WriterGroups
	{
		get
		{
			return m_writerGroups;
		}
		set
		{
			m_writerGroups = value;
			if (value == null)
			{
				m_writerGroups = new WriterGroupDataTypeCollection();
			}
		}
	}

	[DataMember(Name = "ReaderGroups", IsRequired = false, Order = 9)]
	public ReaderGroupDataTypeCollection ReaderGroups
	{
		get
		{
			return m_readerGroups;
		}
		set
		{
			m_readerGroups = value;
			if (value == null)
			{
				m_readerGroups = new ReaderGroupDataTypeCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PubSubConnectionDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PubSubConnectionDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PubSubConnectionDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PubSubConnectionDataType_Encoding_DefaultJson;

	public PubSubConnectionDataType()
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
		m_transportProfileUri = null;
		m_address = null;
		m_connectionProperties = new KeyValuePairCollection();
		m_transportSettings = null;
		m_writerGroups = new WriterGroupDataTypeCollection();
		m_readerGroups = new ReaderGroupDataTypeCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteBoolean("Enabled", Enabled);
		encoder.WriteVariant("PublisherId", PublisherId);
		encoder.WriteString("TransportProfileUri", TransportProfileUri);
		encoder.WriteExtensionObject("Address", Address);
		encoder.WriteEncodeableArray("ConnectionProperties", ConnectionProperties.ToArray(), typeof(KeyValuePair));
		encoder.WriteExtensionObject("TransportSettings", TransportSettings);
		encoder.WriteEncodeableArray("WriterGroups", WriterGroups.ToArray(), typeof(WriterGroupDataType));
		encoder.WriteEncodeableArray("ReaderGroups", ReaderGroups.ToArray(), typeof(ReaderGroupDataType));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Enabled = decoder.ReadBoolean("Enabled");
		PublisherId = decoder.ReadVariant("PublisherId");
		TransportProfileUri = decoder.ReadString("TransportProfileUri");
		Address = decoder.ReadExtensionObject("Address");
		ConnectionProperties = (KeyValuePair[])decoder.ReadEncodeableArray("ConnectionProperties", typeof(KeyValuePair));
		TransportSettings = decoder.ReadExtensionObject("TransportSettings");
		WriterGroups = (WriterGroupDataType[])decoder.ReadEncodeableArray("WriterGroups", typeof(WriterGroupDataType));
		ReaderGroups = (ReaderGroupDataType[])decoder.ReadEncodeableArray("ReaderGroups", typeof(ReaderGroupDataType));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PubSubConnectionDataType pubSubConnectionDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, pubSubConnectionDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enabled, pubSubConnectionDataType.m_enabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publisherId, pubSubConnectionDataType.m_publisherId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportProfileUri, pubSubConnectionDataType.m_transportProfileUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_address, pubSubConnectionDataType.m_address))
		{
			return false;
		}
		if (!Utils.IsEqual(m_connectionProperties, pubSubConnectionDataType.m_connectionProperties))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportSettings, pubSubConnectionDataType.m_transportSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writerGroups, pubSubConnectionDataType.m_writerGroups))
		{
			return false;
		}
		if (!Utils.IsEqual(m_readerGroups, pubSubConnectionDataType.m_readerGroups))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PubSubConnectionDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubConnectionDataType obj = (PubSubConnectionDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_enabled = (bool)Utils.Clone(m_enabled);
		obj.m_publisherId = (Variant)Utils.Clone(m_publisherId);
		obj.m_transportProfileUri = (string)Utils.Clone(m_transportProfileUri);
		obj.m_address = (ExtensionObject)Utils.Clone(m_address);
		obj.m_connectionProperties = (KeyValuePairCollection)Utils.Clone(m_connectionProperties);
		obj.m_transportSettings = (ExtensionObject)Utils.Clone(m_transportSettings);
		obj.m_writerGroups = (WriterGroupDataTypeCollection)Utils.Clone(m_writerGroups);
		obj.m_readerGroups = (ReaderGroupDataTypeCollection)Utils.Clone(m_readerGroups);
		return obj;
	}
}
