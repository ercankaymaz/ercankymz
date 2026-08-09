using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_endpointUrl;

	private MessageSecurityMode m_securityMode;

	private string m_securityPolicyUri;

	private string m_transportProfileUri;

	[DataMember(Name = "EndpointUrl", IsRequired = false, Order = 1)]
	public string EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			m_endpointUrl = value;
		}
	}

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 3)]
	public string SecurityPolicyUri
	{
		get
		{
			return m_securityPolicyUri;
		}
		set
		{
			m_securityPolicyUri = value;
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.EndpointType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EndpointType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EndpointType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EndpointType_Encoding_DefaultJson;

	public EndpointType()
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
		m_endpointUrl = null;
		m_securityMode = MessageSecurityMode.Invalid;
		m_securityPolicyUri = null;
		m_transportProfileUri = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteString("SecurityPolicyUri", SecurityPolicyUri);
		encoder.WriteString("TransportProfileUri", TransportProfileUri);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EndpointUrl = decoder.ReadString("EndpointUrl");
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
		TransportProfileUri = decoder.ReadString("TransportProfileUri");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EndpointType endpointType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, endpointType.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, endpointType.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityPolicyUri, endpointType.m_securityPolicyUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportProfileUri, endpointType.m_transportProfileUri))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EndpointType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointType obj = (EndpointType)base.MemberwiseClone();
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_securityPolicyUri = (string)Utils.Clone(m_securityPolicyUri);
		obj.m_transportProfileUri = (string)Utils.Clone(m_transportProfileUri);
		return obj;
	}
}
