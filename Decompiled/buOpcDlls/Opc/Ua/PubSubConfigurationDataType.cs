using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PubSubConfigurationDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private PublishedDataSetDataTypeCollection m_publishedDataSets;

	private PubSubConnectionDataTypeCollection m_connections;

	private bool m_enabled;

	[DataMember(Name = "PublishedDataSets", IsRequired = false, Order = 1)]
	public PublishedDataSetDataTypeCollection PublishedDataSets
	{
		get
		{
			return m_publishedDataSets;
		}
		set
		{
			m_publishedDataSets = value;
			if (value == null)
			{
				m_publishedDataSets = new PublishedDataSetDataTypeCollection();
			}
		}
	}

	[DataMember(Name = "Connections", IsRequired = false, Order = 2)]
	public PubSubConnectionDataTypeCollection Connections
	{
		get
		{
			return m_connections;
		}
		set
		{
			m_connections = value;
			if (value == null)
			{
				m_connections = new PubSubConnectionDataTypeCollection();
			}
		}
	}

	[DataMember(Name = "Enabled", IsRequired = false, Order = 3)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.PubSubConfigurationDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PubSubConfigurationDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PubSubConfigurationDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PubSubConfigurationDataType_Encoding_DefaultJson;

	public PubSubConfigurationDataType()
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
		m_publishedDataSets = new PublishedDataSetDataTypeCollection();
		m_connections = new PubSubConnectionDataTypeCollection();
		m_enabled = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("PublishedDataSets", PublishedDataSets.ToArray(), typeof(PublishedDataSetDataType));
		encoder.WriteEncodeableArray("Connections", Connections.ToArray(), typeof(PubSubConnectionDataType));
		encoder.WriteBoolean("Enabled", Enabled);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PublishedDataSets = (PublishedDataSetDataType[])decoder.ReadEncodeableArray("PublishedDataSets", typeof(PublishedDataSetDataType));
		Connections = (PubSubConnectionDataType[])decoder.ReadEncodeableArray("Connections", typeof(PubSubConnectionDataType));
		Enabled = decoder.ReadBoolean("Enabled");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PubSubConfigurationDataType pubSubConfigurationDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishedDataSets, pubSubConfigurationDataType.m_publishedDataSets))
		{
			return false;
		}
		if (!Utils.IsEqual(m_connections, pubSubConfigurationDataType.m_connections))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enabled, pubSubConfigurationDataType.m_enabled))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PubSubConfigurationDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubConfigurationDataType obj = (PubSubConfigurationDataType)base.MemberwiseClone();
		obj.m_publishedDataSets = (PublishedDataSetDataTypeCollection)Utils.Clone(m_publishedDataSets);
		obj.m_connections = (PubSubConnectionDataTypeCollection)Utils.Clone(m_connections);
		obj.m_enabled = (bool)Utils.Clone(m_enabled);
		return obj;
	}
}
