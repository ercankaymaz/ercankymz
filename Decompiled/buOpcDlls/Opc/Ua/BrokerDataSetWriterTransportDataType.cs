using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrokerDataSetWriterTransportDataType : DataSetWriterTransportDataType
{
	private string m_queueName;

	private string m_resourceUri;

	private string m_authenticationProfileUri;

	private BrokerTransportQualityOfService m_requestedDeliveryGuarantee;

	private string m_metaDataQueueName;

	private double m_metaDataUpdateTime;

	[DataMember(Name = "QueueName", IsRequired = false, Order = 1)]
	public string QueueName
	{
		get
		{
			return m_queueName;
		}
		set
		{
			m_queueName = value;
		}
	}

	[DataMember(Name = "ResourceUri", IsRequired = false, Order = 2)]
	public string ResourceUri
	{
		get
		{
			return m_resourceUri;
		}
		set
		{
			m_resourceUri = value;
		}
	}

	[DataMember(Name = "AuthenticationProfileUri", IsRequired = false, Order = 3)]
	public string AuthenticationProfileUri
	{
		get
		{
			return m_authenticationProfileUri;
		}
		set
		{
			m_authenticationProfileUri = value;
		}
	}

	[DataMember(Name = "RequestedDeliveryGuarantee", IsRequired = false, Order = 4)]
	public BrokerTransportQualityOfService RequestedDeliveryGuarantee
	{
		get
		{
			return m_requestedDeliveryGuarantee;
		}
		set
		{
			m_requestedDeliveryGuarantee = value;
		}
	}

	[DataMember(Name = "MetaDataQueueName", IsRequired = false, Order = 5)]
	public string MetaDataQueueName
	{
		get
		{
			return m_metaDataQueueName;
		}
		set
		{
			m_metaDataQueueName = value;
		}
	}

	[DataMember(Name = "MetaDataUpdateTime", IsRequired = false, Order = 6)]
	public double MetaDataUpdateTime
	{
		get
		{
			return m_metaDataUpdateTime;
		}
		set
		{
			m_metaDataUpdateTime = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.BrokerDataSetWriterTransportDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.BrokerDataSetWriterTransportDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.BrokerDataSetWriterTransportDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.BrokerDataSetWriterTransportDataType_Encoding_DefaultJson;

	public BrokerDataSetWriterTransportDataType()
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
		m_queueName = null;
		m_resourceUri = null;
		m_authenticationProfileUri = null;
		m_requestedDeliveryGuarantee = BrokerTransportQualityOfService.NotSpecified;
		m_metaDataQueueName = null;
		m_metaDataUpdateTime = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("QueueName", QueueName);
		encoder.WriteString("ResourceUri", ResourceUri);
		encoder.WriteString("AuthenticationProfileUri", AuthenticationProfileUri);
		encoder.WriteEnumerated("RequestedDeliveryGuarantee", RequestedDeliveryGuarantee);
		encoder.WriteString("MetaDataQueueName", MetaDataQueueName);
		encoder.WriteDouble("MetaDataUpdateTime", MetaDataUpdateTime);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		QueueName = decoder.ReadString("QueueName");
		ResourceUri = decoder.ReadString("ResourceUri");
		AuthenticationProfileUri = decoder.ReadString("AuthenticationProfileUri");
		RequestedDeliveryGuarantee = (BrokerTransportQualityOfService)(object)decoder.ReadEnumerated("RequestedDeliveryGuarantee", typeof(BrokerTransportQualityOfService));
		MetaDataQueueName = decoder.ReadString("MetaDataQueueName");
		MetaDataUpdateTime = decoder.ReadDouble("MetaDataUpdateTime");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrokerDataSetWriterTransportDataType brokerDataSetWriterTransportDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queueName, brokerDataSetWriterTransportDataType.m_queueName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_resourceUri, brokerDataSetWriterTransportDataType.m_resourceUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_authenticationProfileUri, brokerDataSetWriterTransportDataType.m_authenticationProfileUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedDeliveryGuarantee, brokerDataSetWriterTransportDataType.m_requestedDeliveryGuarantee))
		{
			return false;
		}
		if (!Utils.IsEqual(m_metaDataQueueName, brokerDataSetWriterTransportDataType.m_metaDataQueueName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_metaDataUpdateTime, brokerDataSetWriterTransportDataType.m_metaDataUpdateTime))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (BrokerDataSetWriterTransportDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerDataSetWriterTransportDataType obj = (BrokerDataSetWriterTransportDataType)base.MemberwiseClone();
		obj.m_queueName = (string)Utils.Clone(m_queueName);
		obj.m_resourceUri = (string)Utils.Clone(m_resourceUri);
		obj.m_authenticationProfileUri = (string)Utils.Clone(m_authenticationProfileUri);
		obj.m_requestedDeliveryGuarantee = (BrokerTransportQualityOfService)Utils.Clone(m_requestedDeliveryGuarantee);
		obj.m_metaDataQueueName = (string)Utils.Clone(m_metaDataQueueName);
		obj.m_metaDataUpdateTime = (double)Utils.Clone(m_metaDataUpdateTime);
		return obj;
	}
}
