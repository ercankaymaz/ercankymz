using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class OpenSecureChannelRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_clientProtocolVersion;

	private SecurityTokenRequestType m_requestType;

	private MessageSecurityMode m_securityMode;

	private byte[] m_clientNonce;

	private uint m_requestedLifetime;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "ClientProtocolVersion", IsRequired = false, Order = 2)]
	public uint ClientProtocolVersion
	{
		get
		{
			return m_clientProtocolVersion;
		}
		set
		{
			m_clientProtocolVersion = value;
		}
	}

	[DataMember(Name = "RequestType", IsRequired = false, Order = 3)]
	public SecurityTokenRequestType RequestType
	{
		get
		{
			return m_requestType;
		}
		set
		{
			m_requestType = value;
		}
	}

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "ClientNonce", IsRequired = false, Order = 5)]
	public byte[] ClientNonce
	{
		get
		{
			return m_clientNonce;
		}
		set
		{
			m_clientNonce = value;
		}
	}

	[DataMember(Name = "RequestedLifetime", IsRequired = false, Order = 6)]
	public uint RequestedLifetime
	{
		get
		{
			return m_requestedLifetime;
		}
		set
		{
			m_requestedLifetime = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.OpenSecureChannelRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.OpenSecureChannelRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.OpenSecureChannelRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.OpenSecureChannelRequest_Encoding_DefaultJson;

	public OpenSecureChannelRequest()
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
		m_requestHeader = new RequestHeader();
		m_clientProtocolVersion = 0u;
		m_requestType = SecurityTokenRequestType.Issue;
		m_securityMode = MessageSecurityMode.Invalid;
		m_clientNonce = null;
		m_requestedLifetime = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("ClientProtocolVersion", ClientProtocolVersion);
		encoder.WriteEnumerated("RequestType", RequestType);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteByteString("ClientNonce", ClientNonce);
		encoder.WriteUInt32("RequestedLifetime", RequestedLifetime);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ClientProtocolVersion = decoder.ReadUInt32("ClientProtocolVersion");
		RequestType = (SecurityTokenRequestType)(object)decoder.ReadEnumerated("RequestType", typeof(SecurityTokenRequestType));
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		ClientNonce = decoder.ReadByteString("ClientNonce");
		RequestedLifetime = decoder.ReadUInt32("RequestedLifetime");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is OpenSecureChannelRequest openSecureChannelRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, openSecureChannelRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientProtocolVersion, openSecureChannelRequest.m_clientProtocolVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestType, openSecureChannelRequest.m_requestType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, openSecureChannelRequest.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientNonce, openSecureChannelRequest.m_clientNonce))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedLifetime, openSecureChannelRequest.m_requestedLifetime))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (OpenSecureChannelRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OpenSecureChannelRequest obj = (OpenSecureChannelRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_clientProtocolVersion = (uint)Utils.Clone(m_clientProtocolVersion);
		obj.m_requestType = (SecurityTokenRequestType)Utils.Clone(m_requestType);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_clientNonce = (byte[])Utils.Clone(m_clientNonce);
		obj.m_requestedLifetime = (uint)Utils.Clone(m_requestedLifetime);
		return obj;
	}
}
