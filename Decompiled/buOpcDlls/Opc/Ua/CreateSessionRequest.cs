using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CreateSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private ApplicationDescription m_clientDescription;

	private string m_serverUri;

	private string m_endpointUrl;

	private string m_sessionName;

	private byte[] m_clientNonce;

	private byte[] m_clientCertificate;

	private double m_requestedSessionTimeout;

	private uint m_maxResponseMessageSize;

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

	[DataMember(Name = "ClientDescription", IsRequired = false, Order = 2)]
	public ApplicationDescription ClientDescription
	{
		get
		{
			return m_clientDescription;
		}
		set
		{
			m_clientDescription = value;
			if (value == null)
			{
				m_clientDescription = new ApplicationDescription();
			}
		}
	}

	[DataMember(Name = "ServerUri", IsRequired = false, Order = 3)]
	public string ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			m_serverUri = value;
		}
	}

	[DataMember(Name = "EndpointUrl", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "SessionName", IsRequired = false, Order = 5)]
	public string SessionName
	{
		get
		{
			return m_sessionName;
		}
		set
		{
			m_sessionName = value;
		}
	}

	[DataMember(Name = "ClientNonce", IsRequired = false, Order = 6)]
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

	[DataMember(Name = "ClientCertificate", IsRequired = false, Order = 7)]
	public byte[] ClientCertificate
	{
		get
		{
			return m_clientCertificate;
		}
		set
		{
			m_clientCertificate = value;
		}
	}

	[DataMember(Name = "RequestedSessionTimeout", IsRequired = false, Order = 8)]
	public double RequestedSessionTimeout
	{
		get
		{
			return m_requestedSessionTimeout;
		}
		set
		{
			m_requestedSessionTimeout = value;
		}
	}

	[DataMember(Name = "MaxResponseMessageSize", IsRequired = false, Order = 9)]
	public uint MaxResponseMessageSize
	{
		get
		{
			return m_maxResponseMessageSize;
		}
		set
		{
			m_maxResponseMessageSize = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CreateSessionRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CreateSessionRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CreateSessionRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CreateSessionRequest_Encoding_DefaultJson;

	public CreateSessionRequest()
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
		m_clientDescription = new ApplicationDescription();
		m_serverUri = null;
		m_endpointUrl = null;
		m_sessionName = null;
		m_clientNonce = null;
		m_clientCertificate = null;
		m_requestedSessionTimeout = 0.0;
		m_maxResponseMessageSize = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("ClientDescription", ClientDescription, typeof(ApplicationDescription));
		encoder.WriteString("ServerUri", ServerUri);
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteString("SessionName", SessionName);
		encoder.WriteByteString("ClientNonce", ClientNonce);
		encoder.WriteByteString("ClientCertificate", ClientCertificate);
		encoder.WriteDouble("RequestedSessionTimeout", RequestedSessionTimeout);
		encoder.WriteUInt32("MaxResponseMessageSize", MaxResponseMessageSize);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ClientDescription = (ApplicationDescription)decoder.ReadEncodeable("ClientDescription", typeof(ApplicationDescription));
		ServerUri = decoder.ReadString("ServerUri");
		EndpointUrl = decoder.ReadString("EndpointUrl");
		SessionName = decoder.ReadString("SessionName");
		ClientNonce = decoder.ReadByteString("ClientNonce");
		ClientCertificate = decoder.ReadByteString("ClientCertificate");
		RequestedSessionTimeout = decoder.ReadDouble("RequestedSessionTimeout");
		MaxResponseMessageSize = decoder.ReadUInt32("MaxResponseMessageSize");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CreateSessionRequest createSessionRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, createSessionRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientDescription, createSessionRequest.m_clientDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUri, createSessionRequest.m_serverUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, createSessionRequest.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionName, createSessionRequest.m_sessionName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientNonce, createSessionRequest.m_clientNonce))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientCertificate, createSessionRequest.m_clientCertificate))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedSessionTimeout, createSessionRequest.m_requestedSessionTimeout))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxResponseMessageSize, createSessionRequest.m_maxResponseMessageSize))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CreateSessionRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CreateSessionRequest obj = (CreateSessionRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_clientDescription = (ApplicationDescription)Utils.Clone(m_clientDescription);
		obj.m_serverUri = (string)Utils.Clone(m_serverUri);
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_sessionName = (string)Utils.Clone(m_sessionName);
		obj.m_clientNonce = (byte[])Utils.Clone(m_clientNonce);
		obj.m_clientCertificate = (byte[])Utils.Clone(m_clientCertificate);
		obj.m_requestedSessionTimeout = (double)Utils.Clone(m_requestedSessionTimeout);
		obj.m_maxResponseMessageSize = (uint)Utils.Clone(m_maxResponseMessageSize);
		return obj;
	}
}
