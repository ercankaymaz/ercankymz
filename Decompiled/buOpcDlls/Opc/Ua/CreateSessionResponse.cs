using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CreateSessionResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private NodeId m_sessionId;

	private NodeId m_authenticationToken;

	private double m_revisedSessionTimeout;

	private byte[] m_serverNonce;

	private byte[] m_serverCertificate;

	private EndpointDescriptionCollection m_serverEndpoints;

	private SignedSoftwareCertificateCollection m_serverSoftwareCertificates;

	private SignatureData m_serverSignature;

	private uint m_maxRequestMessageSize;

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

	[DataMember(Name = "SessionId", IsRequired = false, Order = 2)]
	public NodeId SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			m_sessionId = value;
		}
	}

	[DataMember(Name = "AuthenticationToken", IsRequired = false, Order = 3)]
	public NodeId AuthenticationToken
	{
		get
		{
			return m_authenticationToken;
		}
		set
		{
			m_authenticationToken = value;
		}
	}

	[DataMember(Name = "RevisedSessionTimeout", IsRequired = false, Order = 4)]
	public double RevisedSessionTimeout
	{
		get
		{
			return m_revisedSessionTimeout;
		}
		set
		{
			m_revisedSessionTimeout = value;
		}
	}

	[DataMember(Name = "ServerNonce", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "ServerCertificate", IsRequired = false, Order = 6)]
	public byte[] ServerCertificate
	{
		get
		{
			return m_serverCertificate;
		}
		set
		{
			m_serverCertificate = value;
		}
	}

	[DataMember(Name = "ServerEndpoints", IsRequired = false, Order = 7)]
	public EndpointDescriptionCollection ServerEndpoints
	{
		get
		{
			return m_serverEndpoints;
		}
		set
		{
			m_serverEndpoints = value;
			if (value == null)
			{
				m_serverEndpoints = new EndpointDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "ServerSoftwareCertificates", IsRequired = false, Order = 8)]
	public SignedSoftwareCertificateCollection ServerSoftwareCertificates
	{
		get
		{
			return m_serverSoftwareCertificates;
		}
		set
		{
			m_serverSoftwareCertificates = value;
			if (value == null)
			{
				m_serverSoftwareCertificates = new SignedSoftwareCertificateCollection();
			}
		}
	}

	[DataMember(Name = "ServerSignature", IsRequired = false, Order = 9)]
	public SignatureData ServerSignature
	{
		get
		{
			return m_serverSignature;
		}
		set
		{
			m_serverSignature = value;
			if (value == null)
			{
				m_serverSignature = new SignatureData();
			}
		}
	}

	[DataMember(Name = "MaxRequestMessageSize", IsRequired = false, Order = 10)]
	public uint MaxRequestMessageSize
	{
		get
		{
			return m_maxRequestMessageSize;
		}
		set
		{
			m_maxRequestMessageSize = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CreateSessionResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CreateSessionResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CreateSessionResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CreateSessionResponse_Encoding_DefaultJson;

	public CreateSessionResponse()
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
		m_sessionId = null;
		m_authenticationToken = null;
		m_revisedSessionTimeout = 0.0;
		m_serverNonce = null;
		m_serverCertificate = null;
		m_serverEndpoints = new EndpointDescriptionCollection();
		m_serverSoftwareCertificates = new SignedSoftwareCertificateCollection();
		m_serverSignature = new SignatureData();
		m_maxRequestMessageSize = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteNodeId("SessionId", SessionId);
		encoder.WriteNodeId("AuthenticationToken", AuthenticationToken);
		encoder.WriteDouble("RevisedSessionTimeout", RevisedSessionTimeout);
		encoder.WriteByteString("ServerNonce", ServerNonce);
		encoder.WriteByteString("ServerCertificate", ServerCertificate);
		encoder.WriteEncodeableArray("ServerEndpoints", ServerEndpoints.ToArray(), typeof(EndpointDescription));
		encoder.WriteEncodeableArray("ServerSoftwareCertificates", ServerSoftwareCertificates.ToArray(), typeof(SignedSoftwareCertificate));
		encoder.WriteEncodeable("ServerSignature", ServerSignature, typeof(SignatureData));
		encoder.WriteUInt32("MaxRequestMessageSize", MaxRequestMessageSize);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		SessionId = decoder.ReadNodeId("SessionId");
		AuthenticationToken = decoder.ReadNodeId("AuthenticationToken");
		RevisedSessionTimeout = decoder.ReadDouble("RevisedSessionTimeout");
		ServerNonce = decoder.ReadByteString("ServerNonce");
		ServerCertificate = decoder.ReadByteString("ServerCertificate");
		ServerEndpoints = (EndpointDescription[])decoder.ReadEncodeableArray("ServerEndpoints", typeof(EndpointDescription));
		ServerSoftwareCertificates = (SignedSoftwareCertificate[])decoder.ReadEncodeableArray("ServerSoftwareCertificates", typeof(SignedSoftwareCertificate));
		ServerSignature = (SignatureData)decoder.ReadEncodeable("ServerSignature", typeof(SignatureData));
		MaxRequestMessageSize = decoder.ReadUInt32("MaxRequestMessageSize");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CreateSessionResponse createSessionResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, createSessionResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionId, createSessionResponse.m_sessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_authenticationToken, createSessionResponse.m_authenticationToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedSessionTimeout, createSessionResponse.m_revisedSessionTimeout))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverNonce, createSessionResponse.m_serverNonce))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCertificate, createSessionResponse.m_serverCertificate))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverEndpoints, createSessionResponse.m_serverEndpoints))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverSoftwareCertificates, createSessionResponse.m_serverSoftwareCertificates))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverSignature, createSessionResponse.m_serverSignature))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxRequestMessageSize, createSessionResponse.m_maxRequestMessageSize))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CreateSessionResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CreateSessionResponse obj = (CreateSessionResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_sessionId = (NodeId)Utils.Clone(m_sessionId);
		obj.m_authenticationToken = (NodeId)Utils.Clone(m_authenticationToken);
		obj.m_revisedSessionTimeout = (double)Utils.Clone(m_revisedSessionTimeout);
		obj.m_serverNonce = (byte[])Utils.Clone(m_serverNonce);
		obj.m_serverCertificate = (byte[])Utils.Clone(m_serverCertificate);
		obj.m_serverEndpoints = (EndpointDescriptionCollection)Utils.Clone(m_serverEndpoints);
		obj.m_serverSoftwareCertificates = (SignedSoftwareCertificateCollection)Utils.Clone(m_serverSoftwareCertificates);
		obj.m_serverSignature = (SignatureData)Utils.Clone(m_serverSignature);
		obj.m_maxRequestMessageSize = (uint)Utils.Clone(m_maxRequestMessageSize);
		return obj;
	}
}
