using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class OpenSecureChannelResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private uint m_serverProtocolVersion;

	private ChannelSecurityToken m_securityToken;

	private byte[] m_serverNonce;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
			}
		}
	}

	[DataMember(Name = "ServerProtocolVersion", IsRequired = false, Order = 2)]
	public uint ServerProtocolVersion
	{
		get
		{
			return m_serverProtocolVersion;
		}
		set
		{
			m_serverProtocolVersion = value;
		}
	}

	[DataMember(Name = "SecurityToken", IsRequired = false, Order = 3)]
	public ChannelSecurityToken SecurityToken
	{
		get
		{
			return m_securityToken;
		}
		set
		{
			m_securityToken = value;
			if (value == null)
			{
				m_securityToken = new ChannelSecurityToken();
			}
		}
	}

	[DataMember(Name = "ServerNonce", IsRequired = false, Order = 4)]
	public byte[] ServerNonce
	{
		get
		{
			return m_serverNonce;
		}
		set
		{
			m_serverNonce = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.OpenSecureChannelResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.OpenSecureChannelResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.OpenSecureChannelResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.OpenSecureChannelResponse_Encoding_DefaultJson;

	public OpenSecureChannelResponse()
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
		m_responseHeader = new ResponseHeader();
		m_serverProtocolVersion = 0u;
		m_securityToken = new ChannelSecurityToken();
		m_serverNonce = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteUInt32("ServerProtocolVersion", ServerProtocolVersion);
		encoder.WriteEncodeable("SecurityToken", SecurityToken, typeof(ChannelSecurityToken));
		encoder.WriteByteString("ServerNonce", ServerNonce);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		ServerProtocolVersion = decoder.ReadUInt32("ServerProtocolVersion");
		SecurityToken = (ChannelSecurityToken)decoder.ReadEncodeable("SecurityToken", typeof(ChannelSecurityToken));
		ServerNonce = decoder.ReadByteString("ServerNonce");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is OpenSecureChannelResponse openSecureChannelResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, openSecureChannelResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverProtocolVersion, openSecureChannelResponse.m_serverProtocolVersion))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityToken, openSecureChannelResponse.m_securityToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverNonce, openSecureChannelResponse.m_serverNonce))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (OpenSecureChannelResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OpenSecureChannelResponse obj = (OpenSecureChannelResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_serverProtocolVersion = (uint)Utils.Clone(m_serverProtocolVersion);
		obj.m_securityToken = (ChannelSecurityToken)Utils.Clone(m_securityToken);
		obj.m_serverNonce = (byte[])Utils.Clone(m_serverNonce);
		return obj;
	}
}
