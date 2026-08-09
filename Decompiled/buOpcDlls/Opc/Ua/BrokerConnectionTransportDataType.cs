using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrokerConnectionTransportDataType : ConnectionTransportDataType
{
	private string m_resourceUri;

	private string m_authenticationProfileUri;

	[DataMember(Name = "ResourceUri", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "AuthenticationProfileUri", IsRequired = false, Order = 2)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.BrokerConnectionTransportDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultJson;

	public BrokerConnectionTransportDataType()
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
		m_resourceUri = null;
		m_authenticationProfileUri = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ResourceUri", ResourceUri);
		encoder.WriteString("AuthenticationProfileUri", AuthenticationProfileUri);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResourceUri = decoder.ReadString("ResourceUri");
		AuthenticationProfileUri = decoder.ReadString("AuthenticationProfileUri");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrokerConnectionTransportDataType brokerConnectionTransportDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_resourceUri, brokerConnectionTransportDataType.m_resourceUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_authenticationProfileUri, brokerConnectionTransportDataType.m_authenticationProfileUri))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (BrokerConnectionTransportDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerConnectionTransportDataType obj = (BrokerConnectionTransportDataType)base.MemberwiseClone();
		obj.m_resourceUri = (string)Utils.Clone(m_resourceUri);
		obj.m_authenticationProfileUri = (string)Utils.Clone(m_authenticationProfileUri);
		return obj;
	}
}
